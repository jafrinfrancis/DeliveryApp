using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetmvcapp.Models
{
    public class Order
    {

        [Key]
        public int OrderID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string OrderType { get; set; }
        public DateTime CreatedDate { get; set; }

        public Delivery DeliveryDetails { get; set; }
    }
}