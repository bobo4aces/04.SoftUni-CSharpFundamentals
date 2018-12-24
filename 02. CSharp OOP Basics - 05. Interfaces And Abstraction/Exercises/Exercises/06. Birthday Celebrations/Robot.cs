using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Robot : IRobot
    {
        public string Model { get; private set; }
        public string Id { get; private set; }

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public List<Robot> GetFakeIds(List<Robot> robots, char character)
        {
            return robots.Where(r => r.Id[r.Id.Length - 1] == character).ToList();
        }
    }
}