﻿using System.ComponentModel.DataAnnotations;

namespace Drug_Management_Service.Models
{
    public class DrugType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Name Must be Less Than 60 Charachtar")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Name Must be Less Than 250 Charachtar")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
