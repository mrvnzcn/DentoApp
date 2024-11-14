using DentoApp.Data.Abstract;
using DentoApp.Entity;
using DentoApp.Services.Abstract;

namespace DentoApp.Services.Concrete
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IDentistRepository _dentistRepository;
        private readonly IPatientRepository _patientRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, ITreatmentRepository treatmentRepository, IDentistRepository dentistRepository, IPatientRepository patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _treatmentRepository = treatmentRepository;
            _dentistRepository = dentistRepository;
            _patientRepository = patientRepository;
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

        public IQueryable<Patient> GetPatients() // Yeni metot
        {
            return _patientRepository.Patients;
        }

        public IQueryable<Dentist> GetDentists() // Yeni metot
        {
            return _dentistRepository.Dentists;
        }

        public IQueryable<Treatment> GetTreatments() // Yeni metot
        {
            return _treatmentRepository.Treatments;
        }

        public List<Treatment> GetTreatmentsForPatientAndDentist(int patientId, int dentistId)
        {
            // Hasta ve diş hekimi bazında tedavileri filtrele
            var treatments = _treatmentRepository.Treatments
                .Where(t => t.PatientId == patientId && t.DentistId == dentistId)
                .ToList();

            return treatments;
        }
    }
}