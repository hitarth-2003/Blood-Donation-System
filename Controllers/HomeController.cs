using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BloodDonationSystem.Models;
using BloodDonationSystem.Data;

namespace BloodDonationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                TotalDonors = _context.Donors.Count(),
                TotalRequests = _context.BloodRequests.Count()
            };

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}