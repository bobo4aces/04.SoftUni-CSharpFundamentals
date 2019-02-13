// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    //using Travel.Core.Controllers;
    //using Travel.Entities;
    //using Travel.Entities.Airplanes;
    //using Travel.Entities.Items;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void CheckIfTripIsCompleted()
        {
            var airport = new Airport();
            var airplane = new LightAirplane();
            var trip = new Trip("Tuk", "Tam", airplane);
            var passenger = new Passenger("Gosho");
            var bag = new Bag(passenger, new Item[] { new Colombian() });
            passenger.Bags.Add(bag);
            airport.AddTrip(trip);
            trip.Complete();

            var flightController = new FlightController(airport);

            var expectedResult = flightController.TakeOff();
            var actualResult = "Confiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestIfAirplaneIsOverbooked()
        {
            var airport = new Airport();
            var airplane = new LightAirplane();
            var trip = new Trip("Tuk", "Tam", airplane);

            var passengers = new Passenger[10];

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Gosho" + i);
                airplane.AddPassenger(passengers[i]);
            }

            airport.AddTrip(trip);

            var flightController = new FlightController(airport);

            var expectedResult = flightController.TakeOff();
            var actualResult = "TukTam2:\r\nOverbooked! Ejected Gosho1, Gosho0, Gosho3, Gosho7, Gosho8\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(trip.IsCompleted, true);
        }

        [Test]
        public void TestLoadCarryOnBaggage()
        {
            var airport = new Airport();

            var airplane = new LightAirplane();

            var passengers = new Passenger[10];

            //test if airplane is overbooked
            //Test load carry on baggage   
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Gosho" + i);
                airplane.AddPassenger(passengers[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    var bag = new Bag(passengers[i], new Item[] { new Colombian() });
                    passengers[i].Bags.Add(bag);
                }
                else
                {
                    var bag = new Bag(passengers[i], new Item[] { new Toothbrush() });
                    passengers[i].Bags.Add(bag);
                }
            }

            var trip = new Trip("Tuk", "Tam", airplane);
            airport.AddTrip(trip);

            var flightController = new FlightController(airport);

            var actualResult = flightController.TakeOff();
            var expectedResult = "TukTam3:\r\nOverbooked! Ejected Gosho1, Gosho0, Gosho3, Gosho7, Gosho8\r\nConfiscated 3 bags ($50006)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 3 (3 items) => $50006";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
