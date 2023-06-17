namespace Hospital_Management_Service.Models.DTOs
{
    public class NurseDTO : StaffDTO
    {
        public int SectionId { get; set; }
        public SectionDTO SectionDto { get; set; }
    }
}
