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
    }
}