using Customer.Profile.Store.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System;

namespace Customer.Profile.Store
{
    public class CustomerProfileContext : DbContext
    {

        public CustomerProfileContext(DbContextOptions<CustomerProfileContext> options) : base(options)
        {

        }

        public DbSet<CustomerProfile> CustomerProfile { get; set; }

    }
}
