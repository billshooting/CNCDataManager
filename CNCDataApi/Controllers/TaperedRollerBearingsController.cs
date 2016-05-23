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
    //圆锥滚子轴承
    public class TaperedRollerBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/TaperedRollerBearings
        public IQueryable<Bearings_TaperedRollerBearings> GetBearings_TaperedRollerBearings()
        {
            return db.Bearings_TaperedRollerBearings;
        }

        // GET: api/TaperedRollerBearings/5
        [ResponseType(typeof(Bearings_TaperedRollerBearings))]
        public async Task<IHttpActionResult> GetBearings_TaperedRollerBearings(string id)
        {
            Bearings_TaperedRollerBearings bearings_TaperedRollerBearings = await db.Bearings_TaperedRollerBearings.FindAsync(id);
            if (bearings_TaperedRollerBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_TaperedRollerBearings);
        }

        // PUT: api/TaperedRollerBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_TaperedRollerBearings(string id, Bearings_TaperedRollerBearings bearings_TaperedRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_TaperedRollerBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_TaperedRollerBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_TaperedRollerBearingsExists(id))
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

        // POST: api/TaperedRollerBearings
        [ResponseType(typeof(Bearings_TaperedRollerBearings))]
        public async Task<IHttpActionResult> PostBearings_TaperedRollerBearings(Bearings_TaperedRollerBearings bearings_TaperedRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_TaperedRollerBearings.Add(bearings_TaperedRollerBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_TaperedRollerBearingsExists(bearings_TaperedRollerBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_TaperedRollerBearings.TypeNo }, bearings_TaperedRollerBearings);
        }

        // DELETE: api/TaperedRollerBearings/5
        [ResponseType(typeof(Bearings_TaperedRollerBearings))]
        public async Task<IHttpActionResult> DeleteBearings_TaperedRollerBearings(string id)
        {
            Bearings_TaperedRollerBearings bearings_TaperedRollerBearings = await db.Bearings_TaperedRollerBearings.FindAsync(id);
            if (bearings_TaperedRollerBearings == null)
            {
                return NotFound();
            }

            db.Bearings_TaperedRollerBearings.Remove(bearings_TaperedRollerBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_TaperedRollerBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_TaperedRollerBearingsExists(string id)
        {
            return db.Bearings_TaperedRollerBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}