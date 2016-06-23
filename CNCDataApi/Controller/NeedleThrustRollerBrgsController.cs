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
    public class NeedleThrustRollerBrgsController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/NeedleThrustRollerBrgs
        public IQueryable<NeedleThrustRollerBrg> GetNeedleRollerAndThrustRollerBearings()
        {
            return db.NeedleRollerAndThrustRollerBearings;
        }

        // GET: api/NeedleThrustRollerBrgs/5
        [ResponseType(typeof(NeedleThrustRollerBrg))]
        public async Task<IHttpActionResult> GetNeedleThrustRollerBrg(string id)
        {
            NeedleThrustRollerBrg needleThrustRollerBrg = await db.NeedleRollerAndThrustRollerBearings.FindAsync(id);
            if (needleThrustRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(needleThrustRollerBrg);
        }

        // PUT: api/NeedleThrustRollerBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNeedleThrustRollerBrg(string id, NeedleThrustRollerBrg needleThrustRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != needleThrustRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(needleThrustRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeedleThrustRollerBrgExists(id))
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

        // POST: api/NeedleThrustRollerBrgs
        [ResponseType(typeof(NeedleThrustRollerBrg))]
        public async Task<IHttpActionResult> PostNeedleThrustRollerBrg(NeedleThrustRollerBrg needleThrustRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NeedleRollerAndThrustRollerBearings.Add(needleThrustRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NeedleThrustRollerBrgExists(needleThrustRollerBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = needleThrustRollerBrg.TypeID }, needleThrustRollerBrg);
        }

        // DELETE: api/NeedleThrustRollerBrgs/5
        [ResponseType(typeof(NeedleThrustRollerBrg))]
        public async Task<IHttpActionResult> DeleteNeedleThrustRollerBrg(string id)
        {
            NeedleThrustRollerBrg needleThrustRollerBrg = await db.NeedleRollerAndThrustRollerBearings.FindAsync(id);
            if (needleThrustRollerBrg == null)
            {
                return NotFound();
            }

            db.NeedleRollerAndThrustRollerBearings.Remove(needleThrustRollerBrg);
            await db.SaveChangesAsync();

            return Ok(needleThrustRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NeedleThrustRollerBrgExists(string id)
        {
            return db.NeedleRollerAndThrustRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}