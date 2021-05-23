using Microsoft.EntityFrameworkCore;
using ModernMilkMan.Data;
using ModernMilkMan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Repo
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ModernMilkManContext _context;

        public CustomerRepo(ModernMilkManContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public bool AlreadyExist(Customer customer)
        {
            bool customerAlreadyExists = _context.Customers.Any(i => i.EmailAddress == customer.EmailAddress);
            return customerAlreadyExists;
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.Include(c => c.Addresses).Where (c=>c.CustomerId == customerId).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCustomer(Customer customer)
        {
            // no code needed
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.Include(c => c.Addresses).ToList();
        }

        public IEnumerable<Customer> GetAllCustomers(string isActive)
        {
            if (isActive != "true")
            {
                return GetAllCustomers();
            }
            return _context.Customers.Where(c => c.IsActive == true).ToList();
        }

    }
}
