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
    public class TaperedRollerBrgsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/TaperedRollerBrgs
        public IQueryable<TaperedRollerBrg> GetTaperedRollerBearings()
        {
            return db.TaperedRollerBearings;
        }

        // GET: api/TaperedRollerBrgs/5
        [ResponseType(typeof(TaperedRollerBrg))]
        public async Task<IHttpActionResult> GetTaperedRollerBrg(string id)
        {
            TaperedRollerBrg taperedRollerBrg = await db.TaperedRollerBearings.FindAsync(id);
            if (taperedRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(taperedRollerBrg);
        }

        // PUT: api/TaperedRollerBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTaperedRollerBrg(string id, TaperedRollerBrg taperedRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taperedRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(taperedRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaperedRollerBrgExists(id))
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

        // POST: api/TaperedRollerBrgs
        [ResponseType(typeof(TaperedRollerBrg))]
        public async Task<IHttpActionResult> PostTaperedRollerBrg(TaperedRollerBrg taperedRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaperedRollerBearings.Add(taperedRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaperedRollerBrgExists(taperedRollerBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = taperedRollerBrg.TypeID }, taperedRollerBrg);
        }

        // DELETE: api/TaperedRollerBrgs/5
        [ResponseType(typeof(TaperedRollerBrg))]
        public async Task<IHttpActionResult> DeleteTaperedRollerBrg(string id)
        {
            TaperedRollerBrg taperedRollerBrg = await db.TaperedRollerBearings.FindAsync(id);
            if (taperedRollerBrg == null)
            {
                return NotFound();
            }

            db.TaperedRollerBearings.Remove(taperedRollerBrg);
            await db.SaveChangesAsync();

            return Ok(taperedRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaperedRollerBrgExists(string id)
        {
            return db.TaperedRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}