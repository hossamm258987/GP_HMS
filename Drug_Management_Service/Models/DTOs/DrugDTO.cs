namespace Drug_Management_Service.Models.DTOs
{
    public class DrugDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double BuingPrice { get; set; }
        public double SellingPrice { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TypeId { get; set; }
        public DrugType DrugType { get; set; }
        public int PharmacyId { get; set; }
        public Section Pharmacy { get; set; }
        public bool IsActive { get; set; }
    }
}
