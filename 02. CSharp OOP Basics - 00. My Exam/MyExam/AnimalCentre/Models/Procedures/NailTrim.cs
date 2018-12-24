using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        public ICollection<IAnimal> ProcedureHistory { get; }

        public NailTrim()
        {
            ProcedureHistory = new List<IAnimal>();
        }

        public string History()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{GetType().Name}");
            foreach (var animal in ProcedureHistory)
            {
                stringBuilder.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.Happiness -= 7;
            ProcedureHistory.Add(animal);
        }

    }
}
