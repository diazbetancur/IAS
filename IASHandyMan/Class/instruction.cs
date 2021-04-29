using ALPHA.Models.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace ALPHA.Class
{
    public class instruction
    {
        public static string InsertDocument ( Models.Request.Document document)
        {
            try
            {
                byte[] file = File.ReadAllBytes ( document.pathFile);

                SqlParameter outPut = new SqlParameter("@result", SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output };

                string result = string.Empty;
                using (Models.DB_ALPHAEntities db = new Models.DB_ALPHAEntities())
                {
                    object[] xparams = {
                new SqlParameter("@IdSender", document.idSender),
                    new SqlParameter("@idReceiver", document.idReceiver),
                    new SqlParameter("@Type", Convert.ToBoolean(document.typeDocument)),
                    new SqlParameter("@name", document.nameFile),
                    new SqlParameter("@realName", document.realName),
                    new SqlParameter("@fileExt", file),
                    outPut};

                    var info = db.Database.ExecuteSqlCommand("exec [dbo].[SP_InsertDocument] @IdSender, @idReceiver, @Type, @name, @realName, @fileExt, @result output", xparams);

                }

                return outPut.Value.ToString();
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public static List<Document> ListDocument (string user)
        {
            try
            {
                List<Document> lstDocument = new List<Document>();

                using (Models.DB_ALPHAEntities db = new Models.DB_ALPHAEntities())
                {
                    object[] xparams = {
                new SqlParameter("@User", user) };

                    var info = db.Database.ExecuteSqlCommand("exec [dbo].[SP_GetDocument] @User", xparams);



                }

                return lstDocument;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}