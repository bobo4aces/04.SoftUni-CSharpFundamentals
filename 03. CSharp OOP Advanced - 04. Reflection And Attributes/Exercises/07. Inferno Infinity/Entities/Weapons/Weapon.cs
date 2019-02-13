using _07._Inferno_Infinity.Contracts;
using _07._Inferno_Infinity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Inferno_Infinity.Entities.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int minDamage;

        private int maxDamage;

        protected Weapon(string name, int minDamage, int maxDamage, int sockets, Rearity rearity)
        {
            this.Rearity = rearity;
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Sockets = sockets;
            this.Gems = new IGem[sockets];
        }

        public string Name { get; private set; }

        public int MinDamage
        {
            get
            {
                return this.minDamage;
            }
            private set
            {
                Type type = typeof(Rearity);
                this.minDamage = value * (int)this.Rearity;
            }
        }

        public int MaxDamage
        {
            get
            {
                return this.maxDamage;
            }
            private set
            {
                Type type = typeof(Rearity);
                this.maxDamage = value * (int)this.Rearity;
            }
        }
        public int Sockets { get; private set; }

        public Rearity Rearity { get; private set; }

        public IGem[] Gems { get; private set; }


        public void AddGem(int index, IGem gem)
        {
            if (index >= 0 && index < this.Gems.Length)
            {
                this.Gems[index] = gem;
                IncreaseDemageValuesByGem(gem);
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < this.Gems.Length && this.Gems[index] != null)
            {
                IGem gem = this.Gems[index];
                this.Gems[index] = null;
                DecreaseDemageValuesByGem(gem);
            }
        }

        private void IncreaseDemageValuesByGem(IGem gem)
        {
            this.MinDamage += gem.Strength * 2 + gem.Agility * 1;
            this.MaxDamage += gem.Strength * 3 + gem.Agility * 4;
        }

        private void DecreaseDemageValuesByGem(IGem gem)
        {
            this.MinDamage -= gem.Strength * 2 + gem.Agility * 1;
            this.MaxDamage -= gem.Strength * 3 + gem.Agility * 4;
        }

        public override string ToString()
        {
            int totalStrength = this.Gems.Where(g => g != null).Sum(g => g.Strength);
            int totalAgility = this.Gems.Where(g => g != null).Sum(g => g.Agility);
            int totalVitality = this.Gems.Where(g => g != null).Sum(g => g.Vitality);
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{totalStrength} Strength, +{totalAgility} Agility, +{totalVitality} Vitality";
        }
    }
}
