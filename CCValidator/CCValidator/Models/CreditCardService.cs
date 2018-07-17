using CreditCardValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCValidator.Models
{
    public class CreditCardService : ICreditCardService
    {
        private ICreditCardRepository _creditCardRepository;
        public CreditCardService(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public int AddCreditCard(CreditCardViewModel cc)
        {
            return _creditCardRepository.AddCreditCard(cc);
        }

        public List<CreditCard> GetAllCards()
        {
            return _creditCardRepository.CreditCards().ToList();
        }
        public CreditCardValidity GetCreditCardInfo(string ccNumber)
        {
            CreditCardDetector detector = new CreditCardDetector(ccNumber);
                       
            CreditCardValidity validity = new CreditCardValidity() { CardNumber = decimal.Parse(detector.CardNumber), BrandName = detector.BrandName, IsValid = detector.IsValid() };

            if (!validity.IsValid) validity.Error = "Unknown card and/or not valid card! ";

            var ccInfo = _creditCardRepository.GetCreditCardInfo(decimal.Parse(ccNumber));

            if (ccInfo == null) validity.Error += "Card doesn't exist on the database!";

            return validity;
        }
    }
}