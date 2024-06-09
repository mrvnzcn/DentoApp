namespace DentoApp.Data.Concrete.EfCore
{
    public class DentoContext : DbContext
    {
        public DentoContext(DbContextOptions<DentoContext> options) : base(options)
        {
            
        }
        public DbSet<Dentist> Dentists => Set<Dentist>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Treatment> Treatments => Set<Treatment>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
    }
}