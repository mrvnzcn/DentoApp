using DentoApp.Models;
using DentoApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DentoApp.Controllers
{
    public class DentistController : Controller
    {
        private readonly IDentistService _dentistService;
        public DentistController(IDentistService dentistService)
        {
            _dentistService = dentistService;
        }

        public IActionResult Index()
        {
            var dentists = _dentistService.GetDentists().ToList();
            var viewModel = new DentistsViewModel
            {
                Dentists = dentists
            };

            return View(viewModel);
        }
    }
}