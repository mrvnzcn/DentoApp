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
            return _dentistRepository.GetDentistById(id);
        }

        public void AddDentist(Dentist dentist)
        {
            // Eklemek için ilgili repository methodunu çağır
            _dentistRepository.Add(dentist);
        }

        public void UpdateDentist(Dentist dentist)
        {
            // Güncellemek için ilgili repository methodunu çağır
            _dentistRepository.UpdateDentist(dentist);
        }

        public bool DeleteDentist(int id)
        {
            var dentist = _dentistRepository.GetDentistById(id);
            if(dentist == null)
            {
                return false;
            }

            _dentistRepository.Delete(dentist);
            return true;
        }
    }
}