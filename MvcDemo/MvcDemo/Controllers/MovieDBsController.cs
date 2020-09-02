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
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class MovieDBsController : ApiController
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: api/MovieDBs
        public IQueryable<MovieDB> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/MovieDBs/5
        [ResponseType(typeof(MovieDB))]
        public IHttpActionResult GetMovieDB(int id)
        {
            MovieDB movieDB = db.Movies.Find(id);
            if (movieDB == null)
            {
                return NotFound();
            }

            return Ok(movieDB);
        }

        // PUT: api/MovieDBs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovieDB(int id, MovieDB movieDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieDB.ID)
            {
                return BadRequest();
            }

            db.Entry(movieDB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieDBExists(id))
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

        // POST: api/MovieDBs
        [ResponseType(typeof(MovieDB))]
        public IHttpActionResult PostMovieDB(MovieDB movieDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movieDB);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movieDB.ID }, movieDB);
        }

        // DELETE: api/MovieDBs/5
        [ResponseType(typeof(MovieDB))]
        public IHttpActionResult DeleteMovieDB(int id)
        {
            MovieDB movieDB = db.Movies.Find(id);
            if (movieDB == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movieDB);
            db.SaveChanges();

            return Ok(movieDB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieDBExists(int id)
        {
            return db.Movies.Count(e => e.ID == id) > 0;
        }
    }
}