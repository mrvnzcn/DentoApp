using DentoApp.Entity;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.AddPatient(patient);
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();  // Hasta bulunamazsa 404 döner
            }

            return View(patient);  // Hasta bilgilerini görünümde göster
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id) // İsim değiştirildi
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();  // Hasta bulunamazsa 404 döner
            }

            var success = _patientService.DeletePatient(id);  // Silme işlemi
            if (success)
            {
                return RedirectToAction("Index");  // Başarılı silme sonrası Index sayfasına yönlendir
            }

            return View("Error");  // Hata durumunda bir hata sayfasına yönlendir
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var patient = _patientService.GetPatientById(id);  // Tekil hasta
            if (patient == null)
            {
                return NotFound();  // Hasta bulunamadığında 404 sayfası döner
            }

            // ViewModel oluşturma
            var viewModel = new PatientsViewModel
            {
                SinglePatient = patient  // Tekil hasta
            };

            return View(viewModel);  // Hasta bulunduğunda View döner ve hasta bilgilerini sayfaya taşır
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();  // Eğer hasta bulunamazsa 404 döner
            }

            var viewModel = new PatientsViewModel
            {
                SinglePatient = patient  // Güncellenecek hasta
            };

            return View(patient);  // Hasta bilgilerini formda gösterir
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.UpdatePatient(patient);
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new PatientsViewModel
            {
                SinglePatient = patient  // Formdaki güncel verilerle geri dön
            };

            return View(viewModel);
        }
    }
}