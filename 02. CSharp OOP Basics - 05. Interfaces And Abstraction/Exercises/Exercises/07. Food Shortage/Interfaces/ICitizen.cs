using System;
using System.Collections.Generic;

namespace FoodShortage
{
    public interface ICitizen
    {
        string Name { get; }
        int Age { get; }
        string Id { get; }
        string Birthday { get; }

        List<Citizen> GetFakeIds(List<Citizen> citizens, char digit);
    }
}
