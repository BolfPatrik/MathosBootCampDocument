using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestnaAplikacija.Model.Common
{
    public interface ICar
    {
        int CarId { get; set; }
        string Name { get; set; }
        string Manufacturer { get; set; }
    }
}
