using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    public class BloodController : Controller
    {
        public IActionResult RequestBlood()
        {
            return View();
        }

        public IActionResult Requests()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}