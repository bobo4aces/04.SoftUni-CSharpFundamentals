using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public interface IRobot
    {
        string Model { get; }
        string Id { get; }

        List<Robot> GetFakeIds(List<Robot> robots, char character);
    }
}
