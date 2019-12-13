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
    public class ManSalariesController : ApiController
    {
        private bmsAPIDbContext db = new bmsAPIDbContext();

        // GET: api/ManSalaries
        public IQueryable<ManSalary> GetManSalaries()
        {
            return db.ManSalaries;
        }

        // GET: api/ManSalaries/5
        [ResponseType(typeof(ManSalary))]
        public IHttpActionResult GetManSalary(int id)
        {
            ManSalary manSalary = db.ManSalaries.Find(id);
            if (manSalary == null)
            {
                return NotFound();
            }

            return Ok(manSalary);
        }

        // PUT: api/ManSalaries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManSalary(int id, ManSalary manSalary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manSalary.Id)
            {
                return BadRequest();
            }

            db.Entry(manSalary).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManSalaryExists(id))
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

        // POST: api/ManSalaries
        [ResponseType(typeof(ManSalary))]
        public IHttpActionResult PostManSalary(ManSalary manSalary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ManSalaries.Add(manSalary);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = manSalary.Id }, manSalary);
        }

        // DELETE: api/ManSalaries/5
        [ResponseType(typeof(ManSalary))]
        public IHttpActionResult DeleteManSalary(int id)
        {
            ManSalary manSalary = db.ManSalaries.Find(id);
            if (manSalary == null)
            {
                return NotFound();
            }

            db.ManSalaries.Remove(manSalary);
            db.SaveChanges();

            return Ok(manSalary);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManSalaryExists(int id)
        {
            return db.ManSalaries.Count(e => e.Id == id) > 0;
        }
    }
}