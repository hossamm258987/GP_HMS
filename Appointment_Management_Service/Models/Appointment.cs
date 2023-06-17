using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment_Management_Service.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(60, ErrorMessage = "Name MaxLength 60 Characters.")]
        public string Name { get; set; }
        [MaxLength(450, ErrorMessage = "Description MaxLength 450 Characters.")]
        public string Description { get; set; }
        public int Number { get; set; }
        public int DocMETimeId { get; set; }
        public DocMETime DocMETime { get; set; }
        public double Price { get; set; }
        public double Pay { get; set; }
        [NotMapped]
        public double NPrice
        {
            get
            {
                return Price - Pay;
            }
        }
        public bool Status { get; set; }
        public DateTime AppointTime { get; set; }
        public int patientId { get; set; }
        public Patient Patient { get; set; }
        public bool IsActive { get; set; }
    }
}
