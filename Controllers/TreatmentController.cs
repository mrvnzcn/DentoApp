using DentoApp.Models;
using DentoApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

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
    }
}