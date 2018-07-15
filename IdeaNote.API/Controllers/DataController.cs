using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IdeaNote.API.Models;

namespace IdeaNote.API.Controllers
{
    public class DataController : ApiController
    {
        readonly IdeaNoteContext _db = new IdeaNoteContext();

        [HttpGet]
        [Route("api/data/{email}/{password}")]
        public User Authenticate(string email , string password)
        {
            var user = _db.Users.FirstOrDefault(u =>
                u.email == email && u.password == password);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
