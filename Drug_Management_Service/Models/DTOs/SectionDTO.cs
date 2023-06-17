﻿namespace Drug_Management_Service.Models.DTOs
{
    public class SectionDTO
    {
        // Basic Info
        public int Id { get; set; }
        public string Name { get; set; }
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
