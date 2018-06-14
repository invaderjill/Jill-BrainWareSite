using PetaPoco;

namespace DataLayer.DataContracts
{
    [TableName("orderproduct")]
    [PrimaryKey("order_id,product_id")]
    public class OrderProduct
    {
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set;}

        [Column("price")]
        public decimal OrderPrice { get; set; }

        public int Quantity { get; set; }

        [ResultColumn]
        public Product Product { get; set; }
    }
}
