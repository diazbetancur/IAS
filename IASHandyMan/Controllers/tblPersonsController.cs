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
    public class tblPersonsController : Controller
    {
        private DB_ALPHAEntities db = new DB_ALPHAEntities();

        // GET: tblPersons
        public ActionResult Index()
        {
            if ((Convert.ToInt32((Session["rol"].ToString())) == 1))
            {
                return View(LoadData());
            }
            return View("Login", "Login");
        }

        // GET: tblPersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPerson tblPerson = LoadData(id);
            if (tblPerson == null)
            {
                return HttpNotFound();
            }
            return View(tblPerson);
        }

        // GET: tblPersons/Create
        public ActionResult Create()
        {
            ViewBag.idRol = new SelectList(db.tblRoles, "id", "description");
            return View();
        }

        // POST: tblPersons/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,lastName,mail,idRol,active,idNumber")] tblPerson tblPerson)
        {
            if (ModelState.IsValid)
            {
                createUser(tblPerson);
                return RedirectToAction("Index");
            }

            ViewBag.idRol = new SelectList(db.tblRoles, "id", "description", tblPerson.idRol);
            return View(tblPerson);
        }

        // GET: tblPersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPerson tblPerson = LoadData(id);
            if (tblPerson == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRol = new SelectList(db.tblRoles, "id", "description", tblPerson.idRol);
            return View(tblPerson);
        }

        // POST: tblPersons/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,lastName,mail,idRol,active,idNumber")] tblPerson tblPerson)
        {
            if (ModelState.IsValid)
            {
                updateUser(tblPerson);
                return RedirectToAction("Index");
            }
            ViewBag.idRol = new SelectList(db.tblRoles, "id", "description", tblPerson.idRol);
            return View(tblPerson);
        }

        // GET: tblPersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPerson tblPerson = LoadData(id);
            if (tblPerson == null)
            {
                return HttpNotFound();
            }
            return View(tblPerson);
        }

        // POST: tblPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            deleteUser(id);
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

        public IEnumerable<tblPerson> LoadData()
        {
            try
            {
                var client = new RestClient("https://localhost:44322/api/Persons");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                IRestResponse response = client.Execute(request);

                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IEnumerable<tblPerson>>(response.Content);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Presentamos un problema atendiendo su solicitud, por favor intentelo un poco mas tarde.";
                return null;
            }
        }

        public tblPerson LoadData(int? id)
        {
            try
            {
                var client = new RestClient("https://localhost:44322/api/Persons/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                IRestResponse response = client.Execute(request);

                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<tblPerson>(response.Content);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Presentamos un problema atendiendo su solicitud, por favor intentelo un poco mas tarde.";
                return null;
            }
        }

        public bool createUser(tblPerson tblPerson)
        {
            try
            {
                string Result = string.Empty;
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(tblPerson);

                WebRequest request = WebRequest.Create("https://localhost:44322/api/Persons");

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

        public bool updateUser(tblPerson tblPerson)
        {
            try
            {
                string Result = string.Empty;
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(tblPerson);

                WebRequest request = WebRequest.Create("https://localhost:44322/api/Persons/" + tblPerson.id);

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

        public bool deleteUser(int? id)
        {
            try
            {
                var client = new RestClient("https://localhost:44322/api/Persons/" + id);
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
