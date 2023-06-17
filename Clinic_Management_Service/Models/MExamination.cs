﻿using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_Service.Models
{
    public class MExamination
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(60, ErrorMessage = "Name MaxLength 60 Characters.")]
        public string Name { get; set; }
        [MaxLength(450, ErrorMessage = "Description MaxLength 450 Characters.")]
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public bool IsActive { get; set; }
    }
}
