using DungeonsAndCodeWizards.Entities.Items;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            switch (name.ToLower())
            {
                case "armorrepairkit":
                    return new ArmorRepairKit();
                case "healthpotion":
                    return new HealthPotion();
                case "poisonpotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{name}\"!");
            }
        }
    }
}
