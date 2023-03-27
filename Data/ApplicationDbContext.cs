using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using System.Collections.Generic;

namespace RestAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
