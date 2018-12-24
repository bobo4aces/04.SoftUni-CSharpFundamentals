using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Factories
{
    public class ProcedureFactory
    {
        public Procedure CreateProcedure(string type)
        {
            switch (type)
            {
                case "Chip":
                    return new Chip();
                case "DentalCare":
                    return new DentalCare();
                case "Fitness":
                    return new Fitness();
                case "NailTrim":
                    return new NailTrim();
                case "Play":
                    return new Play();
                case "Vaccinate":
                    return new Vaccinate();
                default:
                    return null;
            }
        }
    }
}
