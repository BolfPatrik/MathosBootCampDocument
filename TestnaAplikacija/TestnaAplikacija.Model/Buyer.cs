using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestnaAplikacija.Model.Common;

namespace TestnaAplikacija.Model
{
   public class Buyer : IBuyer
    {
        public int BuyerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Oib { get ; set; }
    }
}
