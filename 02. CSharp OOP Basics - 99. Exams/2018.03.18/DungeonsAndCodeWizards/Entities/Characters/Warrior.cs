using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Enums;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) 
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                if (Equals(character))
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                if (Faction == character.Faction)
                {
                    throw new ArgumentException($"Friendly fire! Both characters are from {Faction} faction!");
                }
                character.TakeDamage(AbilityPoints);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
