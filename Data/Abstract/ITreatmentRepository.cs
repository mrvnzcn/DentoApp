using DentoApp.Entity;

namespace DentoApp.Data.Abstract
{
    public interface ITreatmentRepository
    {
        IQueryable<Treatment> Treatments { get; }
        void Add(Treatment treatment);
        void Update(Treatment treatment);
        Treatment GetTreatmentById(int id);
        void Delete(Treatment treatment);
    }
}