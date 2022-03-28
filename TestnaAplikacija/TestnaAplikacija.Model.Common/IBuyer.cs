using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestnaAplikacija.Model.Common
{
    public interface IBuyer
    {
        int BuyerId { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Oib { get; set; }
    }
}
