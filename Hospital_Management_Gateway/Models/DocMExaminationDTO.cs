namespace Hospital_Management_Gateway.Models
{
    public class DocMExaminationDTO
    {
        public int Id { get; set; }
        public int MExaminationId { get; set; }
        public MExaminationDTO MExaminationDto { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO DoctorDto { get; set; }
        public bool IsActive { get; set; }
    }
}
