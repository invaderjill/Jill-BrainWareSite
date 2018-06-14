using PetaPoco;

namespace DataLayer.DataContracts
{
    [TableName("product")]
    [PrimaryKey("product_id")]
    public class Product
    {
        [Column("product_id")]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
