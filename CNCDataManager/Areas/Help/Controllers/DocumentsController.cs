using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNCDataManager.Areas.Help.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Help/Documents
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataAPI()
        {
            return View();
        }
    }
}