using DentoApp.Entity;
using DentoApp.Models;
using DentoApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DentoApp.Data;

namespace DentoApp.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ITreatmentService _treatmentService;
        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        public IActionResult Index()
        {
            var treatments = _treatmentService.GetTreatments().ToList();
            var viewModel = new TreatmentsViewModel
            {
                Treatments = treatments
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Patients = new SelectList(_treatmentService.GetPatients(), "Id", "Name");
            ViewBag.Dentists = new SelectList(_treatmentService.GetDentists(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                _treatmentService.AddTreatment(treatment);
                return RedirectToAction(nameof(Index));
            }
            return View(treatment);
        }
    }
}