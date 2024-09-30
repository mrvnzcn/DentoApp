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
            return _patientRepository.GetPatientById(id);
        }

        public void AddPatient(Patient patient)
        {
            _patientRepository.Add(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            _patientRepository.UpdatePatient(patient);  // Repository katmanında güncelleme işlemi yapılır
        }

        public bool DeletePatient(int id)
        {
            var patient = _patientRepository.GetPatientById(id);
            if(patient == null)
            {
                return false;
            }

            _patientRepository.Delete(patient);
            return true;
        }
    }
}