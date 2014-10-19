using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalaxyGame.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public RedirectToRouteResult NewGalaxy()
        {
            return RedirectToAction("Index");
        }
    }
}