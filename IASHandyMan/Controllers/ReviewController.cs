using ALPHA.Class;
using ALPHA.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPHA.Controllers
{
    public class ReviewController : Controller
    {
        public Documents lstDocument;
        // GET: Review
        public ActionResult Review()
        {
            if ((Convert.ToInt32((Session["rol"].ToString())) == 4))
            {
                return View("Login", "Login");
            }

            if ((Session["user"] as Employee).idRol == 3)
            {
                lstDocument = new Documents();
                instruction.ListDocument((Session["user"] as Employee).user);
            }
            
            return View(lstDocument);
        }

        public void getDocuments()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}