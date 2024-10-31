using DentoApp.Entity;
using DentoApp.Models;
using DentoApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dentist dentist)
        {
            if (ModelState.IsValid)
            {
                _dentistService.AddDentist(dentist);
                return RedirectToAction(nameof(Index));
            }
            return View(dentist);
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dentist = _dentistService.GetDentistById(id);
            if (dentist == null)
            {
                return NotFound();  // hekim bulunamazsa 404 döner
            }

            return View(dentist);  // Hasta bilgilerini görünümde göster
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id) // İsim değiştirildi
        {
            var dentist = _dentistService.GetDentistById(id);
            if (dentist == null)
            {
                return NotFound();  // Hasta bulunamazsa 404 döner
            }

            var success = _dentistService.DeleteDentist(id);  // Silme işlemi
            if (success)
            {
                return RedirectToAction("Index");  // Başarılı silme sonrası Index sayfasına yönlendir
            }

            return View("Error");  // Hata durumunda bir hata sayfasına yönlendir
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var dentist = _dentistService.GetDentistById(id);  // Tekil hasta
            if (dentist == null)
            {
                return NotFound();  // Hasta bulunamadığında 404 sayfası döner
            }

            // ViewModel oluşturma
            var viewModel = new DentistsViewModel
            {
                SingleDentist = dentist  // Tekil hasta
            };

            return View(viewModel);  // Hasta bulunduğunda View döner ve hasta bilgilerini sayfaya taşır
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dentist = _dentistService.GetDentistById(id);
            if (dentist == null)
            {
                return NotFound();  // Eğer hasta bulunamazsa 404 döner
            }

            

            var viewModel = new DentistsViewModel
            {
                SingleDentist = dentist  // Güncellenecek hasta
            };

            return View(dentist);  // Hasta bilgilerini formda gösterir
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dentist dentist)
        {
            if (ModelState.IsValid)
            {
                _dentistService.UpdateDentist(dentist);
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new DentistsViewModel
            {
                SingleDentist = dentist  // Formdaki güncel verilerle geri dön
            };

            return View(viewModel);
        }
    }
}