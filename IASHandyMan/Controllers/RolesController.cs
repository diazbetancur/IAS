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
    public class RolesController : ApiController
    {
        private DB_ALPHAEntities db = new DB_ALPHAEntities();

        // GET: api/Roles
        public IQueryable<tblRoles> GettblRoles()
        {
            return db.tblRoles;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(tblRoles))]
        public IHttpActionResult GettblRoles(int id)
        {
            tblRoles tblRoles = db.tblRoles.Find(id);
            if (tblRoles == null)
            {
                return NotFound();
            }

            return Ok(tblRoles);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblRoles(int id, tblRoles tblRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblRoles.id)
            {
                return BadRequest();
            }

            db.Entry(tblRoles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblRolesExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(tblRoles))]
        public IHttpActionResult PosttblRoles(tblRoles tblRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblRoles.Add(tblRoles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblRoles.id }, tblRoles);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(tblRoles))]
        public IHttpActionResult DeletetblRoles(int id)
        {
            tblRoles tblRoles = db.tblRoles.Find(id);
            if (tblRoles == null)
            {
                return NotFound();
            }

            db.tblRoles.Remove(tblRoles);
            db.SaveChanges();

            return Ok(tblRoles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblRolesExists(int id)
        {
            return db.tblRoles.Count(e => e.id == id) > 0;
        }
    }
}