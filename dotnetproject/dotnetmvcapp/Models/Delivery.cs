using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetmvcapp.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }

        [Required]
        public string? userId { get; set; }

        [Required]
        public DateTime EstablishmentDate { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int DeliveryStatus { get; set; }

    }
}



 
    
