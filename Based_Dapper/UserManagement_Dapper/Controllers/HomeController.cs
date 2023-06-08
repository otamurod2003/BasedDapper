using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserManagement_Dapper.Models;

namespace UserManagement_Dapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _users;

        //constructor injection
        public HomeController(IUserRepository users)
        {
            _users = users;
        }
        public IActionResult Index()
        {
            ViewBag.AllUsers = _users.GetAllUsers().ToList();
            return View(ViewBag.AllUsers);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var user = _users.GetUser(id);
            if (user == null)
            {
                NotFound();
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _users.CreateUser(user);
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _users.GetUser(id);
            if (user == null)
            {
                NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            _users.UpdateUser(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _users.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
