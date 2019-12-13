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
    public class EmpSalariesController : ApiController
    {
        private bmsAPIDbContext db = new bmsAPIDbContext();

        // GET: api/EmpSalaries
        public IQueryable<EmpSalary> GetEmpSalaries()
        {
            return db.EmpSalaries;
        }

        // GET: api/EmpSalaries/5
        [ResponseType(typeof(EmpSalary))]
        public IHttpActionResult GetEmpSalary(int id)
        {
            EmpSalary empSalary = db.EmpSalaries.Find(id);
            if (empSalary == null)
            {
                return NotFound();
            }

            return Ok(empSalary);
        }

        // PUT: api/EmpSalaries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpSalary(int id, EmpSalary empSalary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empSalary.Id)
            {
                return BadRequest();
            }

            db.Entry(empSalary).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpSalaryExists(id))
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

        // POST: api/EmpSalaries
        [ResponseType(typeof(EmpSalary))]
        public IHttpActionResult PostEmpSalary(EmpSalary empSalary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpSalaries.Add(empSalary);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empSalary.Id }, empSalary);
        }

        // DELETE: api/EmpSalaries/5
        [ResponseType(typeof(EmpSalary))]
        public IHttpActionResult DeleteEmpSalary(int id)
        {
            EmpSalary empSalary = db.EmpSalaries.Find(id);
            if (empSalary == null)
            {
                return NotFound();
            }

            db.EmpSalaries.Remove(empSalary);
            db.SaveChanges();

            return Ok(empSalary);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpSalaryExists(int id)
        {
            return db.EmpSalaries.Count(e => e.Id == id) > 0;
        }
    }
}