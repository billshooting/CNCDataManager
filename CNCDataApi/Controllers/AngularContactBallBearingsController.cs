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
    public class AngularContactBallBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/AngularContactBallBearings
        public IQueryable<Bearings_AngularContactBallBearings> GetBearings_AngularContactBallBearings()
        {
            return db.Bearings_AngularContactBallBearings;
        }

        // GET: api/AngularContactBallBearings/5
        [ResponseType(typeof(Bearings_AngularContactBallBearings))]
        public async Task<IHttpActionResult> GetBearings_AngularContactBallBearings(string id)
        {
            Bearings_AngularContactBallBearings bearings_AngularContactBallBearings = await db.Bearings_AngularContactBallBearings.FindAsync(id);
            if (bearings_AngularContactBallBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_AngularContactBallBearings);
        }

        // PUT: api/AngularContactBallBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_AngularContactBallBearings(string id, Bearings_AngularContactBallBearings bearings_AngularContactBallBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_AngularContactBallBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_AngularContactBallBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_AngularContactBallBearingsExists(id))
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

        // POST: api/AngularContactBallBearings
        [ResponseType(typeof(Bearings_AngularContactBallBearings))]
        public async Task<IHttpActionResult> PostBearings_AngularContactBallBearings(Bearings_AngularContactBallBearings bearings_AngularContactBallBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_AngularContactBallBearings.Add(bearings_AngularContactBallBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_AngularContactBallBearingsExists(bearings_AngularContactBallBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_AngularContactBallBearings.TypeNo }, bearings_AngularContactBallBearings);
        }

        // DELETE: api/AngularContactBallBearings/5
        [ResponseType(typeof(Bearings_AngularContactBallBearings))]
        public async Task<IHttpActionResult> DeleteBearings_AngularContactBallBearings(string id)
        {
            Bearings_AngularContactBallBearings bearings_AngularContactBallBearings = await db.Bearings_AngularContactBallBearings.FindAsync(id);
            if (bearings_AngularContactBallBearings == null)
            {
                return NotFound();
            }

            db.Bearings_AngularContactBallBearings.Remove(bearings_AngularContactBallBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_AngularContactBallBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_AngularContactBallBearingsExists(string id)
        {
            return db.Bearings_AngularContactBallBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}