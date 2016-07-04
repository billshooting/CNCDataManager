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
    public class NeedleRollerThrustRollerBrgsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/NeedleRollerThrustRollerBrgs
        public IQueryable<NeedleRollerThrustRollerBrg> GetNeedleRollerThrustRollerBearings()
        {
            return db.NeedleRollerThrustRollerBearings;
        }

        // GET: api/NeedleRollerThrustRollerBrgs/5
        [ResponseType(typeof(NeedleRollerThrustRollerBrg))]
        public async Task<IHttpActionResult> GetNeedleRollerThrustRollerBrg(string id)
        {
            NeedleRollerThrustRollerBrg needleRollerThrustRollerBrg = await db.NeedleRollerThrustRollerBearings.FindAsync(id);
            if (needleRollerThrustRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(needleRollerThrustRollerBrg);
        }

        // PUT: api/NeedleRollerThrustRollerBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNeedleRollerThrustRollerBrg(string id, NeedleRollerThrustRollerBrg needleRollerThrustRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != needleRollerThrustRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(needleRollerThrustRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeedleRollerThrustRollerBrgExists(id))
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

        // POST: api/NeedleRollerThrustRollerBrgs
        [ResponseType(typeof(NeedleRollerThrustRollerBrg))]
        public async Task<IHttpActionResult> PostNeedleRollerThrustRollerBrg(NeedleRollerThrustRollerBrg needleRollerThrustRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NeedleRollerThrustRollerBearings.Add(needleRollerThrustRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NeedleRollerThrustRollerBrgExists(needleRollerThrustRollerBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = needleRollerThrustRollerBrg.TypeID }, needleRollerThrustRollerBrg);
        }

        // DELETE: api/NeedleRollerThrustRollerBrgs/5
        [ResponseType(typeof(NeedleRollerThrustRollerBrg))]
        public async Task<IHttpActionResult> DeleteNeedleRollerThrustRollerBrg(string id)
        {
            NeedleRollerThrustRollerBrg needleRollerThrustRollerBrg = await db.NeedleRollerThrustRollerBearings.FindAsync(id);
            if (needleRollerThrustRollerBrg == null)
            {
                return NotFound();
            }

            db.NeedleRollerThrustRollerBearings.Remove(needleRollerThrustRollerBrg);
            await db.SaveChangesAsync();

            return Ok(needleRollerThrustRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NeedleRollerThrustRollerBrgExists(string id)
        {
            return db.NeedleRollerThrustRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}