using CCValidator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace CCValidator.Controllers
{
    [RoutePrefix("v1/creditcard")]
    public class CreditCardController : ApiController
    {
        private ICreditCardService _creditCardService;
        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet, Route(""), ResponseType(typeof(List<string>))]
        public IHttpActionResult Get()
        {
            var creditCards = _creditCardService.GetAllCards().Select(c => c.CardNumber).ToList();

            return Ok(creditCards);
        }

        [HttpGet, Route("{id}"), ResponseType(typeof(CreditCardViewModel))]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();

            return Ok(_creditCardService.GetCreditCardInfo(id));
        }

        [HttpPost, Route(""), ResponseType(typeof(int))]
        public IHttpActionResult Post([FromUri] CreditCardViewModel value)
        {
            return Ok(_creditCardService.AddCreditCard(value));
        }
    }
}