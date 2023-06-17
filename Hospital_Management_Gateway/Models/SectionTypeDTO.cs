namespace Hospital_Management_Gateway.Models
{
    public class SectionTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WardId { get; set; }
        public WardDTO WardDto { get; set; }
        public bool IsActive { get; set; }
    }
}
