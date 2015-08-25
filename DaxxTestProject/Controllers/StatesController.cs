using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DaxxTestProject.Models;
using DaxxTestProject.DAL;

namespace DaxxTestProject.Controllers
{
    public class StatesController : ApiController
    {
        private RegistrationContext db = new RegistrationContext();

        // GET api/States
        public IQueryable<State> GetStates()
        {
            return db.States;
        }

        [HttpGet]
        public IQueryable<State> GetState(int id)
        {
            return db.States.Where(state => state.CountryId == id);
        }

        // PUT api/States/5
        public async Task<IHttpActionResult> PutState(int id, State state)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != state.Id)
            {
                return BadRequest();
            }

            db.Entry(state).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
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

        // POST api/States
        [ResponseType(typeof(State))]
        public async Task<IHttpActionResult> PostState(State state)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.States.Add(state);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = state.Id }, state);
        }

        // DELETE api/States/5
        [ResponseType(typeof(State))]
        public async Task<IHttpActionResult> DeleteState(int id)
        {
            State state = await db.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            db.States.Remove(state);
            await db.SaveChangesAsync();

            return Ok(state);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StateExists(int id)
        {
            return db.States.Count(e => e.Id == id) > 0;
        }
    }
}