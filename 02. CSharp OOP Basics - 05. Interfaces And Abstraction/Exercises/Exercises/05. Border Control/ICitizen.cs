using System.Collections.Generic;

namespace BorderControl
{
    public interface ICitizen
    {
        string Name { get; }
        int Age { get; }
        string Id { get; }

        List<Citizen> GetFakeIds(List<Citizen> citizens, char digit);
    }
}
