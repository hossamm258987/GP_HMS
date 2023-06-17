namespace Clinic_Management_Service.Models.DTOs
{
    public class DocMETimeDTO
    {
        public int Id { get; set; }
        public int DocMExaminationId { get; set; }
        public DocMExaminationDTO DocMExaminationDto { get; set; }
        public string Day { get; set; }
        public DateTime STime { get; set; }
        public DateTime ETime { get; set; }
    }
}
