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
using bmsAPI.Models;

namespace bmsAPI.Controllers
{
    public class MangrTransectionsController : ApiController
    {
        private bmsAPIDbContext db = new bmsAPIDbContext();

        // GET: api/MangrTransections
        [Route("api/Managers/Transection")]
        public IQueryable<MangrTransection> GetMangrTransections()
        {
            return db.MangrTransections;
        }

        [Route("api/Managers/Transection/{id}")]
        // GET: api/MangrTransections/5
        [ResponseType(typeof(MangrTransection))]
        public IHttpActionResult GetMangrTransection(int id)
        {
            MangrTransection mangrTransection = db.MangrTransections.Find(id);
            if (mangrTransection == null)
            {
                return NotFound();
            }

            return Ok(mangrTransection);
        }
        [Route("api/Managers/Transection/{id}")]
        // PUT: api/MangrTransections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMangrTransection(int id, MangrTransection mangrTransection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mangrTransection.Id)
            {
                return BadRequest();
            }

            db.Entry(mangrTransection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MangrTransectionExists(id))
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

        // POST: api/MangrTransections
        [Route("api/Managers/Transection")]
        [ResponseType(typeof(MangrTransection))]
        public IHttpActionResult PostMangrTransection(MangrTransection mangrTransection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MangrTransections.Add(mangrTransection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mangrTransection.Id }, mangrTransection);
        }

        // DELETE: api/MangrTransections/5
        [Route("api/Managers/Transection/{id}")]
        [ResponseType(typeof(MangrTransection))]
        public IHttpActionResult DeleteMangrTransection(int id)
        {
            MangrTransection mangrTransection = db.MangrTransections.Find(id);
            if (mangrTransection == null)
            {
                return NotFound();
            }

            db.MangrTransections.Remove(mangrTransection);
            db.SaveChanges();

            return Ok(mangrTransection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MangrTransectionExists(int id)
        {
            return db.MangrTransections.Count(e => e.Id == id) > 0;
        }
    }
}