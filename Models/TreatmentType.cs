using System.ComponentModel.DataAnnotations;

namespace DentoApp.Models
{
    public enum TreatmentType
    {
        
        [Display(Name = "Filling and Restoration")]
        GeneralDentist_FillingAndRestoration,
        [Display(Name = "Teeth Cleaning")]
        GeneralDentist_TeethCleaning,
        [Display(Name = "Tooth Extraction")]
        GeneralDentist_ToothExtraction,
        
        [Display(Name = "Braces")]
        Orthodontist_Braces,
        [Display(Name = "Clear Aligner")]
        Orthodontist_ClearAligner,
        [Display(Name = "Orthognathic Surgery")]
        Orthodontist_OrthognathicSurgery,
        
        [Display(Name = "Oral Surgery")]
        OralAndMaxillofacialSurgeon_OralSurgery,
        [Display(Name = "Dental Implant Surgery")]
        OralAndMaxillofacialSurgeon_DentalImplantSurgery,
        [Display(Name = "Jaw Fracture Treatment")]
        OralAndMaxillofacialSurgeon_JawFractureTreatment,
        
        [Display(Name = "Periodontal Therapy")]
        Periodontist_PeriodontalTherapy,
        [Display(Name = "Root Planing")]
        Periodontist_RootPlaning,
        [Display(Name = "Regenerative Gum Treatments")]
        Periodontist_RegenerativeGumTreatments,
        
        [Display(Name = "Root Canal Therapy")]
        Endodontist_RootCanalTherapy,
        [Display(Name = "Apicoectomy")]
        Endodontist_Apicoectomy,
        [Display(Name = "Dental Trauma Treatment")]
        Endodontist_DentalTraumaTreatment,
        
        [Display(Name = "Fixed and Removable Prostheses")]
        Prosthodontist_FixedAndRemovableProstheses,
        [Display(Name = "Partial or Full Dentures")]
        Prosthodontist_PartialOrFullDentures,
        [Display(Name = "Implant-Supported Prosthesis")]
        Prosthodontist_ImplantSupportedProsthesis
    
    }
}