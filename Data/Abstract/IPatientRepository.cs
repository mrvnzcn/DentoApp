using DentoApp.Entity;

namespace DentoApp.Data.Abstract
{
    public interface IPatientRepository
    {
        IQueryable<Patient> Patients { get; }
    }
}