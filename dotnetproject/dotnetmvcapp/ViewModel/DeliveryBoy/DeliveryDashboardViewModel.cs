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
    }
}
