using DentoApp.Data.Abstract;
using DentoApp.Entity;
using DentoApp.Services.Abstract;

namespace DentoApp.Services.Concrete
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IQueryable<Patient> GetPatients()
        {
            return _patientRepository.Patients;
        }

        public Patient GetPatientById(int id)
        {
            return _patientRepository.Patients.FirstOrDefault(t => t.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            // Eklemek için ilgili repository methodunu çağır
        }

        public void UpdatePatient(Patient patient)
        {
            // Güncellemek için ilgili repository methodunu çağır
        }

        public void DeletePatient(int id)
        {
            // Silmek için ilgili repository methodunu çağır
        }
    }
}