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
    //双向推力角接触球轴承
    public class DoubleThrustAngularContactBallBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/DoubleThrustAngularContactBallBearings
        public IQueryable<Bearings_DoubleThrustAngularContactBallBearings> GetBearings_DoubleThrustAngularContactBallBearings()
        {
            return db.Bearings_DoubleThrustAngularContactBallBearings;
        }

        // GET: api/DoubleThrustAngularContactBallBearings/5
        [ResponseType(typeof(Bearings_DoubleThrustAngularContactBallBearings))]
        public async Task<IHttpActionResult> GetBearings_DoubleThrustAngularContactBallBearings(string id)
        {
            Bearings_DoubleThrustAngularContactBallBearings bearings_DoubleThrustAngularContactBallBearings = await db.Bearings_DoubleThrustAngularContactBallBearings.FindAsync(id);
            if (bearings_DoubleThrustAngularContactBallBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_DoubleThrustAngularContactBallBearings);
        }

        // PUT: api/DoubleThrustAngularContactBallBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_DoubleThrustAngularContactBallBearings(string id, Bearings_DoubleThrustAngularContactBallBearings bearings_DoubleThrustAngularContactBallBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_DoubleThrustAngularContactBallBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_DoubleThrustAngularContactBallBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_DoubleThrustAngularContactBallBearingsExists(id))
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

        // POST: api/DoubleThrustAngularContactBallBearings
        [ResponseType(typeof(Bearings_DoubleThrustAngularContactBallBearings))]
        public async Task<IHttpActionResult> PostBearings_DoubleThrustAngularContactBallBearings(Bearings_DoubleThrustAngularContactBallBearings bearings_DoubleThrustAngularContactBallBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_DoubleThrustAngularContactBallBearings.Add(bearings_DoubleThrustAngularContactBallBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_DoubleThrustAngularContactBallBearingsExists(bearings_DoubleThrustAngularContactBallBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_DoubleThrustAngularContactBallBearings.TypeNo }, bearings_DoubleThrustAngularContactBallBearings);
        }

        // DELETE: api/DoubleThrustAngularContactBallBearings/5
        [ResponseType(typeof(Bearings_DoubleThrustAngularContactBallBearings))]
        public async Task<IHttpActionResult> DeleteBearings_DoubleThrustAngularContactBallBearings(string id)
        {
            Bearings_DoubleThrustAngularContactBallBearings bearings_DoubleThrustAngularContactBallBearings = await db.Bearings_DoubleThrustAngularContactBallBearings.FindAsync(id);
            if (bearings_DoubleThrustAngularContactBallBearings == null)
            {
                return NotFound();
            }

            db.Bearings_DoubleThrustAngularContactBallBearings.Remove(bearings_DoubleThrustAngularContactBallBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_DoubleThrustAngularContactBallBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_DoubleThrustAngularContactBallBearingsExists(string id)
        {
            return db.Bearings_DoubleThrustAngularContactBallBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}