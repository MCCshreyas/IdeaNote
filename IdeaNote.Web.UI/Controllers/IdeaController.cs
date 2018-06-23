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

            if (userId != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == (int)userId);

                var ideas = _context.Ideas.Where(i => i.UserId == (int)userId);

                if (user != null)
                {
                    ViewBag.UserID = userId;
                    ViewBag.UserName = user.name;
                    return View(ideas);
                }
            }

            return View();

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
            var userId = Session["UserID"];
            var user = _context.Users.FirstOrDefault(u => u.Id == (int)userId);
            userIdea.User = user;
            userIdea.UserId = user.Id;
            _context.Ideas.Add(userIdea);
            _context.SaveChanges();
            return RedirectToAction("Index", "Idea");
        }

        [HttpPost]
        [Route("/idea/delete/{id}")]
        public ActionResult Delete(int Id)
        {
            var unwantedIdea = _context.Ideas.SingleOrDefault(i => i.Id == Id);

            if (unwantedIdea != null)
            {
                _context.Ideas.Remove(unwantedIdea);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Idea");
        }

        [HttpPost]
        [Route("/idea/edit/{id}")]
        public ActionResult Edit(int Id)
        {
            var editIdea = _context.Ideas.SingleOrDefault(i => i.Id == Id);

            return RedirectToAction("Edit", "Idea", editIdea);
        }


        [HttpGet]
        [Route("/idea/edit/{id}")]
        public ActionResult Edit(Idea editIdea)
        {
            return View(editIdea);
        }

        [HttpPost]
        public ActionResult EditIdea(Idea editIdea)
        {
            var oldIdeaContent = _context.Ideas.FirstOrDefault(i => i.Id == editIdea.Id);

            oldIdeaContent.title = editIdea.title;
            oldIdeaContent.details = editIdea.details;

            _context.SaveChanges();

            return RedirectToAction("Index", "Idea");
        }
    }
}