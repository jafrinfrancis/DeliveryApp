using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetmvcapp.Models
{
    public class Delivery : BaseEntity
    {
        public int userId { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public int OrderId { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
    }

    public enum DeliveryStatus
    {

        Pending = 1,
        OutDelivery = 2,
        InTransit = 3,
        DoorLock = 4,
        Delivered = 5,
        UnAssigned = 6
    }
}



 
    
