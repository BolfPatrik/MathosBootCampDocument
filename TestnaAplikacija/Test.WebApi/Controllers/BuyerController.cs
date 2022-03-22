using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.WebApi.Models;

namespace Test.WebApi.Controllers
{
    public class BuyerController : ApiController
    {
        static IList<Buyer> buyers = new List<Buyer>()
        {
            new Buyer()
            {
                Id = 1, Name="John", Surname ="Doe", Oib ="57131771368"
            },
            new Buyer()
            {
                Id = 2, Name="Joe", Surname ="Dawn", Oib ="13705894329"
            },
            new Buyer()
            {
                Id = 3, Name="Jack", Surname ="Dog", Oib ="47813680773"
            },
            new Buyer()
            {
                Id = 4, Name="Jill", Surname ="Valentine", Oib ="70737730427"
            },
            new Buyer()
            {
                Id = 5, Name="Johnny", Surname ="Fastfinger", Oib ="80058829494"
            },
        };
        [HttpGet]
        [Route("api/buyers")]
        public HttpResponseMessage GetAllBuyers()
        {
            IList<Buyer> buyersPresent = new List<Buyer>();
            foreach (Buyer buyer in buyers)
            {
                buyersPresent.Add(buyer);
            }
            return Request.CreateResponse(HttpStatusCode.OK, buyers);
        }
        [HttpGet]
        [Route("api/buyers/getspecific")]
        public HttpResponseMessage GetABuyer(int id)
        {
            var buyer = buyers.FirstOrDefault(b => b.Id == id);
            if (buyer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Buyer not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, buyer);
        }
        [HttpPost]
        [Route("api/buyers/post")]
        public HttpResponseMessage PostNewBuyer(Buyer buyer)
        {

            buyers.Add(new Buyer()
            {
                Id = buyer.Id,
                Name = buyer.Name,
                Surname = buyer.Surname,
                Oib = buyer.Oib
            });
            if (buyer == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad request");
            }
            return Request.CreateResponse(HttpStatusCode.OK, buyer);
        }
        [HttpPut]
        [Route("api/buyers/put")]
        public HttpResponseMessage Put(Buyer buyer)
        {
            var existingBuyer = buyers.Where(b => b.Id == buyer.Id).FirstOrDefault<Buyer>();
            if (existingBuyer != null)
            {
                existingBuyer.Name = buyer.Name;
                existingBuyer.Surname = buyer.Surname;
                existingBuyer.Oib = buyer.Oib;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad request");
            }
            return Request.CreateResponse(HttpStatusCode.OK, buyer);
        }
        [HttpDelete]
        [Route("api/buyers/delete")]
        public HttpResponseMessage Delete(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad request");
            }
            else
            {
                buyers.RemoveAt(id);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}