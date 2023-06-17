using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment_Management_Service.Models
{
    public class DocMETime
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int DocMExaminationId { get; set; }
        public DocMExamination DocMExamination { get; set; }
        [NotMapped]
        public string Day { get; set; }
        public DateTime STime { get; set; }
        public DateTime ETime { get; set; }
    }
}
