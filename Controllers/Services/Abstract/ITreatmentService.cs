using DentoApp.Entity;

namespace DentoApp.Services.Abstract
{
    public interface ITreatmentService
    {
        IQueryable<Treatment> GetTreatments();
        Treatment GetTreatmentById(int id);
        void AddTreatment(Treatment treatment);
        void UpdateTreatment(Treatment treatment);
        void DeleteTreatment(int id);
    }
}
