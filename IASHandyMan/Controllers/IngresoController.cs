using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ALPHA.Controllers
{
    public class IngresoController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(Models.Request.Employee model)
        {
            try
            {
                string result = string.Empty;
                using (Models.DB_ALPHAEntities db = new Models.DB_ALPHAEntities())
                {
                    SqlParameter outPut = new SqlParameter("@result", SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output };

                    object[] xparams = {
                new SqlParameter("@User", model.user),
                new SqlParameter("@pwd", model.pass),
                outPut };

                    db.Database.ExecuteSqlCommand("exec [dbo].[SP_Login] @User, @pwd, @result output", xparams);

                    result = outPut.Value.ToString();

                }
                return Ok(result);
            }
            catch (Exception Ex)
            {
                return Ok(Ex.Message);
            }           
        }
    }
}
