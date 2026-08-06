using Microsoft.AspNetCore.Mvc;
using BloodDonationSystem.Data;
using BloodDonationSystem.Models;

namespace BloodDonationSystem.Controllers
{
    public class BloodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodController(ApplicationDbContext context)
        {
            _context = context;
        }


        // ==========================
        // Blood Request Form
        // ==========================
        [HttpGet]
        public IActionResult RequestBlood()
        {
            return View();
        }



        // ==========================
        // Submit Blood Request
        // ==========================
 [HttpPost]
public IActionResult RequestBlood(BloodRequest request)
{
    ModelState.Remove("Status");

    request.Status = "Pending";

    if (!ModelState.IsValid)
    {
        return View(request);
    }

    _context.BloodRequests.Add(request);
    _context.SaveChanges();

    return RedirectToAction("Success");
}



        // ==========================
        // Blood Request Success Page
        // ==========================
        public IActionResult Success()
        {
            return View();
        }




        // ==========================
        // All Blood Requests
        // ==========================
        public IActionResult Requests()
        {
            var requests = _context.BloodRequests.ToList();

            return View(requests);
        }




        // ==========================
        // Blood Request Details
        // ==========================
        public IActionResult Details(int id)
        {
            var request = _context.BloodRequests
                                  .FirstOrDefault(x => x.Id == id);


            if (request == null)
            {
                return NotFound();
            }


            return View(request);
        }





        // ==========================
        // Search Donor
        // ==========================
        [HttpGet]
        public IActionResult Search(string bloodGroup, string city)
        {
            var donors = _context.Donors.AsQueryable();



            if (!string.IsNullOrEmpty(bloodGroup))
            {
                donors = donors.Where(x => x.BloodGroup == bloodGroup);
            }



            if (!string.IsNullOrEmpty(city))
            {
                donors = donors.Where(x => x.City.Contains(city));
            }



            return View(donors.ToList());
        }



        // ==========================
        // Edit Blood Request GET
        // ==========================
        public IActionResult Edit(int id)
        {
            var request = _context.BloodRequests
                                  .FirstOrDefault(x => x.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }




        // ==========================
        // Edit Blood Request POST
        // ==========================
        [HttpPost]
        public IActionResult Edit(BloodRequest request)
        {
            if (ModelState.IsValid)
            {
                _context.BloodRequests.Update(request);

                _context.SaveChanges();

                return RedirectToAction("Requests");
            }

            return View(request);
        }




        // ==========================
        // Delete Blood Request
        // ==========================
        public IActionResult Delete(int id)
        {
            var request = _context.BloodRequests
                                  .FirstOrDefault(x => x.Id == id);


            if (request == null)
            {
                return NotFound();
            }


            _context.BloodRequests.Remove(request);

            _context.SaveChanges();


            return RedirectToAction("Requests");
        }

    }
}