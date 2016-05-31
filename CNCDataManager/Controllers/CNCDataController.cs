using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNCDataManager.Controllers
{
    public class CNCDataController : Controller
    {
        // GET: CNCData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string listname)
        {
            ViewData["viewname"] = listname;
            return View();
        }
    }
}