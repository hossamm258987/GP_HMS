namespace Drug_Management_Service.Models.DTOs
{
    public class HospitalDTO
    {
        // Basic Info
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Contact Info
        public string Phone { get; set; }
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
