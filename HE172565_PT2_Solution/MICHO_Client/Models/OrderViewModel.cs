namespace MICHO_Client.Models
{
    public class OrderViewModel
    {
        public int CustomerId { get; set; }
        public int EmpId { get; set; }
        public List<OrderItemModel> Items { get; set; } = new();
    }
}
