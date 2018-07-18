using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCValidator.Controllers;
using CCValidator.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTestCreditCardController
    {
        private ICreditCardService _creditCardService;
        public UnitTestCreditCardController()
        {
            _creditCardService = new CreditCardServiceTest();
        }
        [TestMethod]
        public void TestMethodGetAllCards_ShouldReturnAllCards()
        {
            var controller = new CreditCardController(_creditCardService);
            var result = controller.Get();

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestMethodGetCard_ShouldReturnCard()
        {
            var controller = new CreditCardController(_creditCardService);
            var result = controller.Get("44444444444");

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestMethodAddCard_ShouldAddCard()
        {
            CreditCardViewModel value = new CreditCardViewModel() { CardNumber = 55555555555, ExpiryDate = DateTime.UtcNow };

            var controller = new CreditCardController(_creditCardService);
            var result = ((System.Web.Http.Results.OkNegotiatedContentResult<int>)controller.Post(value));

            Assert.IsTrue(result.Content.Equals(1));
        }
    }
}
