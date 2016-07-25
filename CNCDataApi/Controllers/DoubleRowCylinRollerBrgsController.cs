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
    public class DoubleRowCylinRollerBrgsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/DoubleRowCylinRollerBrgs
        public IQueryable<DoubleRowCylinRollerBrg> GetDoubleRowCylinRollerBearings()
        {
            return db.DoubleRowCylinRollerBearings;
        }

        // GET: api/DoubleRowCylinRollerBrgs/5
        [ResponseType(typeof(DoubleRowCylinRollerBrg))]
        public async Task<IHttpActionResult> GetDoubleRowCylinRollerBrg(string id)
        {
            DoubleRowCylinRollerBrg doubleRowCylinRollerBrg = await db.DoubleRowCylinRollerBearings.FindAsync(id);
            if (doubleRowCylinRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(doubleRowCylinRollerBrg);
        }

        // PUT: api/DoubleRowCylinRollerBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDoubleRowCylinRollerBrg(string id, DoubleRowCylinRollerBrg doubleRowCylinRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doubleRowCylinRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(doubleRowCylinRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoubleRowCylinRollerBrgExists(id))
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

        // POST: api/DoubleRowCylinRollerBrgs
        [ResponseType(typeof(DoubleRowCylinRollerBrg))]
        public async Task<IHttpActionResult> PostDoubleRowCylinRollerBrg(DoubleRowCylinRollerBrg doubleRowCylinRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DoubleRowCylinRollerBearings.Add(doubleRowCylinRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoubleRowCylinRollerBrgExists(doubleRowCylinRollerBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = doubleRowCylinRollerBrg.TypeID }, doubleRowCylinRollerBrg);
        }

        // DELETE: api/DoubleRowCylinRollerBrgs/5
        [ResponseType(typeof(DoubleRowCylinRollerBrg))]
        public async Task<IHttpActionResult> DeleteDoubleRowCylinRollerBrg(string id)
        {
            DoubleRowCylinRollerBrg doubleRowCylinRollerBrg = await db.DoubleRowCylinRollerBearings.FindAsync(id);
            if (doubleRowCylinRollerBrg == null)
            {
                return NotFound();
            }

            db.DoubleRowCylinRollerBearings.Remove(doubleRowCylinRollerBrg);
            await db.SaveChangesAsync();

            return Ok(doubleRowCylinRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoubleRowCylinRollerBrgExists(string id)
        {
            return db.DoubleRowCylinRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}