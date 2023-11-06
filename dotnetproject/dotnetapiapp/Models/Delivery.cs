using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapiapp.Models
{
    public class Delivery : BaseEntity
    {
        public int userId { get; set; }
        [Required]
        public DateTime EstablishmentDate { get; set; }
        public int OrderId { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
    }
}