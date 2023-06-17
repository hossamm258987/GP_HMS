namespace Hospital_Management_Gateway.Models
{
    public class NurseDTO : StaffDTO
    {
        public int SectionId { get; set; }
        public SectionDTO SectionDto { get; set; }
    }
}
