using DentoApp.Entity;

namespace DentoApp.Services.Abstract
{
    public interface IDentistService
    {
        IQueryable<Dentist> GetDentists();
        Dentist GetDentistById(int id);
        void AddDentist(Dentist dentist);
        void UpdateDentist(Dentist dentist);
        bool DeleteDentist(int id);
    }
}
