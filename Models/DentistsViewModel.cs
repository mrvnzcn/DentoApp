using DentoApp.Entity;

namespace DentoApp.Models
{
    public class DentistsViewModel
    {
        public List<Dentist> Dentists { get; set; } = new();

        public Dentist? SingleDentist { get; set; }
    }
}