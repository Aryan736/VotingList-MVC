using Microsoft.AspNetCore.Mvc;
using VotingList.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace VotingList.Controllers
{
    public class VotersController : Controller
    {
        public CitizenDB _db;
        public VotersController()
        {
            _db = new CitizenDB();
        }

        [HttpGet]
        public IActionResult RegisterVoters()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterVoters(Votermod obj)
        {
            _db.Voters.Add(obj);
            _db.SaveChanges();
            return View();

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email)
        {
            var user = _db.Voters.FirstOrDefault(x => x.email == email);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.VoterId);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid Email";
            return View();
        }


        public IActionResult Dashboard()
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
                return RedirectToAction("Login");

            var user = _db.Voters.Find(id);

            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

       

    }
}
