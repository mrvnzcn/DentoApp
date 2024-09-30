using DentoApp.Entity;

namespace DentoApp.Models
{
    public class PatientsViewModel
    {
        // Birden fazla hasta için liste (Index için kullanılır)
        public List<Patient> Patients { get; set; } = new();

        // Tekil hasta (Details, Edit ve Delete işlemleri için kullanılır)
        public Patient? SinglePatient { get; set; }
    }
}