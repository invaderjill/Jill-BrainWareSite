using PetaPoco;

namespace DataLayer.DataContracts
{
    [TableName("company")]
    [PrimaryKey("company_id")]
    public class Company
    {
        [Column("company_id")]
        public int CompanyId { get; set; }

        public string Name { get; set; }
    }
}
