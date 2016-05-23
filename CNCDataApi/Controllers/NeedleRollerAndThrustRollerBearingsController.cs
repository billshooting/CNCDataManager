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
    //滚针轴承和推力滚子组合轴承
    public class NeedleRollerAndThrustRollerBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/NeedleRollerAndThrustRollerBearings
        public IQueryable<Bearings_NeedleRollerAndThrustRollerBearings> GetBearings_NeedleRollerAndThrustRollerBearings()
        {
            return db.Bearings_NeedleRollerAndThrustRollerBearings;
        }

        // GET: api/NeedleRollerAndThrustRollerBearings/5
        [ResponseType(typeof(Bearings_NeedleRollerAndThrustRollerBearings))]
        public async Task<IHttpActionResult> GetBearings_NeedleRollerAndThrustRollerBearings(string id)
        {
            Bearings_NeedleRollerAndThrustRollerBearings bearings_NeedleRollerAndThrustRollerBearings = await db.Bearings_NeedleRollerAndThrustRollerBearings.FindAsync(id);
            if (bearings_NeedleRollerAndThrustRollerBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_NeedleRollerAndThrustRollerBearings);
        }

        // PUT: api/NeedleRollerAndThrustRollerBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_NeedleRollerAndThrustRollerBearings(string id, Bearings_NeedleRollerAndThrustRollerBearings bearings_NeedleRollerAndThrustRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_NeedleRollerAndThrustRollerBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_NeedleRollerAndThrustRollerBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_NeedleRollerAndThrustRollerBearingsExists(id))
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

        // POST: api/NeedleRollerAndThrustRollerBearings
        [ResponseType(typeof(Bearings_NeedleRollerAndThrustRollerBearings))]
        public async Task<IHttpActionResult> PostBearings_NeedleRollerAndThrustRollerBearings(Bearings_NeedleRollerAndThrustRollerBearings bearings_NeedleRollerAndThrustRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_NeedleRollerAndThrustRollerBearings.Add(bearings_NeedleRollerAndThrustRollerBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_NeedleRollerAndThrustRollerBearingsExists(bearings_NeedleRollerAndThrustRollerBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_NeedleRollerAndThrustRollerBearings.TypeNo }, bearings_NeedleRollerAndThrustRollerBearings);
        }

        // DELETE: api/NeedleRollerAndThrustRollerBearings/5
        [ResponseType(typeof(Bearings_NeedleRollerAndThrustRollerBearings))]
        public async Task<IHttpActionResult> DeleteBearings_NeedleRollerAndThrustRollerBearings(string id)
        {
            Bearings_NeedleRollerAndThrustRollerBearings bearings_NeedleRollerAndThrustRollerBearings = await db.Bearings_NeedleRollerAndThrustRollerBearings.FindAsync(id);
            if (bearings_NeedleRollerAndThrustRollerBearings == null)
            {
                return NotFound();
            }

            db.Bearings_NeedleRollerAndThrustRollerBearings.Remove(bearings_NeedleRollerAndThrustRollerBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_NeedleRollerAndThrustRollerBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_NeedleRollerAndThrustRollerBearingsExists(string id)
        {
            return db.Bearings_NeedleRollerAndThrustRollerBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}