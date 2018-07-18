using CCValidator.Models;
using CreditCardValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    class CreditCardServiceTest : ICreditCardService
    {
        private readonly List<CreditCard> _creditCards;
        public CreditCardServiceTest()
        {
            _creditCards = new List<CreditCard>()
            {
                new CreditCard() { CardNumber = 12121221212, ExpiryDate = DateTime.UtcNow, Id = 1 },
                new CreditCard() { CardNumber = 33333333333, ExpiryDate = DateTime.UtcNow, Id = 2 },
                new CreditCard() { CardNumber = 44444444444, ExpiryDate = DateTime.UtcNow, Id = 3 }
            };
        }
        public int AddCreditCard(CreditCardViewModel cc)
        {
            return 1;
        }

        public List<CreditCard> GetAllCards()
        {
            return _creditCards;
        }

        public CreditCardValidity GetCreditCardInfo(string ccNumber)
        {
            var card = _creditCards.Find(c => c.CardNumber.Equals(decimal.Parse(ccNumber)));

            CreditCardDetector detector = new CreditCardDetector(ccNumber);

            var cardValidity = new CreditCardValidity() { BrandName = detector.BrandName, CardNumber = decimal.Parse(detector.CardNumber), IsValid = detector.IsValid() };

            if (!cardValidity.IsValid) cardValidity.Error = "Unknown card and/or not valid card! ";

            if (card == null) cardValidity.Error += "Card doesn't exist on the database!";

            return cardValidity;
        }
    }
}
