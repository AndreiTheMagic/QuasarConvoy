using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuasarConvoy.Controls;
using QuasarConvoy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuasarConvoy.States
{
    public class GatheringState : State
    {
        private SpriteFont font;

        private Texture2D textureBar;
        private Rectangle textureBarFrame;

        private Texture2D Mule, Elephant, Collector;
        private Button MuleButton, ElephantButton, CollectorButton;

        private string mules, elephants, collectors;
        private int mulesInMission, elephantsInMission, collectorsInMission;

        private DBManager dBManager;
        private string query;

        private List<string> TimerWatch;

        private List<Component> components;

        private void Load(ContentManager _contentManager)
        {
            dBManager = new DBManager();
            font = _contentManager.Load<SpriteFont>("Fonts/Font");

            textureBar = _contentManager.Load<Texture2D>("UI Stuff/Images/TradeTexture Bar");
            textureBarFrame = new Rectangle(0, textureBar.Height, Game1.ScreenWidth, Game1.ScreenHeight / 20);

            Mule = _contentManager.Load<Texture2D>("mule");
            Elephant = _contentManager.Load<Texture2D>("elephant");
            Collector = _contentManager.Load<Texture2D>("collector");

            mulesInMission = elephantsInMission = collectorsInMission = 0;

            query = "SELECT COUNT(*) FROM [Ships] WHERE ID_Model = 2";
            mules = "x" + int.Parse(dBManager.SelectElement(query)) + "\n" + "=> x" + mulesInMission;
            query = "SELECT COUNT(*) FROM [Ships] WHERE ID_Model = 4";
            elephants = "x" + int.Parse(dBManager.SelectElement(query)) + "\n" + "=> x" + elephantsInMission;
            query = "SELECT COUNT(*) FROM [Ships] WHERE ID_Model = 3";
            collectors = "x" + int.Parse(dBManager.SelectElement(query)) + "\n" + "=> x" + collectorsInMission;
        }

        public GatheringState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _contentManager) : base(_game, _graphicsDevice, _contentManager)
        {
            Load(_contentManager);

            MuleButton = new Button(Mule, _contentManager)
            {
                Position = new Vector2(Game1.ScreenWidth / 4 - Mule.Width / 2, textureBarFrame.Y + textureBarFrame.Height + 100),
            };
            MuleButton.Click += MuleButton_Click;

            ElephantButton = new Button(Elephant, _contentManager)
            {
                Position = new Vector2(Game1.ScreenWidth / 2 - Elephant.Width / 2, MuleButton.Position.Y),
            };
            ElephantButton.Click += ElephantButton_Click;

            CollectorButton = new Button(Collector, _contentManager)
            {
                Position = new Vector2(3 * Game1.ScreenWidth / 4 - Collector.Width / 2, MuleButton.Position.Y),
            };
            CollectorButton.Click += CollectorButton_Click;

            MuleButton.activeButton = false; MuleButton.scale = 0.7f;
            ElephantButton.activeButton = false; ElephantButton.scale = 0.7f;
            CollectorButton.activeButton = false; CollectorButton.scale = 0.7f;

            components = new List<Component>()
            {
                MuleButton,
                ElephantButton,
                CollectorButton,
            };
        }

        

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(font, mules, new Vector2(MuleButton.Position.X, MuleButton.Position.Y + MuleButton.Rectangle.Height), Color.White);
            spriteBatch.DrawString(font, elephants, new Vector2(ElephantButton.Position.X, ElephantButton.Position.Y + ElephantButton.Rectangle.Height), Color.White);
            spriteBatch.DrawString(font, collectors, new Vector2(CollectorButton.Position.X, CollectorButton.Position.Y + CollectorButton.Rectangle.Height), Color.White);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.IsPressed(Keys.Escape))
                game.ChangeStates(game.GameState);

            foreach (var component in components)
                component.Update(gameTime);
        }

        private void CollectorButton_Click(object sender, EventArgs e)
        {

        }

        private void ElephantButton_Click(object sender, EventArgs e)
        {

        }

        private void MuleButton_Click(object sender, EventArgs e)
        {
            query = "SELECT COUNT(*) FROM [Ships] WHERE ID_Model = 2";
            if(int.Parse(dBManager.SelectElement(query)) != 0)
            {
                query = "SELECT * FROM [Ships] WHERE ID_Model = 2";
                List<string> ids = dBManager.SpecificSelectColumnFrom("[Ships]", "ID", "ID_Model", "2");
                query = "DELETE FROM [Ships] WHERE ID = " + ids[0];
                dBManager.QueryIUD(query);
                
                query = "SELECT COUNT(*) FROM [Ships] WHERE ID_Model = 2";
                mules = "x" + int.Parse(dBManager.SelectElement(query)) + "\n" + "=> x" + ++mulesInMission;
            }
        }
    }
}
