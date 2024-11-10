using DentoApp.Entity;

namespace DentoApp.Data.Abstract
{
    public interface ITreatmentRepository
    {
        IQueryable<Treatment> Treatments { get; }
        void Add(Treatment treatment);
    }
}