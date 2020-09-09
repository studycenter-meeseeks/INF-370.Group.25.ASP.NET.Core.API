using _25.Core.System;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PsychologistCentre>()
                .HasKey(item => new { item.CentreId, item.PsychologistId });

            base.OnModelCreating(builder);
        }


        //User DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<EmployeePhysicalAddress> EmployeePhysicalAddresses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientPhysicalAddress> PatientPhysicalAddresses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<HomeLanguage> HomeLanguages { get; set; }
        public DbSet<LevelOfEducation> LevelOfEducations { get; set; }
        public DbSet<LegalGuardian> LegalGuardians { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<Psychologist> Psychologists { get; set; }
        public DbSet<PsychologistQualification> PsychologistQualifications { get; set; }
        public DbSet<PsychologistService> PsychologistServices { get; set; }
        public DbSet<PsychologistCentre> PsychologistCentres { get; set; }

        //System
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Core.System.System> Systems { get; set; }
        public DbSet<SubSystem> SubSystems { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public DbSet<Centre> Centres { get; set; }
        public DbSet<CentreAddress> CentreAddresses { get; set; }

        //Identity

    }
}