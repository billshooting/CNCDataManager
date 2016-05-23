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
    public class CommonCylindricalWormGearController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/CommonCylindricalWormGear
        public IQueryable<Worm_CommonCylindricalWormGear> GetWorm_CommonCylindricalWormGear()
        {
            return db.Worm_CommonCylindricalWormGear;
        }

        // GET: api/CommonCylindricalWormGear/5
        [ResponseType(typeof(Worm_CommonCylindricalWormGear))]
        public async Task<IHttpActionResult> GetWorm_CommonCylindricalWormGear(string id)
        {
            Worm_CommonCylindricalWormGear worm_CommonCylindricalWormGear = await db.Worm_CommonCylindricalWormGear.FindAsync(id);
            if (worm_CommonCylindricalWormGear == null)
            {
                return NotFound();
            }

            return Ok(worm_CommonCylindricalWormGear);
        }

        // PUT: api/CommonCylindricalWormGear/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorm_CommonCylindricalWormGear(string id, Worm_CommonCylindricalWormGear worm_CommonCylindricalWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worm_CommonCylindricalWormGear.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(worm_CommonCylindricalWormGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Worm_CommonCylindricalWormGearExists(id))
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

        // POST: api/CommonCylindricalWormGear
        [ResponseType(typeof(Worm_CommonCylindricalWormGear))]
        public async Task<IHttpActionResult> PostWorm_CommonCylindricalWormGear(Worm_CommonCylindricalWormGear worm_CommonCylindricalWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Worm_CommonCylindricalWormGear.Add(worm_CommonCylindricalWormGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Worm_CommonCylindricalWormGearExists(worm_CommonCylindricalWormGear.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = worm_CommonCylindricalWormGear.TypeNo }, worm_CommonCylindricalWormGear);
        }

        // DELETE: api/CommonCylindricalWormGear/5
        [ResponseType(typeof(Worm_CommonCylindricalWormGear))]
        public async Task<IHttpActionResult> DeleteWorm_CommonCylindricalWormGear(string id)
        {
            Worm_CommonCylindricalWormGear worm_CommonCylindricalWormGear = await db.Worm_CommonCylindricalWormGear.FindAsync(id);
            if (worm_CommonCylindricalWormGear == null)
            {
                return NotFound();
            }

            db.Worm_CommonCylindricalWormGear.Remove(worm_CommonCylindricalWormGear);
            await db.SaveChangesAsync();

            return Ok(worm_CommonCylindricalWormGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Worm_CommonCylindricalWormGearExists(string id)
        {
            return db.Worm_CommonCylindricalWormGear.Count(e => e.TypeNo == id) > 0;
        }
    }
}