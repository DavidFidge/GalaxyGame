using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GalaxyGame.Web.Controllers
{
    public class MoveController : ApiController
    {
        // GET: api/Move
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Move/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Move
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Move/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Move/5
        public void Delete(int id)
        {
        }
    }
}
