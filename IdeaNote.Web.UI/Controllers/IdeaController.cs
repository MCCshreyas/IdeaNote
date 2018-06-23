using System.Linq;
using System.Web.Mvc;
using IdeaNote.Web.UI.Models;

namespace IdeaNote.Web.UI.Controllers
{
    public class IdeaController : Controller
    {
        private readonly IdeaNoteContext _context = new IdeaNoteContext();

        [HttpGet]
        [Route("/idea/index/{id}")]
        public ActionResult Index(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            
            return View(user);
        }
    }
}