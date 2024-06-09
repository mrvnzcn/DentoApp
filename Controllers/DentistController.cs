using Microsoft.AspNetCore.Mvc;

namespace DentoApp.Controllers
{
    public class DentistController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}