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
using LinkarServer.Models;

namespace LinkarServer.Controllers
{
    public class LinkController : ApiController
    {
        private LinkarServerContext db = new LinkarServerContext();

        // GET /Link
        public IQueryable<Link> GetLinks()
        {
            return db.Links;
        }

        // GET /Link/5
        [ResponseType(typeof(Link))]
        public IHttpActionResult GetLink(int id)
        {
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            return Ok(link);
        }

        // PUT /Link/5
        public IHttpActionResult PutLink(int id, Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != link.LinkId)
            {
                return BadRequest();
            }

            db.Entry(link).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(id))
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

        // POST /Link
        [ResponseType(typeof(Link))]
        public IHttpActionResult PostLink(Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Links.Add(link);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = link.LinkId }, link);
        }

        // DELETE /Link/5
        [ResponseType(typeof(Link))]
        public IHttpActionResult DeleteLink(int id)
        {
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            db.Links.Remove(link);
            db.SaveChanges();

            return Ok(link);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinkExists(int id)
        {
            return db.Links.Count(e => e.LinkId == id) > 0;
        }
    }
}