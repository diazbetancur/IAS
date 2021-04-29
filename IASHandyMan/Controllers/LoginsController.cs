using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ALPHA.Models;
using RestSharp;

namespace ALPHA.Controllers
{
    public class LoginsController : Controller
    {
        private DB_ALPHAEntities db = new DB_ALPHAEntities();

        // GET: Logins
        public ActionResult Index()
        {
            if ((Convert.ToInt32((Session["rol"].ToString())) == 1))
            {
                return View(LoadData());
            }
            return View("Login", "Login");
        }

        // GET: Logins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLogin tblLogin = LoadData(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // GET: Logins/Create
        public ActionResult Create()
        {
            ViewBag.idPerson = new SelectList(db.tblPerson.Where(x=> x.idRol != 4), "id", "name");
            return View();
        }

        // POST: Logins/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userName,pwd,idPerson")] tblLogin tblLogin)
        {
            if (ModelState.IsValid)
            {
                createLogin(tblLogin);
                return RedirectToAction("Index");
            }

            ViewBag.idPerson = new SelectList(db.tblPerson, "id", "name", tblLogin.idPerson);
            return View(tblLogin);
        }

        // GET: Logins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLogin tblLogin = LoadData(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPerson = new SelectList(db.tblPerson, "id", "name", tblLogin.idPerson);
            return View(tblLogin);
        }

        // POST: Logins/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userName,pwd,idPerson")] tblLogin tblLogin)
        {
            if (ModelState.IsValid)
            {
                updateLogin(tblLogin);
                return RedirectToAction("Index");
            }
            ViewBag.idPerson = new SelectList(db.tblPerson, "id", "name", tblLogin.idPerson);
            return View(tblLogin);
        }

        // GET: Logins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLogin tblLogin = LoadData(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            deleteLogin(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public IEnumerable<tblLogin> LoadData()
        {
            try
            {
                var client = new RestClient("https://localhost:44322/api/tblLogins");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                IRestResponse response = client.Execute(request);

                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IEnumerable<tblLogin>>(response.Content);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Presentamos un problema atendiendo su solicitud, por favor intentelo un poco mas tarde.";
                return null;
            }
        }

        public tblLogin LoadData(string id)
        {
            try
            {
                var client = new RestClient("https://localhost:44322/api/tblLogins/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                IRestResponse response = client.Execute(request);

                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<tblLogin>(response.Content);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Presentamos un problema atendiendo su solicitud, por favor intentelo un poco mas tarde.";
                return null;
            }
        }

        public bool createLogin(tblLogin tblLogin)
        {
            try
            {
                string Result = string.Empty;
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(tblLogin);

                WebRequest request = WebRequest.Create("https://localhost:44322/api/tblLogins");

                request.Method = "POST";
                request.ContentType = "application/json;charset=utf-8";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    Result = streamReader.ReadToEnd();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateLogin(tblLogin tblLogin)
        {
            try
            {
                string Result = string.Empty;
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(tblLogin);

                WebRequest request = WebRequest.Create("https://localhost:44322/api/tblLogins/" + tblLogin.userName);

                request.Method = "PUT";
                request.ContentType = "application/json;charset=utf-8";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    Result = streamReader.ReadToEnd();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteLogin(string id)
        {
            try
            {
                var client = new RestClient("https://localhost:44322/api/tblLogins/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                IRestResponse response = client.Execute(request);

                return true;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Presentamos un problema atendiendo su solicitud, por favor intentelo un poco mas tarde.";
                return false;
            }
        }
    }
}
