using Microsoft.EntityFrameworkCore;
using ModernMilkMan.Data;
using ModernMilkMan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Repo
{
    public class AddressRepo : IAddressRepo
    {
        private readonly ModernMilkManContext _context;
        private readonly ICustomerRepo _customerRepo;

        public AddressRepo(ModernMilkManContext context, ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
            _context = context;
        }
        public void AddAddress(int customerId, Address address)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            customer.Addresses.Add(address);
        }

        public void DeleteAddress(Address address)
        {
            _context.Addresses.Remove(address);
        }

        public Address GetAddress(int addressId, int customerId)
        {
            return _context.Addresses.Where(c => c.CustomerId == customerId && c.AddressId == addressId).FirstOrDefault();
        }

        public bool HasMainAddress(int customerId)
        {
            var currentcustomer = _customerRepo.GetCustomer(customerId);
            var hasmainaddress = currentcustomer.Addresses.Where(a => a.IsMainAddress == true);

            if (hasmainaddress.Any())
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool MoreThanOneAddress(int customerId, int addressId)
        {

            var customer = _context.Customers.Include(c => c.Addresses).Where(c => c.CustomerId == customerId).FirstOrDefault();


                if (customer.Addresses.Count() >= 2)
            {
                return true;
            }
            return false;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAddress(Address address)
        {
            //no code needed
        }
    }
}
