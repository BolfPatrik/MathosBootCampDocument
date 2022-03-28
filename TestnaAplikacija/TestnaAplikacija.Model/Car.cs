using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestnaAplikacija.Model.Common;

namespace TestnaAplikacija.Model
{
    public class Car : ICar
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
    }
}
