using IASHandyMan.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IASHandyMan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string dato = DBConexion.GetLogin(11, "HolaMundo");
            //Login.ServiceRegisterTimeClient obj = new Login.ServiceRegisterTimeClient();

            //dato  =  obj.validarEmpleado();

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
