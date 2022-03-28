using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestnaAplikacija.Model;
using TestnaAplikacija.Repository;
using TestnaAplikacija.Service.Common;

namespace TestnaAplikacija.Service
{
    public class BuyerService : IBuyerService
    {
        public List<Buyer> GetAllBuyers()
        {
            BuyerRepository buyerRep = new BuyerRepository();

            return buyerRep.GetAllBuyers();
        }


        public Buyer PostBuyer(Buyer buyer)
        {
            BuyerRepository buyerRep = new BuyerRepository();

            return buyerRep.PostBuyer(buyer);
        }


        public Buyer PutBuyerById(Buyer buyer)
        {
            BuyerRepository buyerRep = new BuyerRepository();

            return buyerRep.PutBuyer(buyer);
        }


        public Buyer DeleteBuyerById(int id)
        {
            BuyerRepository buyerRep = new BuyerRepository();

            return buyerRep.DeleteBuyerById(id);
        }
    }
}
