using ModernMilkMan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Repo
{
    public interface IAddressRepo
    {
        Address GetAddress(int addressId, int customerId);
        void AddAddress(int customerId, Address address);
        bool HasMainAddress(int customerId);
        void DeleteAddress(Address address);
        void UpdateAddress(Address address);

        bool MoreThanOneAddress(int addressId, int customerId);

        bool Save();
    }
}
