using Microsoft.AspNetCore.Mvc;
using VotingList.Models;
using System.Linq;

namespace VotingList.Controllers
{
    public class AdminController : Controller
    {
        private CitizenDB _db;

        public AdminController()
        {
            _db = new CitizenDB();
        }

        // GET: Admin Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Admin Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "1234")
            {
                HttpContext.Session.SetString("Admin", "true");
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid Credentials";
            return View();
        }

        // Admin Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Admin") != "true")
                return RedirectToAction("Login");

            var voters = _db.Voters.ToList();
            return View(voters);
        }

        public IActionResult Approve(int id)
        {
            var voter = _db.Voters.Find(id);
            voter.Status = Votermod.VoterStatus.Approved;
            _db.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        public IActionResult Reject(int id)
        {
            var voter = _db.Voters.Find(id);
            voter.Status = Votermod.VoterStatus.Rejected;
            _db.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Admin");
            return RedirectToAction("Login");
        }
    }
}