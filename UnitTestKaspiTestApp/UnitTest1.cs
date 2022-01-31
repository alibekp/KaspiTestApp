using KaspiTestApp;
using KaspiTestApp.Controllers;
using KaspiTestApp.Data;
using Moq;
using NUnit.Framework;

namespace UnitTestKaspiTestApp
{
    public class Tests
    {
            [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var dataContext = new Mock<DataContext>().Object;
            var payment = new Mock<Payment>().Object;
            payment.Account = "7777777777";
            payment.Amount = 500;

            PaymentController paymentController = new PaymentController(dataContext);
            paymentController.AddPayment(payment);


            Assert.Pass();
        }
    }
}