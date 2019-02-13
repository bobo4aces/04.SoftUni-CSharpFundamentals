// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    using Travel.Core.Controllers;
    using Travel.Core.Controllers.Contracts;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void CheckIfAirplaneIsOverbooked()
        {
            IAirport airport = new Airport();
            IAirplane airplane = new LightAirplane();
            ITrip trip = new Trip("Tuk", "Tam", airplane);
            airplane.AddPassenger(new Passenger("Pesho1"));
            airplane.AddPassenger(new Passenger("Pesho2"));
            airplane.AddPassenger(new Passenger("Pesho3"));
            airplane.AddPassenger(new Passenger("Pesho4"));
            airplane.AddPassenger(new Passenger("Pesho5"));
            airplane.AddPassenger(new Passenger("Pesho6"));
            airport.AddTrip(trip);
            IFlightController flightController = new FlightController(airport);

            string expectedResult = "TukTam1:\r\nOverbooked! Ejected Pesho2\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 0 (0 items) => $0";
            string actualResult = flightController.TakeOff();

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(trip.IsCompleted, true);
        }

        [Test]
        public void CheckIfTripIsCompleted()
        {
            IAirport airport = new Airport();
            IAirplane airplane = new LightAirplane();
            ITrip trip = new Trip("Tuk", "Tam", airplane);
            airplane.AddPassenger(new Passenger("Pesho1"));
            airport.AddTrip(trip);
            trip.Complete();
            IFlightController flightController = new FlightController(airport);
            string expectedResult = "Confiscated bags: 0 (0 items) => $0";
            string actualResult = flightController.TakeOff();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestLoadCarryOnBaggage()
        {
            IAirport airport = new Airport();
            IAirplane airplane = new LightAirplane();
            IPassenger[] passengers = new Passenger[10];
            for (int i = 0; i < 10; i++)
            {
                passengers[i] = new Passenger("Pesho" + i);
                airplane.AddPassenger(passengers[i]);
                if (i % 2 == 0)
                {
                    IBag bag = new Bag(passengers[i], new Item[] { new Colombian() });
                    passengers[i].Bags.Add(bag);
                }
            }

            ITrip trip = new Trip("Tuk", "Tam", airplane);
            airport.AddTrip(trip);
            IFlightController flightController = new FlightController(airport);

            string expectedResult = "TukTam3:\r\nOverbooked! Ejected Pesho1, Pesho0, Pesho3, Pesho7, Pesho8\r\nConfiscated 2 bags ($100000)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 2 (2 items) => $100000";

            string actualResult = flightController.TakeOff();

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
