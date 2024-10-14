using DentoApp.Entity;

namespace DentoApp.Data.Abstract
{
    public interface IDentistRepository
    {
        IQueryable<Dentist> Dentists { get; }
        void Add(Dentist dentist);
        void Delete(Dentist dentist);
        Dentist GetDentistById(int id); 
        void UpdateDentist(Dentist dentist);
    }
}