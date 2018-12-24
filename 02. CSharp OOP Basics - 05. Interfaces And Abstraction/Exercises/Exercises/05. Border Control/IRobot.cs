using System.Collections.Generic;

namespace BorderControl
{
    public interface IRobot
    {
        string Model { get; }
        string Id { get; }

        List<Robot> GetFakeIds(List<Robot> robots, char character);
    }
}
