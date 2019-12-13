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
    public class ManNoticeBoardsController : ApiController
    {
        private bmsAPIDbContext db = new bmsAPIDbContext();

        // GET: api/ManNoticeBoards
        [Route("api/Managers/Notices")]
        public IHttpActionResult GetMannoticeBoards()
        {
            var list = db.ManNoticeBoards.ToList();
            List<ManNoticeBoard> man = new List<ManNoticeBoard>();
            foreach (var item in list)
            {
                ManNoticeBoard manNoticeBoard = new ManNoticeBoard();
                manNoticeBoard.Id = item.Id;
                manNoticeBoard.MesBody = item.MesBody;
                manNoticeBoard.Seen = item.Seen;
                manNoticeBoard.Title = item.Title;


                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers", Method = "GET", Rel = "Self" });
                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manNoticeBoard.Id, Method = "GET", Rel = "Specific Resource" });
                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manNoticeBoard.Id, Method = "PUT", Rel = "Resource Edit" });
                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manNoticeBoard.Id, Method = "DELETE", Rel = "Resource Delete" });
                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers", Method = "POST", Rel = "Resource Create" });
                man.Add(manNoticeBoard);
            }
            return Ok(man);
        }

        // GET: api/ManNoticeBoards/5
        [Route("api/Managers/Notices/{id}")]
        [ResponseType(typeof(ManNoticeBoard))]
        public IHttpActionResult GetManNoticeBoard(int id)
        {
            ManNoticeBoard item = db.ManNoticeBoards.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                ManNoticeBoard manNoticeBoard = new ManNoticeBoard();
                manNoticeBoard.Id = item.Id;
                manNoticeBoard.MesBody = item.MesBody;
                manNoticeBoard.Seen = item.Seen;
                manNoticeBoard.Title = item.Title;


                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers", Method = "GET", Rel = "Self" });
                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manNoticeBoard.Id, Method = "GET", Rel = "Specific Resource" });
                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manNoticeBoard.Id, Method = "PUT", Rel = "Resource Edit" });
                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manNoticeBoard.Id, Method = "DELETE", Rel = "Resource Delete" });
                manNoticeBoard.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers", Method = "POST", Rel = "Resource Create" });
                return Ok(manNoticeBoard);
            }

           
        }

        // PUT: api/ManNoticeBoards/5
        [Route("api/Managers/Notices/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManNoticeBoard(int id, ManNoticeBoard manNoticeBoard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manNoticeBoard.Id)
            {
                return BadRequest();
            }

            db.Entry(manNoticeBoard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManNoticeBoardExists(id))
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

        // POST: api/ManNoticeBoards
        [Route("api/Managers/Notices")]
        [ResponseType(typeof(ManNoticeBoard))]
        public IHttpActionResult PostManNoticeBoard(ManNoticeBoard manNoticeBoard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ManNoticeBoards.Add(manNoticeBoard);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = manNoticeBoard.Id }, manNoticeBoard);
        }

        // DELETE: api/ManNoticeBoards/5
        [Route("api/Managers/Notices/{id}")]
        [ResponseType(typeof(ManNoticeBoard))]
        public IHttpActionResult DeleteManNoticeBoard(int id)
        {
            ManNoticeBoard manNoticeBoard = db.ManNoticeBoards.Find(id);
            if (manNoticeBoard == null)
            {
                return NotFound();
            }

            db.ManNoticeBoards.Remove(manNoticeBoard);
            db.SaveChanges();

            return Ok(manNoticeBoard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManNoticeBoardExists(int id)
        {
            return db.ManNoticeBoards.Count(e => e.Id == id) > 0;
        }
    }
}