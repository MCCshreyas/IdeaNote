using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using IdeaNote.Web.UI.Models;
using Newtonsoft.Json;

namespace IdeaNote.Web.UI.Controllers
{
    public class DataController : ApiController
    {
        readonly IdeaNoteContext _db = new IdeaNoteContext();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/data/{email}/{password}")]
        public System.Net.Http.HttpResponseMessage Authenticate(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u =>
                u.email == email && u.password == password);

            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "user not found");
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("api/data/{userID}")]
        public void GetIdeas(int userID)
        {

        }

        // POST api/values
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("api/data/createnewaccount")]
        public System.Net.Http.HttpResponseMessage CreateNewAccount(User user)
        {
            var newUser = _db.Users.Add(user);
            var status = _db.SaveChanges();
            if (status != 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }

            if (status == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, newUser);
            }

            return null;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
