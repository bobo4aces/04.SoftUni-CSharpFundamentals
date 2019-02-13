namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void Test()
        {
            IVehicle vehicle = new Revenger("Model", 5, 5, 5, 5, 5, new VehicleAssembler());
            IPart arsenalPart = new ArsenalPart("Part", 6, 6, 6);
            double weightBefore = vehicle.TotalAttack;
            vehicle.AddArsenalPart(arsenalPart);
            double weightAfter = vehicle.TotalAttack;
            Assert.AreNotEqual(weightBefore, weightAfter);
        }

        [Test]
        public void Test1()
        {
            IVehicle vehicle = new Revenger("Model", 5, 5, 5, 5, 5, new VehicleAssembler());
            string expectedResult = "Revenger - Model\r\nTotal Weight: 5.000\r\nTotal Price: 5.000\r\nAttack: 5\r\nDefense: 5\r\nHitPoints: 5\r\nParts: None";
            string actualResult = vehicle.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}