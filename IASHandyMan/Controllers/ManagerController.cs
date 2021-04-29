using ALPHA.Class;
using ALPHA.Models.Request;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ALPHA.Controllers
{
    public class ManagerController : Controller
    {
        public Document document = new Document();
        public List<People> lstpeople = new List<People>();
        // GET: Manager
        public ActionResult Manager()
        {
            if ((Convert.ToInt32((Session["rol"].ToString())) == 2) || (Convert.ToInt32((Session["rol"].ToString())) == 1))
            {
                return View();
            }
            else
            {
                return View("Login", "Login");
            }
            
        }

        [HttpPost]
        public ActionResult Manager(Document DocumentDataModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DocumentDataModel.realName = Path.GetFileNameWithoutExtension(DocumentDataModel.documentFile.FileName)
                    + Path.GetExtension(DocumentDataModel.documentFile.FileName);

                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), DocumentDataModel.realName);
                    //DocumentDataModel.documentFile.SaveAs(_path);
                    DocumentDataModel.pathFile = _path;
                    //DocumentDataModel.pathFile = Path.GetFullPath(DocumentDataModel.documentFile.FileName);
                    string resutl = instruction.InsertDocument(DocumentDataModel);
                    if (resutl.Trim().Replace("\"","").Split('|').Count() > 1)
                    {
                        ViewBag.ErrorMessage = resutl.Trim().Replace("\"", "").Split('|')[1];
                        return View();
                    }
                    ViewBag.ErrorMessage = "Información Cargada Exitosamente " + resutl.Trim().Replace("\"", "");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMessage = "Ocurrio un error inesperado, por favor intentelo mas tarde.";
                return View();
            }

            return View();
        }

    }
}