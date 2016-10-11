using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Rosita.Infrastructure.Database.Entities;
using Rosita.XCutting.Configuration;
using Rosita.XCutting.EntityFramework;

namespace Rosita.Infrastructure.Database.Contexts
{
    public class DataContext:DbContext
    {
        private readonly AppConfiguration _configuration;
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<InvoiceRecord> InvoiceRecords { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DataContext(AppConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.Databases.MainConnectionString);
        }

    }
}