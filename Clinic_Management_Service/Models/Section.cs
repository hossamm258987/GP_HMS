using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_Management_Service.Models
{
    public class Section
    {
        // Basic Info
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(60, ErrorMessage = "Name MaxLength 60 Characters.")]
        public string Name { get; set; }
        [MaxLength(450, ErrorMessage = "Description MaxLength 450 Characters.")]
        public string Description { get; set; }

        // Address Info
        public string Location { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public int TypeId { get; set; }
        public SectionType Type { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
