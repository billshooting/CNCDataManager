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
using CNCDataManager.Models;

namespace CNCDataManager.Controllers
{
    public class SrvDriverReactorsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SrvDriverReactors
        public IQueryable<SrvDriverReactor> GetSrvDriverReactors()
        {
            return db.SrvDriverReactors;
        }

        // GET: api/SrvDriverReactors/5
        [ResponseType(typeof(SrvDriverReactor))]
        public async Task<IHttpActionResult> GetSrvDriverReactor(string id)
        {
            SrvDriverReactor srvDriverReactor = await db.SrvDriverReactors.FindAsync(id);
            if (srvDriverReactor == null)
            {
                return NotFound();
            }

            return Ok(srvDriverReactor);
        }

        // PUT: api/SrvDriverReactors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSrvDriverReactor(string id, SrvDriverReactor srvDriverReactor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != srvDriverReactor.TypeID)
            {
                return BadRequest();
            }

            db.Entry(srvDriverReactor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SrvDriverReactorExists(id))
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

        // POST: api/SrvDriverReactors
        [ResponseType(typeof(SrvDriverReactor))]
        public async Task<IHttpActionResult> PostSrvDriverReactor(SrvDriverReactor srvDriverReactor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SrvDriverReactors.Add(srvDriverReactor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SrvDriverReactorExists(srvDriverReactor.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = srvDriverReactor.TypeID }, srvDriverReactor);
        }

        // DELETE: api/SrvDriverReactors/5
        [ResponseType(typeof(SrvDriverReactor))]
        public async Task<IHttpActionResult> DeleteSrvDriverReactor(string id)
        {
            SrvDriverReactor srvDriverReactor = await db.SrvDriverReactors.FindAsync(id);
            if (srvDriverReactor == null)
            {
                return NotFound();
            }

            db.SrvDriverReactors.Remove(srvDriverReactor);
            await db.SaveChangesAsync();

            return Ok(srvDriverReactor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SrvDriverReactorExists(string id)
        {
            return db.SrvDriverReactors.Count(e => e.TypeID == id) > 0;
        }
    }
}