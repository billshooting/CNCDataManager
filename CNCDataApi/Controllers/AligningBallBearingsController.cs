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
using CNCDataApi.Models;

namespace CNCDataApi.Controllers
{
    public class AligningBallBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/AligningBallBearings
        public IQueryable<Bearings_AligningBallBearings> GetBearings_AligningBallBearings()
        {
            return db.Bearings_AligningBallBearings;
        }

        // GET: api/AligningBallBearings/5
        [ResponseType(typeof(Bearings_AligningBallBearings))]
        public async Task<IHttpActionResult> GetBearings_AligningBallBearings(string id)
        {
            Bearings_AligningBallBearings bearings_AligningBallBearings = await db.Bearings_AligningBallBearings.FindAsync(id);
            if (bearings_AligningBallBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_AligningBallBearings);
        }

        // PUT: api/AligningBallBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_AligningBallBearings(string id, Bearings_AligningBallBearings bearings_AligningBallBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_AligningBallBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_AligningBallBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_AligningBallBearingsExists(id))
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

        // POST: api/AligningBallBearings
        [ResponseType(typeof(Bearings_AligningBallBearings))]
        public async Task<IHttpActionResult> PostBearings_AligningBallBearings(Bearings_AligningBallBearings bearings_AligningBallBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_AligningBallBearings.Add(bearings_AligningBallBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_AligningBallBearingsExists(bearings_AligningBallBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_AligningBallBearings.TypeNo }, bearings_AligningBallBearings);
        }

        // DELETE: api/AligningBallBearings/5
        [ResponseType(typeof(Bearings_AligningBallBearings))]
        public async Task<IHttpActionResult> DeleteBearings_AligningBallBearings(string id)
        {
            Bearings_AligningBallBearings bearings_AligningBallBearings = await db.Bearings_AligningBallBearings.FindAsync(id);
            if (bearings_AligningBallBearings == null)
            {
                return NotFound();
            }

            db.Bearings_AligningBallBearings.Remove(bearings_AligningBallBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_AligningBallBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_AligningBallBearingsExists(string id)
        {
            return db.Bearings_AligningBallBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}