using DentoApp.Data.Abstract;
using DentoApp.Entity;
using DentoApp.Services.Abstract;

namespace DentoApp.Services.Concrete
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public IQueryable<Appointment> GetAppointments()
        {
            return _appointmentRepository.Appointments;
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointmentRepository.Appointments.FirstOrDefault(t => t.Id == id);
        }

        public void AddAppointment(Appointment appointment)
        {
            // Eklemek için ilgili repository methodunu çağır
            _appointmentRepository.Add(appointment);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            // Güncellemek için ilgili repository methodunu çağır
        }

        public void DeleteAppointment(int id)
        {
            // Silmek için ilgili repository methodunu çağır
        }
    }
}