
namespace Web.Models
{
    //should be refactored to include unit test and interface
    //this is not currently being used, but is a placeholder model for a future products page for example
    public class ProductVM
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}