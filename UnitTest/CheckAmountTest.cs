using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaspiTestApp;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class CheckAmountTest
    {
        [TestMethod]
        public void CheckAmount()
        {
            var payment = new Mock<Payment>().Object;
            payment.Amount = 500;

            int expected = 0;
            int actual = Checkers.makePaymentCheck(payment);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegativeTestLessThanZero()
        {
            var payment = new Mock<Payment>().Object;
            payment.Amount = -5;

            int expected = 109;
            int actual = Checkers.makePaymentCheck(payment);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegativeTestMoreThanLimit()
        {
            var payment = new Mock<Payment>().Object;
            payment.Amount = 600000;

            int expected = 110;
            int actual = Checkers.makePaymentCheck(payment);

            Assert.AreEqual(expected, actual);
        }

    }
}
