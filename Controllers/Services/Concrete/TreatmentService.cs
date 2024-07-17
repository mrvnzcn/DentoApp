using DentoApp.Data.Abstract;
using DentoApp.Entity;
using DentoApp.Services.Abstract;

namespace DentoApp.Services.Concrete
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public IQueryable<Treatment> GetTreatments()
        {
            return _treatmentRepository.Treatments;
        }

        public Treatment GetTreatmentById(int id)
        {
            return _treatmentRepository.Treatments.FirstOrDefault(t => t.Id == id);
        }

        public void AddTreatment(Treatment treatment)
        {
            // Eklemek için ilgili repository methodunu çağır
        }

        public void UpdateTreatment(Treatment treatment)
        {
            // Güncellemek için ilgili repository methodunu çağır
        }

        public void DeleteTreatment(int id)
        {
            // Silmek için ilgili repository methodunu çağır
        }
    }
}