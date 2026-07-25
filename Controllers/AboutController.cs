using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}