namespace Hospital_Management_Service.Models.DTOs
{
    public class PharmatistDTO : StaffDTO
    {
        public int SectionId { get; set; }
        public SectionDTO SectionDto { get; set; }
    }
}
