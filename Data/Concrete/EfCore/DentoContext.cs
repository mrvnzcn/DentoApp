using Microsoft.EntityFrameworkCore;
using DentoApp.Entity;

namespace DentoApp.Data.Concrete.EfCore.Data
{
    public class DentoContext : DbContext
    {
        public DentoContext(DbContextOptions<DentoContext> options) : base(options)
        {
        }
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many relationship between Dentist and Patient
            modelBuilder.Entity<Dentist>()
                .HasMany(d => d.Patients)
                .WithMany(p => p.Dentists)
                .UsingEntity(j => j.ToTable("DentistPatient"));

            // One-to-many relationship between Dentist and Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Dentist)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DentistId);

            // One-to-many relationship between Patient and Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            // One-to-many relationship between Dentist and Treatment
            modelBuilder.Entity<Treatment>()
                .HasOne(t => t.Dentist)
                .WithMany(d => d.Treatments)
                .HasForeignKey(t => t.DentistId);

            // One-to-many relationship between Patient and Treatment
            modelBuilder.Entity<Treatment>()
                .HasOne(t => t.Patient)
                .WithMany(p => p.Treatments)
                .HasForeignKey(t => t.PatientId);

            // One-to-many relationship between Treatment and Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Treatment)
                .WithMany(t => t.Appointments)
                .HasForeignKey(a => a.TreatmentId);
        }


    }
}
