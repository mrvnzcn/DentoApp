using System.ComponentModel.DataAnnotations;

namespace DentoApp.Models
{
    public enum DentistProfession
    {
        [Display(Name = "General Dentist")]
        GeneralDentist,
        [Display(Name = "Orthodontist")]
        Orthodontist,
        [Display(Name = "Oral and Maxillofacial Surgeon")]
        OralAndMaxillofacialSurgeon,
        [Display(Name = "Periodontist")]
        Periodontist,
        [Display(Name = "Endodontist")]
        Endodontist,
        [Display(Name = "Prosthodontist")]
        Prosthodontist
    }
}