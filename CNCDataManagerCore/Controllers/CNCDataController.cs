using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CNCDataManagerCore.Controllers
{
    public class CNCDataController : Controller
    {
        public IActionResult Index()
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