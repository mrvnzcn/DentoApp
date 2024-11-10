using DentoApp.Data.Abstract;
using DentoApp.Entity;
using DentoApp.Services.Abstract;

namespace DentoApp.Services.Concrete
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IDentistRepository _dentistRepository;
        private readonly IPatientRepository _patientRepository;
        public TreatmentService(ITreatmentRepository treatmentRepository, IDentistRepository dentistRepository, IPatientRepository patientRepository)
        {
            _treatmentRepository = treatmentRepository;
            _dentistRepository = dentistRepository;
            _patientRepository = patientRepository;
        }

        public IQueryable<Treatment> GetTreatments()
        {
            return _treatmentRepository.Treatments;
        }

        public Treatment GetTreatmentById(int id)
        {
            return _treatmentRepository.Treatments.FirstOrDefault(t => t.Id == id);
        }

        public void AddTreatment(Treatment treatment)
        {
            _treatmentRepository.Add(treatment);
        }

        public void UpdateTreatment(Treatment treatment)
        {
            // Güncellemek için ilgili repository methodunu çağır
        }

        public void DeleteTreatment(int id)
        {
            // Silmek için ilgili repository methodunu çağır
        }
        public IQueryable<Patient> GetPatients() // Yeni metot
        {
            return _patientRepository.Patients;
        }

        public IQueryable<Dentist> GetDentists() // Yeni metot
        {
            return _dentistRepository.Dentists;
        }
    }
}