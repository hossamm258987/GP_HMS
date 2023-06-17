namespace Drug_Management_Service.Models.DTOs
{
    public class DrugListDTO
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public Drug Drug { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
    }
}
