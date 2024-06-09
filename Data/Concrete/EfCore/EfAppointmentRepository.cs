using DentoApp.Data.Abstract;
using DentoApp.Entity;

namespace DentoApp.Data.Concrete
{
    public class EfAppointmentRepository : IAppointmentRepository
    {
        private DentoContext _context;
        public EfAppointmentRepository(DentoContext context)
        {
            _context = context;
        }

        public IQueryable<Appointment> Appointments => _context.Appointments;
    }
}