using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapiapp.Models
{
    public class DashbordModel
    {
        public int Pending { get; set; }
        public int OutDelivery { get; set; }
        public int InTransit { get; set; }
        public int DoorLock { get; set; }
        public int Delivered { get; set; }
        public int UnAssigned { get; set; }
    }

    public class DeliveryStatusCount
    {
        public DeliveryStatus DeliveryStatus { get; set; }
        public int Count { get; set; }
    }

    public enum DeliveryStatus
    {
        
        Pending=1,
        OutDelivery=2,
        InTransit=3,
        DoorLock=4,
        Delivered=5,
        UnAssigned=6
    }
}