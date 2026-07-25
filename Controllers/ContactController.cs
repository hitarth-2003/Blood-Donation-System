using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}