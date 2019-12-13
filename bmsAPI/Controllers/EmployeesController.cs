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
    public class EmployeesController : ApiController
    {
        private bmsAPIDbContext db = new bmsAPIDbContext();

        // GET: api/Employees
        public IHttpActionResult GetEmployees()
        {
            var list = db.Employees.ToList();
            List<Employee> emp = new List<Employee>();
            foreach (var item in list)
            {
                Employee employee = new Employee();
                employee.Id = item.Id;
                employee.Salary = item.Salary;
                employee.BranchId = item.BranchId;
                employee.DateOfBirth = item.DateOfBirth;
                employee.Email = item.Email;
                employee.Gender = item.Gender;
                employee.JoinDate = item.JoinDate;
                employee.EmpPoints = item.EmpPoints;
                employee.NID = item.NID;
                employee.Name = item.Name;
                employee.Password = item.Password;
                employee.PhoneNumber = item.PhoneNumber;

                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees", Method = "GET", Rel = "Self" });
                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees/" + employee.Id, Method = "GET", Rel = "Specific Resource" });
                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees/" + employee.Id, Method = "PUT", Rel = "Resource Edit" });
                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees/" + employee.Id, Method = "DELETE", Rel = "Resource Delete" });
                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees", Method = "POST", Rel = "Resource Create" });
                emp.Add(employee);
            }
            return Ok(emp);
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee item = db.Employees.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Employee employee = new Employee();
                employee.Id = item.Id;
                employee.Salary = item.Salary;
                employee.BranchId = item.BranchId;
                employee.DateOfBirth = item.DateOfBirth;
                employee.Email = item.Email;
                employee.Gender = item.Gender;
                employee.JoinDate = item.JoinDate;
                employee.EmpPoints = item.EmpPoints;
                employee.NID = item.NID;
                employee.Name = item.Name;
                employee.Password = item.Password;
                employee.PhoneNumber = item.PhoneNumber;

                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees", Method = "GET", Rel = "Self" });
                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees/" + employee.Id, Method = "GET", Rel = "Specific Resource" });
                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees/" + employee.Id, Method = "PUT", Rel = "Resource Edit" });
                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees/" + employee.Id, Method = "DELETE", Rel = "Resource Delete" });
                employee.links.Add(new Links() { HRef = "http://localhost:63961/api/Md/Employees", Method = "POST", Rel = "Resource Create" });
                return Ok(employee);
            }


        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
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
    }
}