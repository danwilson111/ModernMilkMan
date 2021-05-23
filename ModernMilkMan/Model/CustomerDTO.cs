using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Model
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string ForeName { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }
        public int MobileNumber { get; set; }
        public bool IsActive { get; set; }

        public ICollection<AddressDTO> Addresses { get; set; } = new List<AddressDTO>();

    }
}
