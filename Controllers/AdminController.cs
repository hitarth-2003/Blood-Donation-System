using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodDonationSystem.Data;
using BloodDonationSystem.Models;

namespace BloodDonationSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================
        // Admin Login
        // ==========================
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                HttpContext.Session.SetString("Admin", "LoggedIn");
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }

        // ==========================
        // Logout
        // ==========================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // ==========================
        // Dashboard
        // ==========================
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new AdminDashboardViewModel
            {
                TotalDonors = _context.Donors.Count(),
                TotalRequests = _context.BloodRequests.Count(),
                TotalContacts = _context.Contacts.Count()
            };

            return View(model);
        }

        // ==========================
        // Manage Donors
        // ==========================
        public IActionResult ManageDonors()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login");
            }

            var donors = _context.Donors.ToList();
            return View(donors);
        }

        // ==========================
        // Edit Donor
        // ==========================
        [HttpGet]
        public IActionResult EditDonor(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login");
            }

            var donor = _context.Donors.FirstOrDefault(x => x.Id == id);

            if (donor == null)
                return NotFound();

            return View(donor);
        }

        [HttpPost]
        public IActionResult EditDonor(Donor donor)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                _context.Donors.Update(donor);
                _context.SaveChanges();

                return RedirectToAction("ManageDonors");
            }

            return View(donor);
        }

        // ==========================
        // Delete Donor
        // ==========================
        public IActionResult DeleteDonor(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login");
            }

            var donor = _context.Donors.FirstOrDefault(x => x.Id == id);

            if (donor != null)
            {
                _context.Donors.Remove(donor);
                _context.SaveChanges();
            }

            return RedirectToAction("ManageDonors");
        }

        // ==========================
        // Manage Requests
        // ==========================
        public IActionResult ManageRequests()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login");
            }

            var requests = _context.BloodRequests.ToList();
            return View(requests);
        }

        // ==========================
        // Delete Request
        // ==========================
        public IActionResult DeleteRequest(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login");
            }

            var request = _context.BloodRequests.FirstOrDefault(x => x.Id == id);

            if (request != null)
            {
                _context.BloodRequests.Remove(request);
                _context.SaveChanges();
            }

            return RedirectToAction("ManageRequests");
        }


        // ==========================
// Approve Request
// ==========================
public IActionResult ApproveRequest(int id)
{
    var request = _context.BloodRequests
                          .FirstOrDefault(x => x.Id == id);

    if (request != null)
    {
        request.Status = "Approved";

        _context.SaveChanges();
    }

    return RedirectToAction("ManageRequests");
}

        // ==========================
        // Contact Messages
        // ==========================
        public IActionResult Contacts()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login");
            }

            return View(_context.Contacts.ToList());
        }

        // ==========================
        // Delete Contact
        // ==========================
        public IActionResult DeleteContact(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login");
            }

            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);

            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }

            return RedirectToAction("Contacts");
        }
    }
}