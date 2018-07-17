using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CCValidator.Models
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private CreditCardContext _context;
        public CreditCardRepository(CreditCardContext context)
        {
            _context = context;
        }
        public IEnumerable<CreditCard> CreditCards()
        {
            return _context.CreditCards.ToList();
        }
        public CreditCard GetCreditCardInfo(Nullable<decimal> ccNumber)
        {
            var ccNumberParam = ccNumber.HasValue ?
                 new SqlParameter("CardNumber", ccNumber) :
                 new SqlParameter("CardNumber", typeof(decimal));

            return _context.Database.SqlQuery<CreditCard>("GetCreditCardInfo @cardNumber", ccNumberParam).SingleOrDefault();
        }
        public int AddCreditCard(CreditCardViewModel cc)
        {
            _context.CreditCards.Add(new CreditCard() { CardNumber = cc.CardNumber, ExpiryDate = cc.ExpiryDate });

            return _context.SaveChanges();
        }
    }
}