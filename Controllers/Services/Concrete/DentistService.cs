using DentoApp.Data.Abstract;
using DentoApp.Entity;
using DentoApp.Services.Abstract;

namespace DentoApp.Services.Concrete
{
    public class DentistService : IDentistService
    {
        private readonly IDentistRepository _dentistRepository;
        public DentistService(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }

        public IQueryable<Dentist> GetDentists()
        {
            return _dentistRepository.Dentists;
        }

        public Dentist GetDentistById(int id)
        {
            return _dentistRepository.Dentists.FirstOrDefault(t => t.Id == id);
        }

        public void AddDentist(Dentist dentist)
        {
            // Eklemek için ilgili repository methodunu çağır
        }

        public void UpdateDentist(Dentist dentist)
        {
            // Güncellemek için ilgili repository methodunu çağır
        }

        public void DeleteDentist(int id)
        {
            // Silmek için ilgili repository methodunu çağır
        }
    }
}