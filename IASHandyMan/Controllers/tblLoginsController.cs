using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ALPHA.Models;

namespace ALPHA.Controllers
{
    public class tblLoginsController : ApiController
    {
        private DB_ALPHAEntities db = new DB_ALPHAEntities();

        // GET: api/tblLogins
        public IQueryable<tblLogin> GettblLogin()
        {
            return db.tblLogin;
        }

        // GET: api/tblLogins/5
        [ResponseType(typeof(tblLogin))]
        public IHttpActionResult GettblLogin(string id)
        {
            tblLogin tblLogin = db.tblLogin.Find(id);
            if (tblLogin == null)
            {
                return NotFound();
            }

            return Ok(tblLogin);
        }

        // PUT: api/tblLogins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblLogin(string id, tblLogin tblLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblLogin.userName)
            {
                return BadRequest();
            }

            db.Entry(tblLogin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblLoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tblLogins
        [ResponseType(typeof(tblLogin))]
        public IHttpActionResult PosttblLogin(tblLogin tblLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblLogin.Add(tblLogin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblLoginExists(tblLogin.userName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblLogin.userName }, tblLogin);
        }

        // DELETE: api/tblLogins/5
        [ResponseType(typeof(tblLogin))]
        public IHttpActionResult DeletetblLogin(string id)
        {
            tblLogin tblLogin = db.tblLogin.Find(id);
            if (tblLogin == null)
            {
                return NotFound();
            }

            db.tblLogin.Remove(tblLogin);
            db.SaveChanges();

            return Ok(tblLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblLoginExists(string id)
        {
            return db.tblLogin.Count(e => e.userName == id) > 0;
        }
    }
}