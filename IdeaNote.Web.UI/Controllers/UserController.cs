using System.Linq;
using System.Web.Mvc;
using IdeaNote.Web.UI.Models;

namespace IdeaNote.Web.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IdeaNoteContext _context = new IdeaNoteContext();

        [HttpGet]
        [Route("/user/register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User newRegisterUser)
        {
            _context.Users.Add(newRegisterUser);
            _context.SaveChangesAsync();
            return Content("Register sucessfully");
        }

        [HttpGet]
        [Route("/user/login")]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User newRegisterUser)
        {
            var user = _context.Users.FirstOrDefault(u =>
                    u.email == newRegisterUser.email && u.password == newRegisterUser.password);

            if (user != null)
            {
                Session["UserID"] = user.Id;

                return RedirectToAction("Index", "Idea");
            }

            ViewBag.Message = "Please enter correct credentials";
            return View();

        }
    }
}