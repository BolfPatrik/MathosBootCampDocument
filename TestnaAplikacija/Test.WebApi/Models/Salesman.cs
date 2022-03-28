using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.WebApi.Models
{
    public class Salesman
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; }
        public string Oib { get; set; }
        public int Salary { get; set; }
    }
}