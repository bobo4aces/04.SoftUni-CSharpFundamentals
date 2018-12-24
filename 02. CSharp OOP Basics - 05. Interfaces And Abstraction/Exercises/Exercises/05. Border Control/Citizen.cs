using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Citizen : ICitizen
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public List<Citizen> GetFakeIds(List<Citizen> citizens, char character)
        {
            return citizens.Where(c => c.Id[c.Id.Length - 1] == character).ToList();
        }
    }
}