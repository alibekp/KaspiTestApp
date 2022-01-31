using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaspiTestApp;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class CheckOperatorTest
    {
        [TestMethod]
        public void CheckActivOperator()
        {
            var payment = new Mock<Payment>().Object;
            payment.Account = "7017658992";

            string provider = Checkers.getProvider(payment.Account);

            string expected = "Activ";
            string actual = provider;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckBeelineOperator()
        {
            var payment = new Mock<Payment>().Object;
            payment.Account = "7777777777";
            //payment.Account = "7057777777";

            string provider = Checkers.getProvider(payment.Account);

            string expected = "Beeline";
            string actual = provider;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckTele2Operator()
        {
            var payment = new Mock<Payment>().Object;
            payment.Account = "7474209132";
            //payment.Account = "7074209132";

            string provider = Checkers.getProvider(payment.Account);

            string expected = "Tele2";
            string actual = provider;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckAltelOperator()
        {
            var payment = new Mock<Payment>().Object;
            payment.Account = "7004209132";
            //payment.Account = "7087087088";

            string provider = Checkers.getProvider(payment.Account);

            string expected = "Altel";
            string actual = provider;

            Assert.AreEqual(expected, actual);
        }

    }
}
