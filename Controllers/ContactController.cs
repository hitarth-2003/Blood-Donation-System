using Microsoft.AspNetCore.Mvc;
using BloodDonationSystem.Data;
using BloodDonationSystem.Models;

namespace BloodDonationSystem.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Contact Page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Submit Contact
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreatedDate = DateTime.Now;

                _context.Contacts.Add(contact);

                _context.SaveChanges();

                return RedirectToAction("Success");
            }

            return View(contact);
        }

        // Success Page
        public IActionResult Success()
        {
            return View();
        }
    }
}