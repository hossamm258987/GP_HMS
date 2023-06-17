using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment_Management_Service.Models
{
    public class Patient
    {
        //Personal Info
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60, ErrorMessage = "Name MaxLength 60 Characters.")]
        public string Name { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        [NotMapped]
        public int Age
        {
            get
            {
                return (int)DateTime.Now.Year - (int)DoB.Year;
            }
        }
        [MaxLength(14, ErrorMessage = "National Number Must Less Than 14")]
        public string NationalNumber { get; set; }

        //Address Info
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        //Contact Info
        [Required]
        [MaxLength(13)]
        public string Phone { get; set; }
        [MaxLength(50, ErrorMessage = "Email Must be Less Than 50 Charachtar")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
