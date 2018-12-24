using AnimalCentre.Models.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCentre;
        public Engine()
        {
            animalCentre = new AnimalCentre();
        }
        public void Run()
        {
            string[] inputArgs = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string command = inputArgs[0].ToLower();
            string type = string.Empty;
            string name = string.Empty;
            string owner = string.Empty;
            string procedureType = string.Empty;
            int energy = 0;
            int happiness = 0;
            int procedureTime = 0;
            string output = string.Empty;
            while (command != "end")
            {
                try
                {
                    switch (command)
                    {
                        case "registeranimal":
                            type = inputArgs[1];
                            name = inputArgs[2];
                            energy = int.Parse(inputArgs[3]);
                            happiness = int.Parse(inputArgs[4]);
                            procedureTime = int.Parse(inputArgs[5]);
                            output = animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                            break;
                        case "chip":
                            name = inputArgs[1];
                            procedureTime = int.Parse(inputArgs[2]);
                            output = animalCentre.Chip(name, procedureTime);
                            break;
                        case "vaccinate":
                            name = inputArgs[1];
                            procedureTime = int.Parse(inputArgs[2]);
                            output = animalCentre.Vaccinate(name, procedureTime);
                            break;
                        case "fitness":
                            name = inputArgs[1];
                            procedureTime = int.Parse(inputArgs[2]);
                            output = animalCentre.Fitness(name, procedureTime);
                            break;
                        case "play":
                            name = inputArgs[1];
                            procedureTime = int.Parse(inputArgs[2]);
                            output = animalCentre.Play(name, procedureTime);
                            break;
                        case "dentalcare":
                            name = inputArgs[1];
                            procedureTime = int.Parse(inputArgs[2]);
                            output = animalCentre.DentalCare(name, procedureTime);
                            break;
                        case "nailtrim":
                            name = inputArgs[1];
                            procedureTime = int.Parse(inputArgs[2]);
                            output = animalCentre.NailTrim(name, procedureTime);
                            break;
                        case "adopt":
                            name = inputArgs[1];
                            owner = inputArgs[2];
                            output = animalCentre.Adopt(name, owner);
                            break;
                        case "history":
                            procedureType = inputArgs[1];
                            output = animalCentre.History(procedureType);
                            break;
                        default:
                            throw new ArgumentException("Invalid command");
                    }
                    Console.WriteLine(output);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"InvalidOperationException: {e.Message}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"ArgumentException: {e.Message}");
                }
                inputArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                command = inputArgs[0].ToLower();
            }

            //foreach (var animal in pro)
            //{
            //    Console.WriteLine($"--Owner: {animal.Value.Owner}");
            //    Console.WriteLine($"    - Adopted animals: {animal.Value}");
            //}
        }
    }
}
