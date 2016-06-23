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

namespace CNCDataApi.Controller
{
    public class StraightBevelGearsController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/StraightBevelGears
        public IQueryable<StraightBevelGear> GetStraightBevelGear()
        {
            return db.StraightBevelGear;
        }

        // GET: api/StraightBevelGears/5
        [ResponseType(typeof(StraightBevelGear))]
        public async Task<IHttpActionResult> GetStraightBevelGear(string id)
        {
            StraightBevelGear straightBevelGear = await db.StraightBevelGear.FindAsync(id);
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

            db.StraightBevelGear.Add(straightBevelGear);

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
            StraightBevelGear straightBevelGear = await db.StraightBevelGear.FindAsync(id);
            if (straightBevelGear == null)
            {
                return NotFound();
            }

            db.StraightBevelGear.Remove(straightBevelGear);
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
            return db.StraightBevelGear.Count(e => e.TypeID == id) > 0;
        }
    }
}