using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_Service.Models
{
    public class DocMExamination
    {
        [Key]
        public int Id { get; set; }
        public int MExaminationId { get; set; }
        public MExamination MExamination { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public bool IsActive { get; set; }
    }
}
