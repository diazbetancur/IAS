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
using MySqlX.XDevAPI.Common;
using RestSharp;

namespace ALPHA.Controllers
{
    public class tblRolesController : Controller
    {
        private DB_ALPHAEntities db = new DB_ALPHAEntities();

        // GET: tblRoles
        public ActionResult Index()
        {
            if ((Convert.ToInt32((Session["rol"].ToString())) == 1))
            {
                return View(LoadData());
            }
            return View("Login","Login");
        }

        // GET: tblRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRoles tblRoles = LoadData(id);

            if (tblRoles == null)
            {
                return HttpNotFound();
            }
            return View(tblRoles);
        }

        // GET: tblRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description,permisionDescription")] tblRoles tblRoles)
        {
            if (ModelState.IsValid)
            {
                createRol(tblRoles);
                return RedirectToAction("Index");
            }

            return View(tblRoles);
        }

        // GET: tblRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRoles tblRoles = LoadData(id);
            return View(tblRoles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,permisionDescription")] tblRoles tblRoles)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tblRoles).State = EntityState.Modified;
                //db.SaveChanges();
                updateRol(tblRoles);
                return RedirectToAction("Index");
            }
            return View(tblRoles);
        }

        // GET: tblRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRoles tblRoles = LoadData(id);
            if (tblRoles == null)
            {
                return HttpNotFound();
            }
            return View(tblRoles);
        }

        // POST: tblRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRoles tblRoles = db.tblRoles.Find(id);
            db.tblRoles.Remove(tblRoles);
            db.SaveChanges();
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

        public IEnumerable<tblRoles> LoadData ()
        {
            try
            {
                var client = new RestClient("https://localhost:44322/api/Roles");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                IRestResponse response = client.Execute(request);

                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IEnumerable<tblRoles>>(response.Content);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Presentamos un problema atendiendo su solicitud, por favor intentelo un poco mas tarde.";
                return null;
            }
        }

        public tblRoles LoadData(int? id)
        {
            try
            {
                var client = new RestClient("https://localhost:44322/api/Roles/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                IRestResponse response = client.Execute(request);

                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<tblRoles>(response.Content);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Presentamos un problema atendiendo su solicitud, por favor intentelo un poco mas tarde.";
                return null;
            }
        }

        public bool createRol(tblRoles tblRoles)
        {
            try
            {
                string Result = string.Empty;
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(tblRoles);

                WebRequest request = WebRequest.Create("https://localhost:44322/api/Roles");

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

        public bool updateRol(tblRoles tblRoles)
        {
            try
            {
                string Result = string.Empty;
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(tblRoles);

                WebRequest request = WebRequest.Create("https://localhost:44322/api/Roles/" + tblRoles.id);

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

        public bool deleteRol(int? id)
        {
            try
            {
                var client = new RestClient("https://localhost:44322/api/Roles/" + id);
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
