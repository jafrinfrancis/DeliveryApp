using dotnetmvcapp.Models;

namespace dotnetmvcapp.ViewModels
{
    public class DeliveryDashboardViewModel
    {
        public int PendingOrders { get; set; }
        public int OutForDelivery { get; set; }
        public int InTransit { get; set; }
        public int DoorLocked { get; set; }
        public int Delivered { get; set; }
        public List<DeliveryDetails> details { get; set; }

    }
    public class DeliveryDetails
    {
        public int DeliveryId { get; set; }
        public int OrderId { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public string? DeliveryStatusString { get; set; }
        public string? CustomerName { get; set; }

        public string? ContactNumber { get; set; }

        public string? Location { get; set; }

        public Decimal Amount { get; set; }

        public OrderType OrderType { get; set; }
        public DateTime EstablishmentDate { get; set; }
    }
}
