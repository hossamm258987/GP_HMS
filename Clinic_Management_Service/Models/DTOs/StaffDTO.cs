namespace Clinic_Management_Service.Models.DTOs
{
    public class StaffDTO
    {
        //Personal Info
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DoB { get; set; }
        public int Age
        {
            get
            {
                return (int)DateTime.Now.Year - (int)DoB.Year;
            }
        }
        public string NationalNumber { get; set; }
        public string SNN { get; set; }

        //Address Info
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        //Contact Info
        public string Phone { get; set; }
        public string Email { get; set; }

        //Ward Information
        public int WardId { get; set; }
        public WardDTO WardDto { get; set; }
        public int SectionId { get; set; }
        public SectionDTO SectionDto { get; set; }
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
