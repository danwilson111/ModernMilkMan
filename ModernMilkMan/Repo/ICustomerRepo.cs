using ModernMilkMan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Repo
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Customer> GetAllCustomers(string isActive);
        void DeleteCustomer(Customer customer);

        Customer GetCustomer(int customerId);
        bool AlreadyExist(Customer customer);

        void UpdateCustomer(Customer customer);
        void AddCustomer(Customer customer);
        bool Save();

    }
}
