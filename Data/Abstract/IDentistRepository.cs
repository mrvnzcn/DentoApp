using DentoApp.Entity;

namespace DentoApp.Data.Abstract
{
    public interface IDentistRepository
    {
        IQueryable<Dentist> Dentists { get; }
    }
}