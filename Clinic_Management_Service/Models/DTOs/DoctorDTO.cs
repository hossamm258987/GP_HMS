namespace Clinic_Management_Service.Models.DTOs
{
    public class DoctorDTO : StaffDTO
    {
        public int SpecializationId { get; set; }
        public SpecializationDTO SpecializationDto { get; set; }
    }
}
