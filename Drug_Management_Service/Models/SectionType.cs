using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drug_Management_Service.Models
{
    public class SectionType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(60, ErrorMessage = "Name MaxLength 60 Characters.")]
        public string Name { get; set; }
        [MaxLength(450, ErrorMessage = "Description MaxLength 450 Characters.")]
        public string Description { get; set; }
        public int WardId { get; set; }
        public Ward Ward { get; set; }
        public bool IsActive { get; set; }
    }
}
