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
    public class StraightBevelGearController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/StraightBevelGear
        public IQueryable<Gear_StraightBevelGear> GetGear_StraightBevelGear()
        {
            return db.Gear_StraightBevelGear;
        }

        // GET: api/StraightBevelGear/5
        [ResponseType(typeof(Gear_StraightBevelGear))]
        public async Task<IHttpActionResult> GetGear_StraightBevelGear(string id)
        {
            Gear_StraightBevelGear gear_StraightBevelGear = await db.Gear_StraightBevelGear.FindAsync(id);
            if (gear_StraightBevelGear == null)
            {
                return NotFound();
            }

            return Ok(gear_StraightBevelGear);
        }

        // PUT: api/StraightBevelGear/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGear_StraightBevelGear(string id, Gear_StraightBevelGear gear_StraightBevelGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gear_StraightBevelGear.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(gear_StraightBevelGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Gear_StraightBevelGearExists(id))
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

        // POST: api/StraightBevelGear
        [ResponseType(typeof(Gear_StraightBevelGear))]
        public async Task<IHttpActionResult> PostGear_StraightBevelGear(Gear_StraightBevelGear gear_StraightBevelGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gear_StraightBevelGear.Add(gear_StraightBevelGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Gear_StraightBevelGearExists(gear_StraightBevelGear.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gear_StraightBevelGear.TypeNo }, gear_StraightBevelGear);
        }

        // DELETE: api/StraightBevelGear/5
        [ResponseType(typeof(Gear_StraightBevelGear))]
        public async Task<IHttpActionResult> DeleteGear_StraightBevelGear(string id)
        {
            Gear_StraightBevelGear gear_StraightBevelGear = await db.Gear_StraightBevelGear.FindAsync(id);
            if (gear_StraightBevelGear == null)
            {
                return NotFound();
            }

            db.Gear_StraightBevelGear.Remove(gear_StraightBevelGear);
            await db.SaveChangesAsync();

            return Ok(gear_StraightBevelGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Gear_StraightBevelGearExists(string id)
        {
            return db.Gear_StraightBevelGear.Count(e => e.TypeNo == id) > 0;
        }
    }
}