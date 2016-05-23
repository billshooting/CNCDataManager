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
    public class SpurGearController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/SpurGear
        public IQueryable<Gear_SpurGear> GetGear_SpurGear()
        {
            return db.Gear_SpurGear;
        }

        // GET: api/SpurGear/5
        [ResponseType(typeof(Gear_SpurGear))]
        public async Task<IHttpActionResult> GetGear_SpurGear(string id)
        {
            Gear_SpurGear gear_SpurGear = await db.Gear_SpurGear.FindAsync(id);
            if (gear_SpurGear == null)
            {
                return NotFound();
            }

            return Ok(gear_SpurGear);
        }

        // PUT: api/SpurGear/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGear_SpurGear(string id, Gear_SpurGear gear_SpurGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gear_SpurGear.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(gear_SpurGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Gear_SpurGearExists(id))
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

        // POST: api/SpurGear
        [ResponseType(typeof(Gear_SpurGear))]
        public async Task<IHttpActionResult> PostGear_SpurGear(Gear_SpurGear gear_SpurGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gear_SpurGear.Add(gear_SpurGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Gear_SpurGearExists(gear_SpurGear.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gear_SpurGear.TypeNo }, gear_SpurGear);
        }

        // DELETE: api/SpurGear/5
        [ResponseType(typeof(Gear_SpurGear))]
        public async Task<IHttpActionResult> DeleteGear_SpurGear(string id)
        {
            Gear_SpurGear gear_SpurGear = await db.Gear_SpurGear.FindAsync(id);
            if (gear_SpurGear == null)
            {
                return NotFound();
            }

            db.Gear_SpurGear.Remove(gear_SpurGear);
            await db.SaveChangesAsync();

            return Ok(gear_SpurGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Gear_SpurGearExists(string id)
        {
            return db.Gear_SpurGear.Count(e => e.TypeNo == id) > 0;
        }
    }
}