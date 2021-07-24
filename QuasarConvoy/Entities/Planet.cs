using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuasarConvoy.Models;
using QuasarConvoy.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuasarConvoy.Entities
{
    public class Planet
    {
        ContentManager _content;
        public string Name;
        public Vector2 Position { set; get; }
        public PlanetSprite _sprite;
        public Sprite _icon;
        public float Size { get; set; }
        public string Type { get; set; }
        public bool IsVisible { set; get; }
        public int ID { set; get; }

        public List<ItemData> Inventory;
        public Planet(ContentManager Content)
        {
            _content = Content;
            IsVisible = false;

        }

        public Planet(Texture2D texture)
        {
            _sprite = new PlanetSprite(texture);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

    }
}
