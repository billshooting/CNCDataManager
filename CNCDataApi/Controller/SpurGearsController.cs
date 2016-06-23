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
    public class SpurGearsController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/SpurGears
        public IQueryable<SpurGear> GetSpurGear()
        {
            return db.SpurGear;
        }

        // GET: api/SpurGears/5
        [ResponseType(typeof(SpurGear))]
        public async Task<IHttpActionResult> GetSpurGear(string id)
        {
            SpurGear spurGear = await db.SpurGear.FindAsync(id);
            if (spurGear == null)
            {
                return NotFound();
            }

            return Ok(spurGear);
        }

        // PUT: api/SpurGears/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpurGear(string id, SpurGear spurGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spurGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spurGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpurGearExists(id))
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

        // POST: api/SpurGears
        [ResponseType(typeof(SpurGear))]
        public async Task<IHttpActionResult> PostSpurGear(SpurGear spurGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpurGear.Add(spurGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpurGearExists(spurGear.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spurGear.TypeID }, spurGear);
        }

        // DELETE: api/SpurGears/5
        [ResponseType(typeof(SpurGear))]
        public async Task<IHttpActionResult> DeleteSpurGear(string id)
        {
            SpurGear spurGear = await db.SpurGear.FindAsync(id);
            if (spurGear == null)
            {
                return NotFound();
            }

            db.SpurGear.Remove(spurGear);
            await db.SaveChangesAsync();

            return Ok(spurGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpurGearExists(string id)
        {
            return db.SpurGear.Count(e => e.TypeID == id) > 0;
        }
    }
}