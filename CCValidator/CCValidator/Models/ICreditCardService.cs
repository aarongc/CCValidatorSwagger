using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCValidator.Models
{
    public interface ICreditCardService
    {
        List<CreditCard> GetAllCards();
        CreditCardValidity GetCreditCardInfo(string ccNumber);
        int AddCreditCard(CreditCardViewModel cc);
    }
}