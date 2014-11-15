using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GalaxyGame.Web.Controllers
{
    public class SolarSystemController : ApiController
    {

        public SolarSystemController()
        {
            
        }
        // GET: api/SolarSystems
        public IEnumerable<string> GetSpaceObjects()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Move/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
