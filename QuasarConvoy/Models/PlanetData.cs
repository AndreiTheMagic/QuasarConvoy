using Microsoft.Xna.Framework;
using QuasarConvoy.Entities;
using System;
using System.Collections.Generic;

using System.Text;

namespace QuasarConvoy.Models
{
    public class PlanetData
    {
        public string Name;
        public Vector2 Position;
        public float Size;
        public List<ItemData> Inventory;
        public PlanetData()
        {

        }

        public PlanetData(Planet p)
        {
            Name = p.Name;
            Position = p.Position;
            Size = p.Size;
            Inventory = p.Inventory;
        }
    }
}
