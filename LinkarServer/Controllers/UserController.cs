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
    public class UserController : ApiController
    {
        private LinkarServerContext db = new LinkarServerContext();

        // GET api/User
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET api/User/5
        public IHttpActionResult GetUser(string id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET api/User(5)/Friends
        [Route("user/{id}/friends")]
        public IQueryable<User> GetFriends(string id)
        {
            User user = db.Users.FirstOrDefault(u => u.username == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Entry(user).Collection(u => u.friends).Load(); 
            return user.friends.AsQueryable<User>();
        }

        // GET api/User/byChannelId/5
        [Route("user/byChannelId/{channelId}")]
        public IHttpActionResult GetByChannelId(string channelId)
        {
            User user = db.Users.FirstOrDefault(u => u.channelId == channelId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/User/5/addFriend/3
        [Route("user/{username}/addFriend/{friendId}")]
        public IHttpActionResult PostFriend(string username, string friendId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (username == friendId)
                return BadRequest();

            User user = db.Users.FirstOrDefault(u => u.username == username);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            User friend = db.Users.FirstOrDefault(u => u.username == friendId);
            if (friend == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            db.Entry(user).Collection(u => u.friends).Load();  
            if (!user.friends.Contains(friend))
                user.friends.Add(friend);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT api/User/5
        public IHttpActionResult PutUser(string id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.username)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST api/User
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.username }, user);
        }

        // DELETE api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(string id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string id)
        {
            return db.Users.Count(e => e.username == id) > 0;
        }
    }
}