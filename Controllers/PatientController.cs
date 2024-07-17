using DentoApp.Models;
using DentoApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DentoApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            var patients = _patientService.GetPatients().ToList();
            var viewModel = new PatientsViewModel
            {
                Patients = patients
            };

            return View(viewModel);
        }
    }
}