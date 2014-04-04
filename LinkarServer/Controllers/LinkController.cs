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
        [Route("link/from/{from}/to/{to}")]
        public IHttpActionResult PostLinkFromTo([FromBody]dynamic link, string from, string to)
        {
            User fromUser = db.Users.Find(from);
            User toUser = db.Users.Find(to);

            if (fromUser == null || toUser == null)
            {
                return NotFound();
            }
            if (link == null || link.url == null)
                return BadRequest();
            String url = link.url.Value;

            return Ok();
        }
    }
}