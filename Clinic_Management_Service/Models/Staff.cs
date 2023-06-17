using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_Management_Service.Models
{
    public class Staff
    {
        //Personal Info
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
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
        [Required]
        [MaxLength(14, ErrorMessage = "National Number Must Less Than 14")]
        public string NationalNumber { get; set; }
        [MaxLength(14, ErrorMessage = "SNN Must Less Than 14")]
        public string SNN { get; set; }

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

        //Ward Information
        public int WardId { get; set; }
        public Ward Ward { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public DateTime HireDate { get; set; }

        //Salary Inforamtion
        public double Salary { get; set; }
        public double Factor { get; set; }
        public double InsuranceTax { get; set; }

        //Education Inforamtion
        public string Certificates { get; set; }
        public int YearsofExperience { get; set; }

        public bool IsActive { get; set; }
    }
}
