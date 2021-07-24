using System;
using System.Collections.Generic;
using System.Text;
using QuasarConvoy.Entities;
using QuasarConvoy.Models;

namespace QuasarConvoy
{
    public class Save
    {
        public int currency;
        public List<ShipData> convoy;
        public List<ShipData> enemy;
        public List<PlanetData> planets;

        public Save()
        {
        }
    }
}
