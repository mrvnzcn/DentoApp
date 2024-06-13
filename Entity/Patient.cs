namespace DentoApp.Entity;

public class Patient
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int Age { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public List<Dentist>? Dentists { get; set; } = new List<Dentist>();
    public List<Appointment>? Appointments { get; set; } = new List<Appointment>();
    public List<Treatment>? Treatments { get; set; } = new List<Treatment>();
    public List<string>? Attachments { get; set; }
    public Dentist? Dentist { get; set; }



}