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
    public class AligningRollerBearingController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/AligningRollerBearing
        public IQueryable<Bearings_AligningRollerBearing> GetBearings_AligningRollerBearing()
        {
            return db.Bearings_AligningRollerBearing;
        }

        // GET: api/AligningRollerBearing/5
        [ResponseType(typeof(Bearings_AligningRollerBearing))]
        public async Task<IHttpActionResult> GetBearings_AligningRollerBearing(string id)
        {
            Bearings_AligningRollerBearing bearings_AligningRollerBearing = await db.Bearings_AligningRollerBearing.FindAsync(id);
            if (bearings_AligningRollerBearing == null)
            {
                return NotFound();
            }

            return Ok(bearings_AligningRollerBearing);
        }

        // PUT: api/AligningRollerBearing/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_AligningRollerBearing(string id, Bearings_AligningRollerBearing bearings_AligningRollerBearing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_AligningRollerBearing.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_AligningRollerBearing).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_AligningRollerBearingExists(id))
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

        // POST: api/AligningRollerBearing
        [ResponseType(typeof(Bearings_AligningRollerBearing))]
        public async Task<IHttpActionResult> PostBearings_AligningRollerBearing(Bearings_AligningRollerBearing bearings_AligningRollerBearing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_AligningRollerBearing.Add(bearings_AligningRollerBearing);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_AligningRollerBearingExists(bearings_AligningRollerBearing.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_AligningRollerBearing.TypeNo }, bearings_AligningRollerBearing);
        }

        // DELETE: api/AligningRollerBearing/5
        [ResponseType(typeof(Bearings_AligningRollerBearing))]
        public async Task<IHttpActionResult> DeleteBearings_AligningRollerBearing(string id)
        {
            Bearings_AligningRollerBearing bearings_AligningRollerBearing = await db.Bearings_AligningRollerBearing.FindAsync(id);
            if (bearings_AligningRollerBearing == null)
            {
                return NotFound();
            }

            db.Bearings_AligningRollerBearing.Remove(bearings_AligningRollerBearing);
            await db.SaveChangesAsync();

            return Ok(bearings_AligningRollerBearing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_AligningRollerBearingExists(string id)
        {
            return db.Bearings_AligningRollerBearing.Count(e => e.TypeNo == id) > 0;
        }
    }
}