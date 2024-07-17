using DentoApp.Entity;

namespace DentoApp.Services.Abstract
{
    public interface IAppointmentService
    {
        IQueryable<Appointment> GetAppointments();
        Appointment GetAppointmentById(int id);
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int id);
    }
}
