using System.Linq;
using System.Web.Mvc;
using IdeaNote.Web.UI.Models;

namespace IdeaNote.Web.UI.Controllers
{
    public class IdeaController : Controller
    {
        private readonly IdeaNoteContext _context = new IdeaNoteContext();

        [HttpGet]
        [Route("/idea/index")]
        public ActionResult Index()
        {
            var userId = Session["UserID"];
            
            var user = _context.Users.FirstOrDefault(u => u.Id == (int) userId);
            
            return View(user);
        }

        [HttpGet]
        [Route("/idea/create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Idea userIdea)
        {
            




        }


    }
}