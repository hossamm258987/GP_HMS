using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment_Management_Service.Models
{
    public class Hospital
    {
        // Basic Info
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(60, ErrorMessage = "Name MaxLength 60 Characters.")]
        public string Name { get; set; }
        [MaxLength(450, ErrorMessage = "Description MaxLength 450 Characters.")]
        public string Description { get; set; }

        //Contact Info
        [Required]
        [MaxLength(13)]
        public string Phone { get; set; }
        [MaxLength(50, ErrorMessage = "Email Must be Less Than 50 Charachtar")]
        public string Email { get; set; }

        // Address Info
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        // Owner Info
        public string OwnerName { get; set; }
    }
}
