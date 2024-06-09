using DentoApp.Entity;

namespace DentoApp.Data.Abstract
{
    public interface IAppointmentRepository
    {
        IQueryable<Appointment> Appointments { get; }
    }
}