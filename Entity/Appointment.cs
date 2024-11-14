using System.ComponentModel.DataAnnotations.Schema;

namespace DentoApp.Entity;

public class Appointment
{
    public int Id { get; set; }
    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    [ForeignKey("Dentist")]
    public int DentistId { get; set; }
    [ForeignKey("Treatment")]
    public int TreatmentId { get; set; } // Foreign key for Treatment
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
    public Patient? Patient { get; set; } // Navigation property for Patient
    public Dentist? Dentist { get; set; } // Navigation property for Dentist
    public Treatment? Treatment { get; set; } // Navigation property for Treatment
}
