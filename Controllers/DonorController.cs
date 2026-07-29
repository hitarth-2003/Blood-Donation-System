using Microsoft.AspNetCore.Mvc;
using BloodDonationSystem.Data;
using BloodDonationSystem.Models;

namespace BloodDonationSystem.Controllers
{
    public class DonorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===========================
        // GET: Register Page
        // ===========================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // ===========================
        // POST: Register Donor
        // ===========================
        [HttpPost]
        public IActionResult Register(Donor donor)
        {
            if (ModelState.IsValid)
            {
                _context.Donors.Add(donor);
                _context.SaveChanges();

                return RedirectToAction("Success");
            }

            return View(donor);
        }

        // ===========================
        // Success Page
        // ===========================
        public IActionResult Success()
        {
            return View();
        }

        // ===========================
        // Donor List
        // ===========================
        public IActionResult List()
        {
            var donors = _context.Donors.ToList();
            return View(donors);
        }

        // ===========================
        // Donor Details
        // ===========================
        public IActionResult Details(int id)
        {
            var donor = _context.Donors.FirstOrDefault(x => x.Id == id);

            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }
    }
}