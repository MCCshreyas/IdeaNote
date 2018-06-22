using System.Web.Mvc;

namespace IdeaNote.Web.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
    }
}