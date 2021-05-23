using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Model
{
    public class AddressForCreationDTO
    {


        [Required]
        [StringLength(80, ErrorMessage = "The AddressLine1 value cannot exceed 80 characters.")]
        public string AddressLine1 { get; set; }

        [StringLength(80, ErrorMessage = "The AddressLine2 value cannot exceed 80 characters.")]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Town value cannot exceed 50 characters.")]
        public string Town { get; set; }

        [StringLength(50, ErrorMessage = "The County value cannot exceed 50 characters.")]
        public string County { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The Post Code value cannot exceed 10 characters.")]
        public string PostCode { get; set; }
        public string Country { get; set; }
        public DateTime DateCreated { get; set; }
        [DefaultValue(false)]
        public bool IsMainAddress { get; set; }

        public int CustomerId { get; set; }
    }
}
