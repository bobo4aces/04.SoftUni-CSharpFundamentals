using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Enums;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public double BaseHealth { get; set; }
        public double BaseArmor { get; set; }
        public double AbilityPoints { get; set; }
        public Bag Bag { get; set; }
        public Faction Faction { get; set; }

        public bool IsAlive { get; set; } = true;
        public virtual double RestHealMultiplier { get; set; } = 0.2;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            //TODO Probably must add BaseHealth = health and BaseArmor = armor
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Faction = faction;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double Health
        {
            get
            {
                return health;
            }
            internal set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            internal set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else if (value > BaseArmor)
                {
                    armor = BaseArmor;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                double leftHitPoints = Armor - hitPoints;
                Armor -= hitPoints;
                if (leftHitPoints < 0)
                {
                    Health -= Math.Abs(leftHitPoints);
                }
                if (Health <= 0)
                {
                    IsAlive = false;
                }
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void Rest()
        {
            if (IsAlive)
            {
                Health += BaseHealth * RestHealMultiplier;
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                Bag.GetItem(item.GetType().Name);
                character.Bag.AddItem(item);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void ReceiveItem(Item item)
        {
            if (IsAlive)
            {
                Bag.AddItem(item);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
