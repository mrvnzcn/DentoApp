namespace DentoApp.Entity;

public class Dentist
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Profession { get; set; }
    public int Age { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public List<Patient> Patients { get; set; } = new List<Patient>();
    public List<Appointment>? Appointments { get; set; } = new List<Appointment>();
    public List<string>? WorkingHours { get; set; }

    public Patient? Patient { get; set; }


}