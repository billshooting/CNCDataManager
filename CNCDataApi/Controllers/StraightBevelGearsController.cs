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
using CNCDataManager.Models;

namespace CNCDataManager.Controllers
{
    public class StraightBevelGearsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/StraightBevelGears
        public IQueryable<StraightBevelGear> GetStraightBevelGears()
        {
            return db.StraightBevelGears;
        }

        // GET: api/StraightBevelGears/5
        [ResponseType(typeof(StraightBevelGear))]
        public async Task<IHttpActionResult> GetStraightBevelGear(string id)
        {
            StraightBevelGear straightBevelGear = await db.StraightBevelGears.FindAsync(id);
            if (straightBevelGear == null)
            {
                return NotFound();
            }

            return Ok(straightBevelGear);
        }

        // PUT: api/StraightBevelGears/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStraightBevelGear(string id, StraightBevelGear straightBevelGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != straightBevelGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(straightBevelGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StraightBevelGearExists(id))
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

        // POST: api/StraightBevelGears
        [ResponseType(typeof(StraightBevelGear))]
        public async Task<IHttpActionResult> PostStraightBevelGear(StraightBevelGear straightBevelGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StraightBevelGears.Add(straightBevelGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StraightBevelGearExists(straightBevelGear.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = straightBevelGear.TypeID }, straightBevelGear);
        }

        // DELETE: api/StraightBevelGears/5
        [ResponseType(typeof(StraightBevelGear))]
        public async Task<IHttpActionResult> DeleteStraightBevelGear(string id)
        {
            StraightBevelGear straightBevelGear = await db.StraightBevelGears.FindAsync(id);
            if (straightBevelGear == null)
            {
                return NotFound();
            }

            db.StraightBevelGears.Remove(straightBevelGear);
            await db.SaveChangesAsync();

            return Ok(straightBevelGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StraightBevelGearExists(string id)
        {
            return db.StraightBevelGears.Count(e => e.TypeID == id) > 0;
        }
    }
}