using System;
using System.Collections.Generic;
using System.Text;
using QuasarConvoy.Models;

namespace QuasarConvoy.Managers
{
    public struct ItemDetails
    {
        public string name;
        public byte rarity;
        public int avgPrice;
        public byte itemType;

        public ItemDetails(string n, byte rar, int ap, byte t)
        {
            name = n;
            rarity = rar;
            avgPrice = ap;
            itemType = t;
        }
    }
    static class ItemManager
    {
        #region Lists&Index

        public static List<ItemDetails> ItemIndex = new List<ItemDetails>
        {
            new ItemDetails("NULL",0,0,0),
            new ItemDetails("OAK WOOD",1,2,2),
            new ItemDetails("COPPER ORE",1,5,1),
            new ItemDetails("IRON ORE",1,5,1),
            new ItemDetails("GOLD ORE",1,10,1),
            new ItemDetails("URANIUM",2,25,1),
            new ItemDetails("CLOTH",1,2,5),
            new ItemDetails("ICE CUBES",1,1,2),
            new ItemDetails("HOPPER STONE",1,15,1),
            new ItemDetails("TITAN STONE",2,50,1),
            new ItemDetails("PERMA ICE",2,30,2),
            new ItemDetails("FROZEN TRUFFLE",2,25,3),
            new ItemDetails("WEIRD FISH",3,150,2),
            new ItemDetails("BONE SHARDS",1,5,2),
            new ItemDetails("STAR DUST",2,75,2),
            new ItemDetails("POISON",2,50,5),
            new ItemDetails("FEATHER",1,1,2),
            new ItemDetails("JEWELRY",3,250,5),
            new ItemDetails("VENDOR STONE",1,25,1),
            new ItemDetails("GEMSTONES",2,100,1),
            new ItemDetails("VENDORIL ORE",3,300,1),
            new ItemDetails("THERSEN ORE",4,1000,1),
            new ItemDetails("DRAGON FANGS",3,350,2),
            new ItemDetails("DIAMOND",2,100,4),
            new ItemDetails("ENERGY CRYSTAL",2,250,4),
            new ItemDetails("LIGHT CRYSTAL",3,500,4),
            new ItemDetails("DARK CRYSTAL",3,500,4),
            new ItemDetails("HAPPY CRYSTAL",4,2500,4),
            new ItemDetails("CRYSTAL FRAGMENTS",1,25,4),
            new ItemDetails("MYTHRIL ORE",3,300,1),
            new ItemDetails("CREME BRULEE",4,1000,3),
            new ItemDetails("DEHYDRATED WATER",2,1,3),
        };

        public static List<string> Rarities = new List<string>
        {
            "NULL","COMMON", "RARE","EPIC","LEGENDARY"
        };
        public static List<string> Types = new List<string>
        {
            "NULL","MINE", "NATURE", "FOOD", "CRYSTALS", "OTHER"
        };
        #endregion

        #region Getters
        public static ItemDetails GetItemDetails(int id)
        {
            return ItemIndex[id];
        }

        public static string GetItemName(int id)
        {
            return ItemIndex[id].name;
        }
        public static int GetItemPrice(int id)
        {
            return ItemIndex[id].avgPrice;
        }
        public static byte GetItemTypeN(int id)
        {
            return ItemIndex[id].itemType;
        }
        public static byte GetItemRarityN(int id)
        {
            return ItemIndex[id].rarity;
        }
        public static string GetItemTypeS(int id)
        {
            return Types[ItemIndex[id].itemType];
        }
        public static string GetItemRarityS(int id)
        {
            return Rarities[ItemIndex[id].rarity];
        }
        public static int GetInventoryVolume(IEnumerable<ItemData> Inventory)
        {
            int v = 0;
            foreach (ItemData i in Inventory)
                v += i.count;
            return v;
        }
        #endregion

        #region Operations
        public static void AddToInventory(List<ItemData> Inventory, ItemData itemData)
        {
            foreach (ItemData i in Inventory)
            {
                if (i.id == itemData.id)
                {
                    i.count += itemData.count;
                    return;
                }
            }
            Inventory.Add(itemData);
        }

        public static void SubstractFromInventory(List<ItemData> Inventory, ItemData itemData)
        {
            foreach (ItemData i in Inventory)
            {
                if (i.id == itemData.id)
                {
                    if (itemData.count > i.count)
                        i.count -= itemData.count;
                    else
                    {
                        Inventory.Remove(i);
                    }
                    return;
                }
            }
        }

        public static void TransferItem(List<ItemData> InventoryFrom, List<ItemData> InventoryTo, ItemData itemData)
        {
            int c=itemData.count;
            bool found=false;
            foreach (ItemData i in InventoryFrom)
            {
                if (i.id == itemData.id)
                {
                    found = true;
                    if (itemData.count > i.count)
                        i.count -= itemData.count;
                    else
                    {
                        c = i.count;
                        InventoryFrom.Remove(i);
                    }
                    break;
                }
            }

            if (found)
                AddToInventory(InventoryTo, new ItemData(itemData.id, c));
        }
        #endregion
    }
}
