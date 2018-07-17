using System;
using System.Collections.Generic;

namespace CCValidator.Models
{
    public interface ICreditCardRepository
    {
        IEnumerable<CreditCard> CreditCards();
        CreditCard GetCreditCardInfo(Nullable<decimal> ccNumber);
        int AddCreditCard(CreditCardViewModel cc);
    }
}