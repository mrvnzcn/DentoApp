using DentoApp.Data.Abstract;
using DentoApp.Data.Concrete.EfCore;
using DentoApp.Data.Concrete.EfCore.Data;
using DentoApp.Entity;

namespace DentoApp.Data.Concrete
{
    public class EfPatientRepository : IPatientRepository
    {
        private DentoContext _context;
        public EfPatientRepository(DentoContext context)
        {
            _context = context;
        }

        public IQueryable<Patient> Patients => _context.Patients;

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges(); // Değişiklikleri kaydet
        }

        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges(); // Değişiklikleri kaydet
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients
                            .FirstOrDefault(p => p.Id == id);  // Hastanın ID'sine göre ilk eşleşeni döner
        }

        public void UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);  // Hastayı günceller
            _context.SaveChanges();
        }
    }
}