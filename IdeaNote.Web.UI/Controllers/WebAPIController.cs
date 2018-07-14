using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Routing;
using IdeaNote.Web.UI.Models;

namespace IdeaNote.Web.UI.Controllers
{
    // ReSharper disable once InconsistentNaming
    public class WebAPIController : ApiController
    {
        private readonly IdeaNoteContext _context = new IdeaNoteContext();

        [Route("webapi")]
        public IEnumerable<string> Get()
        {
            return new List<string>();
        }

       
        

       
        [HttpPost]
        [Route("webapi/{email}/{password}")]
        public User Post(string email , string password)
        {
            var dbUser = _context.Users.FirstOrDefault(u =>
                u.email == email && u.password == password);

            if (dbUser != null)
            {
                return dbUser;
            }

            var message = "User not found";
            HttpError err = new HttpError(message);
            return null;

        }

        
        public void Put(int id, [FromBody]string value)
        {
        }

       
        public void Delete(int id)
        {
        }
    }
}
