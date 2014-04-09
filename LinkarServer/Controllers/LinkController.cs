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

        // POST /Link/from/:from/to/:to
        [Route("link/")]
        public IHttpActionResult PostLinkFromTo(Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User fromUser = db.Users.Find(link.from);
            User toUser = db.Users.Find(link.to);

            if (fromUser == null || toUser == null)
            {
                return NotFound();
            }
            String url = link.url;

            return Ok();
        }
    }
}