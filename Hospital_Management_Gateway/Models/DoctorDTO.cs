namespace Hospital_Management_Gateway.Models
{
    public class DoctorDTO : StaffDTO
    {
        public int SpecializationId { get; set; }
        public SpecializationDTO SpecializationDto { get; set; }
        public int SectionId { get; set; }
        public SectionDTO SectionDto { get; set; }
    }
}
