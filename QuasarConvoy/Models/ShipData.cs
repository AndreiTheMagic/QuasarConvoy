using Microsoft.Xna.Framework;
using QuasarConvoy.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuasarConvoy.Models
{
    public class ShipData
    {
        public Vector2 Position;
        public float Rotation;
        public int ModelID;

        public ShipData()
        { }

        public ShipData(Ship s)
        {
            Position = s.Position;
            Rotation = s.Rotation;
            ModelID = s.model;
        }
    }
}
