using DentoApp.Models;
using DentoApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using DentoApp.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using DentoApp.Helpers;

namespace DentoApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            ViewBag.Patients = new SelectList(_appointmentService.GetPatients(), "Id", "Name");
            ViewBag.Dentists = new SelectList(_appointmentService.GetDentists(), "Id", "Name");
            ViewBag.Treatments = new SelectList(_appointmentService.GetTreatments(), "Id", "Name");
            var appointments = _appointmentService.GetAppointments().ToList();
            var viewModel = new AppointmentsViewModel
            {
                Appointments = appointments
            };

            return View(viewModel);
        }

        public IActionResult Create(int? patientId, int? dentistId)
        {
            ViewBag.Patients = new SelectList(_appointmentService.GetPatients(), "Id", "Name");
            ViewBag.Dentists = new SelectList(_appointmentService.GetDentists(), "Id", "Name");

            if (patientId.HasValue && dentistId.HasValue)
            {
                var treatments = _appointmentService.GetTreatmentsForPatientAndDentist(patientId.Value, dentistId.Value);
                var treatmentSelectList = treatments.Select(t => 
                {
                    var displayName = t.TreatmentType != null && Enum.TryParse(typeof(TreatmentType), t.TreatmentType, out var enumValue)
                        ? EnumHelper.GetDisplayName((Enum)enumValue)
                        : "Unknown"; // Null veya geçersiz durumda "Unknown" yazılır

                    return new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = displayName
                    };
                }).ToList();

                ViewBag.Treatments = new SelectList(treatmentSelectList, "Value", "Text");
            }
            else
            {
                ViewBag.Treatments = new SelectList(new List<SelectListItem>(), "Value", "Text"); // Boş bir liste
            }

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.AddAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }
    }
}