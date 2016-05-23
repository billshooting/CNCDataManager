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
    public class sysdiagramsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/sysdiagrams
        public IQueryable<sysdiagrams> Getsysdiagrams()
        {
            return db.sysdiagrams;
        }

        // GET: api/sysdiagrams/5
        [ResponseType(typeof(sysdiagrams))]
        public async Task<IHttpActionResult> Getsysdiagrams(int id)
        {
            sysdiagrams sysdiagrams = await db.sysdiagrams.FindAsync(id);
            if (sysdiagrams == null)
            {
                return NotFound();
            }

            return Ok(sysdiagrams);
        }

        // PUT: api/sysdiagrams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putsysdiagrams(int id, sysdiagrams sysdiagrams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sysdiagrams.diagram_id)
            {
                return BadRequest();
            }

            db.Entry(sysdiagrams).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sysdiagramsExists(id))
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

        // POST: api/sysdiagrams
        [ResponseType(typeof(sysdiagrams))]
        public async Task<IHttpActionResult> Postsysdiagrams(sysdiagrams sysdiagrams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sysdiagrams.Add(sysdiagrams);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sysdiagrams.diagram_id }, sysdiagrams);
        }

        // DELETE: api/sysdiagrams/5
        [ResponseType(typeof(sysdiagrams))]
        public async Task<IHttpActionResult> Deletesysdiagrams(int id)
        {
            sysdiagrams sysdiagrams = await db.sysdiagrams.FindAsync(id);
            if (sysdiagrams == null)
            {
                return NotFound();
            }

            db.sysdiagrams.Remove(sysdiagrams);
            await db.SaveChangesAsync();

            return Ok(sysdiagrams);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sysdiagramsExists(int id)
        {
            return db.sysdiagrams.Count(e => e.diagram_id == id) > 0;
        }
    }
}