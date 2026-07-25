using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    public class DonorController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}