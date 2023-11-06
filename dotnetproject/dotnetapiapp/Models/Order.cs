using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapiapp.Models
{
    public class Order : BaseEntity
    {

        public string CustomerName { get; set; }

        public string ContactNumber { get; set; }

        public string Location { get; set; }

        public Decimal Amount { get; set; }

        public string OrderType { get; set; }
        public Delivery Delivery { get; set; }
    }
}