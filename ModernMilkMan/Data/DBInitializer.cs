using ModernMilkMan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Data
{
    public static class DBInitializer
    {
        public static void Initializer(ModernMilkManContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            var customer = new Customer[]
                {
                    new Customer{ Title = "Mr", ForeName ="Obi-Wan", SurName ="Kenobi", EmailAddress ="Kenobi@msn.com", MobileNumber = 000, IsActive = true},
                    new Customer{ Title = "Mr", ForeName ="Han", SurName ="Solo", EmailAddress ="Solo@gmail.com", MobileNumber = 000, IsActive = true},
                    new Customer{ Title = "Mr", ForeName ="Darth", SurName ="Vader", EmailAddress ="Vader@Hotmail.com", MobileNumber = 000, IsActive = false}
                };
            foreach (Customer c in customer)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var address = new Address[]
            {
                new Address{AddressLine1 = "Jedi Temple", AddressLine2 = "", Town = "Coruscant", County = "", PostCode = "co12 co12", Country = "", DateCreated = DateTime.Now, IsMainAddress = false, CustomerId = 1},
                new Address{AddressLine1 = "Flat 736", AddressLine2 = "Jedi Temple", Town = "Coruscant", County = "", PostCode = "co12 co12", Country = "", DateCreated = DateTime.Now, IsMainAddress = true, CustomerId = 1},
                new Address{AddressLine1 = "Sand Cave", AddressLine2 = "Desert", Town = "Tatooine", County = "", PostCode = "ta1 ta1", Country = "tatooine", DateCreated = DateTime.Now, IsMainAddress = false, CustomerId = 1},
                new Address{AddressLine1 = "millennium", AddressLine2 = "falcon", Town = "Space", County = "", PostCode = "sp01sp01", Country = "", DateCreated = DateTime.Now, IsMainAddress = true, CustomerId = 2},
                new Address{AddressLine1 = "Sand Hut", AddressLine2 = "", Town = "Desert", County = "Tatooine", PostCode = "ta12 ta12", Country = "Tatooine", DateCreated = DateTime.Now, IsMainAddress = false, CustomerId = 3},
                new Address{AddressLine1 = "Death", AddressLine2 = "Star", Town = "Space", County = "Space", PostCode = "Sp01 sp01", Country = "Space", DateCreated = DateTime.Now, IsMainAddress = false, CustomerId = 3},
                new Address{AddressLine1 = "Fortress Vader", AddressLine2 = "", Town = "Mustafar", County = "Mustafar", PostCode = "mu23 mu23", Country = "Mustafar", DateCreated = DateTime.Now, IsMainAddress = true, CustomerId = 3}
            };
            foreach (Address a in address)
            {
                context.Addresses.Add(a);
            }
            context.SaveChanges();
        }
    }
}
