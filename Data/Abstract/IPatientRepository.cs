using DentoApp.Entity;

namespace DentoApp.Data.Abstract
{
    public interface IPatientRepository
    {
        IQueryable<Patient> Patients { get; }
        void Add(Patient patient);
        void Delete(Patient patient);
        Patient GetPatientById(int id); 
        void UpdatePatient(Patient patient);
    }
}