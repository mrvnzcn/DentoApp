using DentoApp.Data.Abstract;
using DentoApp.Data.Concrete.EfCore;
using DentoApp.Data.Concrete.EfCore.Data;
using DentoApp.Entity;

namespace DentoApp.Data.Concrete
{
    public class EfDentistRepository : IDentistRepository
    {
        private DentoContext _context;
        public EfDentistRepository(DentoContext context)
        {
            _context = context;
        }

        public IQueryable<Dentist> Dentists => _context.Dentists;

        public void Add(Dentist dentist)
        {
            _context.Dentists.Add(dentist);
            _context.SaveChanges(); // Değişiklikleri kaydet
        }

        public void Delete(Dentist dentist)
        {
            _context.Dentists.Remove(dentist);
            _context.SaveChanges(); // Değişiklikleri kaydet
        }

        public Dentist GetDentistById(int id)
        {
            return _context.Dentists
                            .FirstOrDefault(p => p.Id == id);  // hekimin ID'sine göre ilk eşleşeni döner
        }

        public void UpdateDentist(Dentist dentist)
        {
            _context.Dentists.Update(dentist);  // Hastayı günceller
            _context.SaveChanges();
        }
    }
}