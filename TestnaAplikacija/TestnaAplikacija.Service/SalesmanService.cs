using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestnaAplikacija.Model;
using TestnaAplikacija.Repository;

namespace TestnaAplikacija.Service
{
    public class SalesmanService
    {
        public List<Salesman> GetSalesmen()
        {
            SalesmanRepository salesmanRep = new SalesmanRepository();

            return salesmanRep.GetAllSalesman();
        }


        public Salesman PostSalesman(Salesman salesman)
        {
            SalesmanRepository salesmanRep = new SalesmanRepository();

            return salesmanRep.PostSalesman(salesman);
        }


        public Salesman PutSalesmanById(Salesman salesman)
        {
            SalesmanRepository salesmanRep = new SalesmanRepository();

            return salesmanRep.PutSalesman(salesman);
        }


        public Salesman DeleteSalesmanById(int id)
        {
            SalesmanRepository salesmanRep = new SalesmanRepository();

            return salesmanRep.DeleteSalesmanById(id);
        }
    }
}

