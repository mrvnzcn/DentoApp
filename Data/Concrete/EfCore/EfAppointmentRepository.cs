using DentoApp.Data.Abstract;
using DentoApp.Entity;
using System.Linq;

namespace DentoApp.Data.Concrete.EfCore.Data
{
    public class EfAppointmentRepository : IAppointmentRepository
    {
        private readonly DentoContext _context;

        public EfAppointmentRepository(DentoContext context)
        {
            _context = context;
        }

        // IQueryable olarak Appointment verilerini getiren property
        public IQueryable<Appointment> Appointments => _context.Appointments;

        // Yeni bir Appointment eklemek için
        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges(); // Değişiklikleri kaydet
        }

        // Mevcut bir Appointment güncellemek için
        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges(); // Değişiklikleri kaydet
        }

        // Var olan bir Appointment'ı silmek için
        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges(); // Değişiklikleri kaydet
        }

        // ID ile Appointment bulmak için
        public Appointment GetById(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.Id == id);
        }
    }
}
