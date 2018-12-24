using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Factories;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private AnimalFactory animalFactory;
        private HotelFactory hotelFactory;
        private ProcedureFactory procedureFactory;
        private Hotel hotel;

        public AnimalCentre()
        {
            animalFactory = new AnimalFactory();
            hotelFactory = new HotelFactory();
            procedureFactory = new ProcedureFactory();
            hotel = hotelFactory.CreateHotel();
        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Animal animal = animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);
            hotel.Accommodate(animal);
            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            Procedure procedure = procedureFactory.CreateProcedure("Chip");
            procedure.DoService(hotel.Animals[name], procedureTime);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            Procedure procedure = procedureFactory.CreateProcedure("Vaccinate");
            procedure.DoService(hotel.Animals[name], procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            Procedure procedure = procedureFactory.CreateProcedure("Fitness");
            procedure.DoService(hotel.Animals[name], procedureTime);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            Procedure procedure = procedureFactory.CreateProcedure("Play");
            procedure.DoService(hotel.Animals[name], procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            Procedure procedure = procedureFactory.CreateProcedure("DentalCare");
            procedure.DoService(hotel.Animals[name], procedureTime);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            Procedure procedure = procedureFactory.CreateProcedure("NailTrim");
            procedure.DoService(hotel.Animals[name], procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = hotel.Animals[animalName];
            hotel.Adopt(animalName, owner);
            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            Procedure procedure = procedureFactory.CreateProcedure(type);
            //foreach (var animal in hotel.Animals)
            //{
            //    animal.Value.
            //}
            return procedure.History();
        }

    }
}
