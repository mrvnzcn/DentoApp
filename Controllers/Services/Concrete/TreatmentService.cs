using DentoApp.Data.Abstract;
using DentoApp.Entity;
using DentoApp.Services.Abstract;
using Microsoft.EntityFrameworkCore;

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
            return _treatmentRepository.Treatments
                    .Include(t => t.Patient)
                    .Include(t => t.Dentist);
        }

        public Treatment GetTreatmentById(int id)
        {
            var treatment = _treatmentRepository.Treatments
            .Include(t => t.Dentist)
            .Include(t => t.Patient)
            .FirstOrDefault(t => t.Id == id) ?? throw new KeyNotFoundException($"Treatment with ID {id} was not found.");
            return treatment;
        }   

        public void AddTreatment(Treatment treatment)
        {
            _treatmentRepository.Add(treatment);
        }

        public void UpdateTreatment(Treatment treatment)
        {
            _treatmentRepository.Update(treatment);
        }

        public bool DeleteTreatment(int id)
        {
            var treatment = _treatmentRepository.GetTreatmentById(id);
            if(treatment == null)
            {
                return false;
            }

            _treatmentRepository.Delete(treatment);
            return true;
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