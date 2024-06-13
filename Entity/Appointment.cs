namespace DentoApp.Entity;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DentistId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? TreatmentType { get; set; }
    public string? Notes { get; set; }
    public Patient? Patient { get; set; }
    public Dentist? Dentist { get; set; }
}
