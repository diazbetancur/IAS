using ALPHA.Models.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ALPHA.Controllers
{
    public class LoginController : Controller
    {

        private Employee employee = new Employee();
        public string message = string.Empty;
        // GET: Login
        public ActionResult Login()
        {
            Session["user"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee loginDataModel)
        {
            if (ModelState.IsValid)
            {
                if (validLogin(loginDataModel))
                {                 
                    Session["rol"] = loginDataModel.idRol;
                    Session["user"] = loginDataModel.user;
                    return RedirectToAction("Default", "Default");
                }                    
                else
                {
                    ViewBag.ErrorMessage = message;
                    return View();
                }
            }
            else
            {
                return View(loginDataModel);
            }
        }

        public bool validLogin (Employee employee)
        {
            string result = string.Empty;

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);

                WebRequest request = WebRequest.Create("https://localhost:44322/api/Ingreso");

                request.Method = "POST";
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                if (result.Split('|').Count() > 1)
                {
                    message = result.Replace("\"", "").Split('|')[1];
                    return false;
                }
                employee.idRol = Convert.ToInt32(result.Trim().Replace("\"",""));
                return true;
            }
            catch (Exception Ex)
            {
                message = "SE ha presentado un error, por favor intentelo mas tarde";
                return false;
            }
        }
    }
}