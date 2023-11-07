using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetmvcapp.Models
{
    public class Order : BaseEntity
    {
      [Key]
      public int OrderID{get;set;}

        public string CustomerName { get; set; }

        public string ContactNumber { get; set; }

        public string Location { get; set; }

        public Decimal Amount { get; set; }

        public OrderType OrderType { get; set; }
        public Delivery Delivery { get; set; }
        public DateTime EstablishmentDate{get;set;}
    }

    
public enum OrderType
{
    Online,
    Direct,
    ThirdParty,
    Pending,
    LongTimeOrder
}
}