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
    public class CylinRollerBrgsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/CylinRollerBrgs
        public IQueryable<CylinRollerBrg> GetCylinRollerBearings()
        {
            return db.CylinRollerBearings;
        }

        // GET: api/CylinRollerBrgs/5
        [ResponseType(typeof(CylinRollerBrg))]
        public async Task<IHttpActionResult> GetCylinRollerBrg(string id)
        {
            CylinRollerBrg cylinRollerBrg = await db.CylinRollerBearings.FindAsync(id);
            if (cylinRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(cylinRollerBrg);
        }

        // PUT: api/CylinRollerBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCylinRollerBrg(string id, CylinRollerBrg cylinRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cylinRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(cylinRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CylinRollerBrgExists(id))
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

        // POST: api/CylinRollerBrgs
        [ResponseType(typeof(CylinRollerBrg))]
        public async Task<IHttpActionResult> PostCylinRollerBrg(CylinRollerBrg cylinRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CylinRollerBearings.Add(cylinRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CylinRollerBrgExists(cylinRollerBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cylinRollerBrg.TypeID }, cylinRollerBrg);
        }

        // DELETE: api/CylinRollerBrgs/5
        [ResponseType(typeof(CylinRollerBrg))]
        public async Task<IHttpActionResult> DeleteCylinRollerBrg(string id)
        {
            CylinRollerBrg cylinRollerBrg = await db.CylinRollerBearings.FindAsync(id);
            if (cylinRollerBrg == null)
            {
                return NotFound();
            }

            db.CylinRollerBearings.Remove(cylinRollerBrg);
            await db.SaveChangesAsync();

            return Ok(cylinRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CylinRollerBrgExists(string id)
        {
            return db.CylinRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}