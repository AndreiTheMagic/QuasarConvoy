using System;
using System.Collections.Generic;
using System.Text;

namespace QuasarConvoy.Models
{
    public class ItemData
    {
        public byte id;
        public int count;

        public ItemData()
        { }

        public ItemData(byte itemID, int nrOfItems)
        {
            id = itemID;
            count = nrOfItems;
        }
    }
}
