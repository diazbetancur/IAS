using IASHandyMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IASHandyMan.Controllers
{
    public class LoginController : Controller
    {

        private Employee employee = new Employee();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee loginDataModel)
        {
            if (ModelState.IsValid)
            {
                // AQUÍ EL CÓDIGO DE VALIDACIÓN DEL USUARIO
                //WebService.Login login = new WebService.Login();
                //if ( login.validarEmpleado(loginDataModel ).Equals("1"))
                //{

                //}

                return RedirectToAction("LoginOk");
            }
            else
            {
                return View(loginDataModel);
            }
        }
    }
}