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
    }
}