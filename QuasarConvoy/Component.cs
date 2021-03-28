﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuasarConvoy
{
    public abstract class Component
    {
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime, SpriteBatch spriteBatch);
        
    }
}
