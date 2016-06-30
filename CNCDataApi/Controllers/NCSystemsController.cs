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
    public class NCSystemsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/NCSystems
        public IQueryable<NCSystem> GetNCSystem()
        {
            return db.NCSystem;
        }

        // GET: api/NCSystems/5
        [ResponseType(typeof(NCSystem))]
        public async Task<IHttpActionResult> GetNCSystem(string id)
        {
            NCSystem nCSystem = await db.NCSystem.FindAsync(id);
            if (nCSystem == null)
            {
                return NotFound();
            }

            return Ok(nCSystem);
        }

        // PUT: api/NCSystems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNCSystem(string id, NCSystem nCSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystem.TypeID)
            {
                return BadRequest();
            }

            db.Entry(nCSystem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemExists(id))
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

        // POST: api/NCSystems
        [ResponseType(typeof(NCSystem))]
        public async Task<IHttpActionResult> PostNCSystem(NCSystem nCSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystem.Add(nCSystem);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemExists(nCSystem.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSystem.TypeID }, nCSystem);
        }

        // DELETE: api/NCSystems/5
        [ResponseType(typeof(NCSystem))]
        public async Task<IHttpActionResult> DeleteNCSystem(string id)
        {
            NCSystem nCSystem = await db.NCSystem.FindAsync(id);
            if (nCSystem == null)
            {
                return NotFound();
            }

            db.NCSystem.Remove(nCSystem);
            await db.SaveChangesAsync();

            return Ok(nCSystem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemExists(string id)
        {
            return db.NCSystem.Count(e => e.TypeID == id) > 0;
        }
    }
}