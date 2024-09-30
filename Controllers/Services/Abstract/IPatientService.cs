using DentoApp.Entity;

namespace DentoApp.Services.Abstract
{
    public interface IPatientService
    {
        IQueryable<Patient> GetPatients();
        Patient GetPatientById(int id);
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        bool DeletePatient(int id);
    }
}
