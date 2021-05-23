using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The Title value cannot exceed 20 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The ForeName value cannot exceed 50 characters.")]
        public string ForeName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The SurName value cannot exceed 50 characters.")]
        public string SurName { get; set; }

        [Required]       
        [StringLength(75, ErrorMessage = "The EmailAddress value cannot exceed 75 characters.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Range(1,15, ErrorMessage = "The Mobile Number value cannot exceed 15 characters or subceed 1 characters")]
        public int MobileNumber { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
