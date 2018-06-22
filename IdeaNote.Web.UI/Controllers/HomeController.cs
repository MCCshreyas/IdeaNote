using System.Web.Mvc;

namespace IdeaNote.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}