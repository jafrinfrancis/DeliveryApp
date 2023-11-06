namespace dotnetmvcapp.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Role UserRole { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public enum Role
    {
        Admin,
        DeliveryBoy
    }
}
