using System;
using System.Collections.Generic;

namespace CSharp
{

    enum ItemType
    {
        Weapon,
        Armor,
        Amulet,
        Ring
    }


    enum Rarity
    {
        Normal,
        Uncommon,
        Rare
    }
    class Item
    {
        public ItemType ItemType;
        public Rarity Rarity;

    }

    class Program
    {
        static List<Item> _items = new List<Item>();

        delegate bool ItemSelector(Item item);

        static Item FindItem(ItemSelector selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }
            return null;
        }

        static bool IsWeapon(Item item)
        {
            return item.ItemType == ItemType.Weapon;
        }

        static void Main(string[] args)
        {
            _items.Add(new Item() { ItemType = ItemType.Weapon, Rarity = Rarity.Normal });
            _items.Add(new Item() { ItemType = ItemType.Armor, Rarity = Rarity.Uncommon });
            _items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });

            Item item = FindItem(delegate (Item item)
            {
                return item.ItemType == ItemType.Weapon;
            });

            Func<Item, bool> selector = (Item item) => { return item.ItemType == ItemType.Weapon; };
            Item item2 = FindItem(selector);
            return;
        
        }
    }
}
