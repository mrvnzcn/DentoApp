namespace DentoApp.Entity;

public class Treatment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DentistId { get; set; }
    public DateTime TreatmentDate { get; set; }
    public string? TreatmentType { get; set; }
    public int TreatmentDuration { get; set; }
    public string? TreatmentDescription { get; set; }
    public double price { get; set; }
}