using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Enums;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) 
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
            RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                if (Faction != character.Faction)
                {
                    throw new InvalidOperationException("Cannot heal enemy character!");
                }
                character.Health += AbilityPoints;
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
