namespace AJAXWithJQuery.Models
{
    public class OrderViewModel
    {
        public int UnitPrice { get; set; }
        public int  Quantity { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get { return DateTime.Now; } }
    }
}
