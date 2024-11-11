using DentoApp.Data.Abstract;
using DentoApp.Data.Concrete.EfCore;
using DentoApp.Data.Concrete.EfCore.Data;
using DentoApp.Entity;

namespace DentoApp.Data.Concrete
{
    public class EfTreatmentRepository : ITreatmentRepository
    {
        private DentoContext _context;
        public EfTreatmentRepository(DentoContext context)
        {
            _context = context;
        }

        public IQueryable<Treatment> Treatments => _context.Treatments;

        public void Add(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            _context.SaveChanges(); // Değişiklikleri kaydet
        }
        public void Update(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
            _context.SaveChanges();
        }
    }
}