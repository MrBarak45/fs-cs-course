using System;
using Microsoft.EntityFrameworkCore;

namespace FS_CSProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> Addresses { get; set; }
        public DbSet<EmployeeContactDetails> ContactDetails { get; set; }
        public DbSet<Employment> Employment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("AZURE_CONNECTIONSTRING"));
        }
    }
}
