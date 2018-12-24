using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public ICollection<IAnimal> ProcedureHistory { get; set; }

        public Chip()
        {
            ProcedureHistory = new List<IAnimal>();
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            base.DoService(animal, procedureTime);

            animal.Happiness -= 5;
            animal.IsChipped = true;
            ProcedureHistory.Add(animal);
        }

        public string History()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine(ProcedureHistory.Count);
            foreach (var animal in ProcedureHistory)
            {
                stringBuilder.AppendLine($"{GetType().Name}");
                stringBuilder.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
