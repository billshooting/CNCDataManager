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
    public class HeliCylinGearsController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/HeliCylinGears
        public IQueryable<HeliCylinGear> GetHelicalCylindricalGear()
        {
            return db.HelicalCylindricalGear;
        }

        // GET: api/HeliCylinGears/5
        [ResponseType(typeof(HeliCylinGear))]
        public async Task<IHttpActionResult> GetHeliCylinGear(string id)
        {
            HeliCylinGear heliCylinGear = await db.HelicalCylindricalGear.FindAsync(id);
            if (heliCylinGear == null)
            {
                return NotFound();
            }

            return Ok(heliCylinGear);
        }

        // PUT: api/HeliCylinGears/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHeliCylinGear(string id, HeliCylinGear heliCylinGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heliCylinGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(heliCylinGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeliCylinGearExists(id))
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

        // POST: api/HeliCylinGears
        [ResponseType(typeof(HeliCylinGear))]
        public async Task<IHttpActionResult> PostHeliCylinGear(HeliCylinGear heliCylinGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HelicalCylindricalGear.Add(heliCylinGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeliCylinGearExists(heliCylinGear.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = heliCylinGear.TypeID }, heliCylinGear);
        }

        // DELETE: api/HeliCylinGears/5
        [ResponseType(typeof(HeliCylinGear))]
        public async Task<IHttpActionResult> DeleteHeliCylinGear(string id)
        {
            HeliCylinGear heliCylinGear = await db.HelicalCylindricalGear.FindAsync(id);
            if (heliCylinGear == null)
            {
                return NotFound();
            }

            db.HelicalCylindricalGear.Remove(heliCylinGear);
            await db.SaveChangesAsync();

            return Ok(heliCylinGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeliCylinGearExists(string id)
        {
            return db.HelicalCylindricalGear.Count(e => e.TypeID == id) > 0;
        }
    }
}