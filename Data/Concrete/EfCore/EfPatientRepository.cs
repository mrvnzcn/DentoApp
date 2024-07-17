using DentoApp.Data.Abstract;
using DentoApp.Data.Concrete.EfCore;
using DentoApp.Data.Concrete.EfCore.Data;
using DentoApp.Entity;

namespace DentoApp.Data.Concrete
{
    public class EfPatientRepository : IPatientRepository
    {
        private DentoContext _context;
        public EfPatientRepository(DentoContext context)
        {
            _context = context;
        }

        public IQueryable<Patient> Patients => _context.Patients;
    }
}