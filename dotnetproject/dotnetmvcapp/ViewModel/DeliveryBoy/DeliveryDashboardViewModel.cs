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
        public string OrderedDate { get; set; }
        public string DeliveryStatus { get; set; }
        public string CustomerName { get; set; }

        public string ContactNumber { get; set; }

        public string Location { get; set; }

        public Decimal Amount { get; set; }

        public string OrderType { get; set; }
    }
}
