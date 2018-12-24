using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Enums;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out Faction parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            switch (characterType.ToLower())
            {
                case "cleric":
                    return new Cleric(name, parsedFaction);
                case "warrior":
                    return new Warrior(name, parsedFaction);
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
        }
    }
}
