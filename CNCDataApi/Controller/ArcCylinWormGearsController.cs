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
    public class ArcCylinWormGearsController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/ArcCylinWormGears
        public IQueryable<ArcCylinWormGear> GetArcCylindricalWormGear()
        {
            return db.ArcCylindricalWormGear;
        }

        // GET: api/ArcCylinWormGears/5
        [ResponseType(typeof(ArcCylinWormGear))]
        public async Task<IHttpActionResult> GetArcCylinWormGear(string id)
        {
            ArcCylinWormGear arcCylinWormGear = await db.ArcCylindricalWormGear.FindAsync(id);
            if (arcCylinWormGear == null)
            {
                return NotFound();
            }

            return Ok(arcCylinWormGear);
        }

        // PUT: api/ArcCylinWormGears/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArcCylinWormGear(string id, ArcCylinWormGear arcCylinWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arcCylinWormGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(arcCylinWormGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArcCylinWormGearExists(id))
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

        // POST: api/ArcCylinWormGears
        [ResponseType(typeof(ArcCylinWormGear))]
        public async Task<IHttpActionResult> PostArcCylinWormGear(ArcCylinWormGear arcCylinWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ArcCylindricalWormGear.Add(arcCylinWormGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArcCylinWormGearExists(arcCylinWormGear.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = arcCylinWormGear.TypeID }, arcCylinWormGear);
        }

        // DELETE: api/ArcCylinWormGears/5
        [ResponseType(typeof(ArcCylinWormGear))]
        public async Task<IHttpActionResult> DeleteArcCylinWormGear(string id)
        {
            ArcCylinWormGear arcCylinWormGear = await db.ArcCylindricalWormGear.FindAsync(id);
            if (arcCylinWormGear == null)
            {
                return NotFound();
            }

            db.ArcCylindricalWormGear.Remove(arcCylinWormGear);
            await db.SaveChangesAsync();

            return Ok(arcCylinWormGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArcCylinWormGearExists(string id)
        {
            return db.ArcCylindricalWormGear.Count(e => e.TypeID == id) > 0;
        }
    }
}