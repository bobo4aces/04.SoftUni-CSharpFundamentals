using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        List<Character> characterParty = new List<Character>();
        List<Item> itemPool = new List<Item>();
        int rounds = 0;

        public string JoinParty(string[] args)
        {
            string faction = args[1];
            string characterType = args[2];
            string name = args[3];
            CharacterFactory characterFactory = new CharacterFactory();
            Character character = characterFactory.CreateCharacter(faction, characterType, name);
            characterParty.Add(character);
            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[1];
            ItemFactory itemFactory = new ItemFactory();
            Item item = itemFactory.CreateItem(itemName);
            itemPool.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[1];
            Character character = characterParty.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (itemPool.Count() == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }
            int lastIndex = itemPool.Count - 1;
            Item lastItem = itemPool[lastIndex];
            itemPool.RemoveAt(lastIndex);
            character.ReceiveItem(lastItem);
            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[1];
            string itemName = args[2];
            Character character = characterParty.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{character.Name} used {item.GetType().Name}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[1];
            string receiverName = args[2];
            string itemName = args[3];

            Character giver = characterParty.FirstOrDefault(c => c.Name == giverName);
            Character receiver = characterParty.FirstOrDefault(c => c.Name == receiverName);
            Item item = itemPool.FirstOrDefault(c => c.GetType().Name == itemName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if (item == null)
            {
                throw new ArgumentException($"Item {itemName} not found!");
            }
            giver.UseItemOn(item, receiver);
            return $"{giver.Name} used {item.GetType().Name} on {receiver.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[1];
            string receiverName = args[2];
            string itemName = args[3];

            Character giver = characterParty.FirstOrDefault(c => c.Name == giverName);
            Character receiver = characterParty.FirstOrDefault(c => c.Name == receiverName);
            Item item = itemPool.FirstOrDefault(c => c.GetType().Name == itemName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if (item == null)
            {
                throw new ArgumentException($"Character {itemName} not found!");
            }
            giver.GiveCharacterItem(item, receiver);
            return $"{giver.Name} gave {receiver.Name} {item.GetType().Name}.";
        }

        public string GetStats()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var character in characterParty.OrderByDescending(c=>c.IsAlive).ThenByDescending(c=>c.Health))
            {
                string status = character.IsAlive ? "Alive" : "Dead";
                stringBuilder
                    .AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, " +
                    $"AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[1];
            string receiverName = args[2];

            Character attacker = characterParty.FirstOrDefault(c => c.Name == attackerName);
            Character receiver = characterParty.FirstOrDefault(c => c.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            //TODO Check if is IAttackable is correct
            if (attacker is IAttackable attackerCharacter)
            {
                attackerCharacter.Attack(receiver);
            }
            else
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
            string output = $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! " +
                $"{receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and " +
                $"{receiver.Armor}/{receiver.BaseArmor} AP left!";
            if (!receiver.IsAlive)
            {
                output += $"\n{receiver.Name} is dead!";
            }
            return output;
        }

        public string Heal(string[] args)
        {
            string healerName = args[1];
            string healingReceiverName = args[2];

            Character healer = characterParty.FirstOrDefault(c => c.Name == healerName);
            Character healingReceiver = characterParty.FirstOrDefault(c => c.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (healingReceiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }
            //TODO Check this, too
            if (healer is IHealable healerCharacter)
            {
                healerCharacter.Heal(healingReceiver);
            }
            else
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }
            string output = $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! " +
                $"{healingReceiver.Name} has {healingReceiver.Health} health now!";

            return output;
        }

        public string EndTurn(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int count = characterParty.Where(c => c.IsAlive).Count();
            //TODO First check if character rests correctly then do this
            // - If there are one or zero alive characters left, the last survivor rounds are incremented by one.
            foreach (var character in characterParty.Where(c => c.IsAlive))
            {
                stringBuilder.Append($"{character.Name} rests ({character.Health} => ");
                if (count == 0 || count == 1)
                {
                    character.Health++; 
                    rounds++;
                    IsGameOver();
                }
                else
                {
                    character.Rest();
                }
                stringBuilder.AppendLine($"{character.Health})");
            }
            
            return stringBuilder.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            return rounds > 1;
        }

    }
}
