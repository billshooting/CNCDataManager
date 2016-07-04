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
    public class SpindleBeltSizesController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SpindleBeltSizes
        public IQueryable<SpindleBeltSize> GetSpindleBeltSizes()
        {
            return db.SpindleBeltSizes;
        }

        // GET: api/SpindleBeltSizes/5
        [ResponseType(typeof(SpindleBeltSize))]
        public async Task<IHttpActionResult> GetSpindleBeltSize(string id)
        {
            SpindleBeltSize spindleBeltSize = await db.SpindleBeltSizes.FindAsync(id);
            if (spindleBeltSize == null)
            {
                return NotFound();
            }

            return Ok(spindleBeltSize);
        }

        // PUT: api/SpindleBeltSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpindleBeltSize(string id, SpindleBeltSize spindleBeltSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleBeltSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleBeltSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleBeltSizeExists(id))
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

        // POST: api/SpindleBeltSizes
        [ResponseType(typeof(SpindleBeltSize))]
        public async Task<IHttpActionResult> PostSpindleBeltSize(SpindleBeltSize spindleBeltSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleBeltSizes.Add(spindleBeltSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleBeltSizeExists(spindleBeltSize.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleBeltSize.TypeID }, spindleBeltSize);
        }

        // DELETE: api/SpindleBeltSizes/5
        [ResponseType(typeof(SpindleBeltSize))]
        public async Task<IHttpActionResult> DeleteSpindleBeltSize(string id)
        {
            SpindleBeltSize spindleBeltSize = await db.SpindleBeltSizes.FindAsync(id);
            if (spindleBeltSize == null)
            {
                return NotFound();
            }

            db.SpindleBeltSizes.Remove(spindleBeltSize);
            await db.SaveChangesAsync();

            return Ok(spindleBeltSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleBeltSizeExists(string id)
        {
            return db.SpindleBeltSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}