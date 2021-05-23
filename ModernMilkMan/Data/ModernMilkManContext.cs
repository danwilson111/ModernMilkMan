using Microsoft.EntityFrameworkCore;
using ModernMilkMan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Data
{
    public class ModernMilkManContext : DbContext
    {
        public ModernMilkManContext(DbContextOptions<ModernMilkManContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
