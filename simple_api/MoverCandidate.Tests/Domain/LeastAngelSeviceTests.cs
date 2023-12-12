
using MoverCandidate.Domain.WatchHands;

namespace MoverCandidate.Tests.Domain
{

    [TestClass]
    public class LeastAngelSeviceTests
    {
        [TestMethod]
        public void LeastHourMinute()
        {
            var hourMinuteAngelTime = new DateTime(2000, 1, 1, 3, 10, 0);

            var service = new LeastAngelService();
            var minAngel = service.FindLeastAngel(hourMinuteAngelTime);

            Assert.AreEqual(30, minAngel);
        }

        [TestMethod]
        public void LeastMinuteSecods()
        {
            var hourMinuteAngelTime = new DateTime(2000, 1, 1, 3, 1, 0);

            var service = new LeastAngelService();
            var minAngel = service.FindLeastAngel(hourMinuteAngelTime);

            Assert.AreEqual(6, minAngel);
        }

        [TestMethod]
        public void Hours24Format_MinuteSecond()
        {
            var hourMinuteAngelTime = new DateTime(2000, 1, 1, 15, 5, 0);

            var service = new LeastAngelService();
            var minAngel = service.FindLeastAngel(hourMinuteAngelTime);

            Assert.AreEqual(30, minAngel);
        }


        [TestMethod]
        public void Hours24Format_HourMinute()
        {
            var hourMinuteAngelTime = new DateTime(2000, 1, 1, 15, 10, 0);

            var service = new LeastAngelService();
            var minAngel = service.FindLeastAngel(hourMinuteAngelTime);

            Assert.AreEqual(30, minAngel);
        }
    }
}
