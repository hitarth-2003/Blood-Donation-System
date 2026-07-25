using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageDonors()
        {
            return View();
        }

        public IActionResult ManageRequests()
        {
            return View();
        }
    }
}