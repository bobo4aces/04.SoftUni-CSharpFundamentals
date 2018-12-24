using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        public int Capacity { get; set; }
        public int Load { get; set; }
        public IReadOnlyCollection<Item> Items { get; set; }

        public Bag(int capacity)
        {
            Capacity = capacity;
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            List<Item> currentItems = Items.ToList();
            currentItems.Add(item);
            Items = currentItems;
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            Item item = Items.FirstOrDefault(i => i.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            
            List<Item> currentItems = Items.ToList();
            currentItems.Remove(item);
            Items = currentItems;
            return item;
        }
    }
}
