using DentoApp.Entity;
using System.Linq;

namespace DentoApp.Data.Abstract
{
    public interface IAppointmentRepository
    {
        IQueryable<Appointment> Appointments { get; }

        // Yeni bir Appointment eklemek için
        void Add(Appointment appointment);

        // Appointment güncellemek için
        void Update(Appointment appointment);

        // Appointment silmek için
        void Delete(Appointment appointment);

        // ID ile Appointment bulmak için
        Appointment GetById(int id);
    }
}
