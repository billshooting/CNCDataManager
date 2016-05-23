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
    public class ArcCylindricalWormGearController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/ArcCylindricalWormGear
        public IQueryable<Worm_ArcCylindricalWormGear> GetWorm_ArcCylindricalWormGear()
        {
            return db.Worm_ArcCylindricalWormGear;
        }

        // GET: api/ArcCylindricalWormGear/5
        [ResponseType(typeof(Worm_ArcCylindricalWormGear))]
        public async Task<IHttpActionResult> GetWorm_ArcCylindricalWormGear(string id)
        {
            Worm_ArcCylindricalWormGear worm_ArcCylindricalWormGear = await db.Worm_ArcCylindricalWormGear.FindAsync(id);
            if (worm_ArcCylindricalWormGear == null)
            {
                return NotFound();
            }

            return Ok(worm_ArcCylindricalWormGear);
        }

        // PUT: api/ArcCylindricalWormGear/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorm_ArcCylindricalWormGear(string id, Worm_ArcCylindricalWormGear worm_ArcCylindricalWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worm_ArcCylindricalWormGear.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(worm_ArcCylindricalWormGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Worm_ArcCylindricalWormGearExists(id))
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

        // POST: api/ArcCylindricalWormGear
        [ResponseType(typeof(Worm_ArcCylindricalWormGear))]
        public async Task<IHttpActionResult> PostWorm_ArcCylindricalWormGear(Worm_ArcCylindricalWormGear worm_ArcCylindricalWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Worm_ArcCylindricalWormGear.Add(worm_ArcCylindricalWormGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Worm_ArcCylindricalWormGearExists(worm_ArcCylindricalWormGear.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = worm_ArcCylindricalWormGear.TypeNo }, worm_ArcCylindricalWormGear);
        }

        // DELETE: api/ArcCylindricalWormGear/5
        [ResponseType(typeof(Worm_ArcCylindricalWormGear))]
        public async Task<IHttpActionResult> DeleteWorm_ArcCylindricalWormGear(string id)
        {
            Worm_ArcCylindricalWormGear worm_ArcCylindricalWormGear = await db.Worm_ArcCylindricalWormGear.FindAsync(id);
            if (worm_ArcCylindricalWormGear == null)
            {
                return NotFound();
            }

            db.Worm_ArcCylindricalWormGear.Remove(worm_ArcCylindricalWormGear);
            await db.SaveChangesAsync();

            return Ok(worm_ArcCylindricalWormGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Worm_ArcCylindricalWormGearExists(string id)
        {
            return db.Worm_ArcCylindricalWormGear.Count(e => e.TypeNo == id) > 0;
        }
    }
}