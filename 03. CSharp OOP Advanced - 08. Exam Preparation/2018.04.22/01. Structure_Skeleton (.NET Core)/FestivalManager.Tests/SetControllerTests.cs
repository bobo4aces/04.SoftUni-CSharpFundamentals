// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void CanPerformShouldReturnTrue()
	    {
            IStage stage = new Stage();
            ISetController controller = new SetController(stage);
            ISet set = new Short("Set1");
            ISong song = new Song("Song1", new System.TimeSpan(0, 1, 2));
            IPerformer performer = new Performer("Pesho", 11);
            IInstrument instrument = new Microphone();
            performer.AddInstrument(instrument);
            set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddSet(set);

            string expectedResult = "1. Set1:\r\n-- 1. Song1 (01:02)\r\n-- Set Successful";
            string actualResult = controller.PerformSets();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CanPerformShouldReturnFalse()
        {
            IStage stage = new Stage();
            ISetController controller = new SetController(stage);
            ISet set = new Short("Set1");
            ISong song = new Song("Song1", new System.TimeSpan(0, 1, 2));
            IPerformer performer = new Performer("Pesho", 11);
            IInstrument instrument = new Microphone();
            performer.AddInstrument(instrument);
            //set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddSet(set);

            string expectedResult = "1. Set1:\r\n-- Did not perform";
            string actualResult = controller.PerformSets();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void WearDownShouldDecreaseWearValue()
        {
            IStage stage = new Stage();
            ISetController controller = new SetController(stage);
            ISet set = new Short("Set1");
            ISong song = new Song("Song1", new System.TimeSpan(0, 1, 2));
            IPerformer performer = new Performer("Pesho", 11);
            IInstrument instrument = new Microphone();
            performer.AddInstrument(instrument);
            set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddSet(set);

            double beforeResult = instrument.Wear;

            controller.PerformSets();
            
            double afterResult = instrument.Wear;

            Assert.AreNotEqual(beforeResult, afterResult);
        }
    }
}