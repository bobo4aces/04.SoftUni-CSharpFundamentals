using GrandPrix.Entities.Cars;
using GrandPrix.Entities.Tyres;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Factories
{
    public class CarFactory
    {
        public Car CreateCar(int hp, double fuelAmount, Tyre tyre)
        {
            Car car = new Car(hp, fuelAmount, tyre);
            return car;
        }
    }
}
