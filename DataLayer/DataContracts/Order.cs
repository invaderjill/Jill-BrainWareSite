using PetaPoco;

namespace DataLayer.DataContracts
{
    [TableName("order")]
    [PrimaryKey("order_id")]
    public class Order
    {
        [Column("order_id")]
        public int OrderId { get; set; }

        public string Description { get; set; }

        [Column("company_id")]
        public int CompanyId { get; set; }

        [ResultColumn]
        public Company Company { get; set; }

        [ResultColumn]
        public OrderProduct OrderProduct { get; set; }
    }
}
