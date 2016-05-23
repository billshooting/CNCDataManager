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
    public class NCSystemController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/NCSystem
        public IQueryable<System_NCSystem> GetSystem_NCSystem()
        {
            return db.System_NCSystem;
        }

        // GET: api/NCSystem/5
        [ResponseType(typeof(System_NCSystem))]
        public async Task<IHttpActionResult> GetSystem_NCSystem(string id)
        {
            System_NCSystem system_NCSystem = await db.System_NCSystem.FindAsync(id);
            if (system_NCSystem == null)
            {
                return NotFound();
            }

            return Ok(system_NCSystem);
        }

        // PUT: api/NCSystem/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSystem_NCSystem(string id, System_NCSystem system_NCSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != system_NCSystem.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(system_NCSystem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!System_NCSystemExists(id))
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

        // POST: api/NCSystem
        [ResponseType(typeof(System_NCSystem))]
        public async Task<IHttpActionResult> PostSystem_NCSystem(System_NCSystem system_NCSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.System_NCSystem.Add(system_NCSystem);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (System_NCSystemExists(system_NCSystem.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = system_NCSystem.TypeNo }, system_NCSystem);
        }

        // DELETE: api/NCSystem/5
        [ResponseType(typeof(System_NCSystem))]
        public async Task<IHttpActionResult> DeleteSystem_NCSystem(string id)
        {
            System_NCSystem system_NCSystem = await db.System_NCSystem.FindAsync(id);
            if (system_NCSystem == null)
            {
                return NotFound();
            }

            db.System_NCSystem.Remove(system_NCSystem);
            await db.SaveChangesAsync();

            return Ok(system_NCSystem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool System_NCSystemExists(string id)
        {
            return db.System_NCSystem.Count(e => e.TypeNo == id) > 0;
        }
    }
}