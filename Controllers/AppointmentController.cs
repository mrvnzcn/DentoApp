using DentoApp.Models;
using DentoApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

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
            var appointments = _appointmentService.GetAppointments().ToList();
            var viewModel = new AppointmentsViewModel
            {
                Appointments = appointments
            };

            return View(viewModel);
        }
    }
}