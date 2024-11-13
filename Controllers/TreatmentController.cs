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
            ViewBag.Patients = new SelectList(_treatmentService.GetPatients(), "Id", "Name");
            ViewBag.Dentists = new SelectList(_treatmentService.GetDentists(), "Id", "Name");
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Patients = new SelectList(_treatmentService.GetPatients(), "Id", "Name");
            ViewBag.Dentists = new SelectList(_treatmentService.GetDentists(), "Id", "Name");
            var treatment = _treatmentService.GetTreatmentById(id);
            if (treatment == null)
            {
                return NotFound();  // Eğer hasta bulunamazsa 404 döner
            }

            var viewModel = new TreatmentsViewModel
            {
                SingleTreatment = treatment  // Güncellenecek hasta
            };

            return View(treatment);  // Hasta bilgilerini formda gösterir
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                _treatmentService.UpdateTreatment(treatment);
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new TreatmentsViewModel
            {
                SingleTreatment = treatment  // Formdaki güncel verilerle geri dön
            };

            return View(viewModel);
        }

        [HttpGet]
         public IActionResult Delete(int id)
        {
            var treatment = _treatmentService.GetTreatmentById(id);
            if(treatment == null)
            {
                return NotFound();
            }
            return View(treatment);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var treatment = _treatmentService.GetTreatmentById(id);
            if (treatment == null)
            {
                return NotFound();  // Hasta bulunamazsa 404 döner
            }
            var success = _treatmentService.DeleteTreatment(id);
            if(success)
            {
                return RedirectToAction("Index");
            }
            
            return View("Error");
        }
    }
}