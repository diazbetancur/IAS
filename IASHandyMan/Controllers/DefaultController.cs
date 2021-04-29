using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPHA.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Default()
        {
            ViewBag.Title = "Inicio";
            return View();
        }
    }
}