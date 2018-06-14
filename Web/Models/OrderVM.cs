using System.Collections.Generic;

namespace Web.Models
{
    //should be refactored to include unit test and interface
    public class OrderVM
    {
        public int OrderId { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }

        public List<OrderProductVM> OrderProducts { get; set; }

    }
}