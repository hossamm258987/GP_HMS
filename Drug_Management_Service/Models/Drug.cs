using System.ComponentModel.DataAnnotations;

namespace Drug_Management_Service.Models
{
    public class Drug
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public double BuingPrice { get; set; }
        public double SellingPrice { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int TypeId { get; set; }
        public DrugType DrugType { get; set; }

        public int PharmacyId { get; set; }
        public Section Pharmacy { get; set; }

        public bool IsActive { get; set; }
    }
}
