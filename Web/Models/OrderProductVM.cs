
namespace Web.Models
{
    //should be refactored to include unit test and interface
    public class OrderProductVM
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal OrderPrice { get; set; }

        public string ProductName { get; set; }
    }
}