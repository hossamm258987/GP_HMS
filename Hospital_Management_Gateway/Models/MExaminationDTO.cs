namespace Hospital_Management_Gateway.Models
{
    public class MExaminationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public bool IsActive { get; set; }
    }
}
