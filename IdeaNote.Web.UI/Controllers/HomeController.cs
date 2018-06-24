using System.Web.Mvc;

namespace IdeaNote.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/about")]
        public ActionResult About()
        {
            return View();
        }
    }
}