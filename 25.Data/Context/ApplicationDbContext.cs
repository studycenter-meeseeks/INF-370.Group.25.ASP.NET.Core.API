using _25.Core.User;
using _25.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _25.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Caleni-Practice-Db;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        //User DbSets

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<PhysicalAddress> PhysicalAddresses { get; set; }
    }
}