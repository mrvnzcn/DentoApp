namespace DentoApp.Entity;

public class Treatment
{
        public int Id { get; set; }
        public int PatientId { get; set; } // Foreign key for Patient
        public int DentistId { get; set; }
        public string? TreatmentType { get; set; }
        public int TreatmentDuration { get; set; }
        public string? TreatmentDescription { get; set; }
        public double Price { get; set; }
        public Patient? Patient { get; set; } // Navigation property for Patient
        public Dentist? Dentist { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
}