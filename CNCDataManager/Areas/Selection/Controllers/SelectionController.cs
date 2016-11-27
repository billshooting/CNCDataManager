using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNCDataManager.Areas.Selection.Models;

namespace CNCDataManager.Areas.Selection.Controllers
{
    public class SelectionController : Controller
    {
        // GET: Selection/Selection
        public ActionResult Index()
        {
            return View();
        }

        public int Result(SelectionResult selectionResult)
        {
            int result = 0;
            return result;
        }
    }
}