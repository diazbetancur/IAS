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
    public class PersonsController : ApiController
    {
        private DB_ALPHAEntities db = new DB_ALPHAEntities();

        // GET: api/Persons
        public IQueryable<tblPerson> GettblPerson()
        {
            return db.tblPerson;
        }

        // GET: api/Persons/5
        [ResponseType(typeof(tblPerson))]
        public IHttpActionResult GettblPerson(int id)
        {
            tblPerson tblPerson = db.tblPerson.Find(id);
            if (tblPerson == null)
            {
                return NotFound();
            }

            return Ok(tblPerson);
        }

        // PUT: api/Persons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblPerson(int id, tblPerson tblPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPerson.id)
            {
                return BadRequest();
            }

            db.Entry(tblPerson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPersonExists(id))
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

        // POST: api/Persons
        [ResponseType(typeof(tblPerson))]
        public IHttpActionResult PosttblPerson(tblPerson tblPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblPerson.Add(tblPerson);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblPerson.id }, tblPerson);
        }

        // DELETE: api/Persons/5
        [ResponseType(typeof(tblPerson))]
        public IHttpActionResult DeletetblPerson(int id)
        {
            tblPerson tblPerson = db.tblPerson.Find(id);
            if (tblPerson == null)
            {
                return NotFound();
            }

            db.tblPerson.Remove(tblPerson);
            db.SaveChanges();

            return Ok(tblPerson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblPersonExists(int id)
        {
            return db.tblPerson.Count(e => e.id == id) > 0;
        }
    }
}