using System;
using System.Collections.Generic;
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
    public class MdController : ApiController
    {
        private bmsAPIDbContext db = new bmsAPIDbContext();

        [Route("api/Md/Manager/Salaries")]              //all salary info managers
        public IQueryable<ManSalary> GetManSalaries()
        {
            return db.ManSalaries;
        }


        [Route("api/Md/Manager/{id}/Salary")]           //GET managers all salary info by manager id
        public IHttpActionResult GetManSalariesById(int id)
        {
           List<ManSalary> ms = db.ManSalaries.Where(c=>c.ManagerId == id).ToList();
            if (ms == null)
            {
                return NotFound();
            }

            return Ok(ms);
        }
        [Route("api/Md/Manager/Salary")]        //give manager salary
        [ResponseType(typeof(ManSalary))]
        public IHttpActionResult PostManSalary(ManSalary manSalary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Manager man = db.Managers.Find(manSalary.ManagerId);
            man.Salary = man.Salary + manSalary.SalaryAmn;

            db.ManSalaries.Add(manSalary);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = manSalary.Id }, manSalary);
        }

        [Route("api/Md/Manager/Salary/{id}")] // DELETE manager salary by salary transection id
        [ResponseType(typeof(ManSalary))]
        public IHttpActionResult DeleteManSalary(int id)
        {
            ManSalary manSalary = db.ManSalaries.Find(id);
            if (manSalary == null)
            {
                return NotFound();
            }
            Manager man = new Manager();
            man = db.Managers.Find(manSalary.ManagerId);
            man.Salary = man.Salary - manSalary.SalaryAmn;

            db.ManSalaries.Remove(manSalary);
            db.SaveChanges();

            return Ok(manSalary);
        }

        


        [Route("api/Md/TopBranch/{count}")]     //GET top branch by transections
        public IQueryable<Branch> GetTopBranches(int count)
        {
            
            return db.Branches.OrderByDescending(c => c.Balance).Take(count); 
        }






        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
        
        private bool ManagerExists(int id)
        {
            return db.Managers.Count(e => e.Id == id) > 0;
        }
    }
}
