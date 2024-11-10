using DentoApp.Entity;

namespace DentoApp.Models
{
    public class TreatmentsViewModel
    {
        public List<Treatment> Treatments { get; set; } = new();
        public TreatmentType TreatmentType { get; set; }
    }
}