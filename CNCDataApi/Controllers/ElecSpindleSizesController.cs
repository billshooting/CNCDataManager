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
    public class ElecSpindleSizesController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/ElecSpindleSizes
        public IQueryable<ElecSpindleSize> GetSizeOfElectricSpindle()
        {
            return db.SizeOfElectricSpindle;
        }

        // GET: api/ElecSpindleSizes/5
        [ResponseType(typeof(ElecSpindleSize))]
        public async Task<IHttpActionResult> GetElecSpindleSize(string id)
        {
            ElecSpindleSize elecSpindleSize = await db.SizeOfElectricSpindle.FindAsync(id);
            if (elecSpindleSize == null)
            {
                return NotFound();
            }

            return Ok(elecSpindleSize);
        }

        // PUT: api/ElecSpindleSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElecSpindleSize(string id, ElecSpindleSize elecSpindleSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elecSpindleSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(elecSpindleSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElecSpindleSizeExists(id))
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

        // POST: api/ElecSpindleSizes
        [ResponseType(typeof(ElecSpindleSize))]
        public async Task<IHttpActionResult> PostElecSpindleSize(ElecSpindleSize elecSpindleSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SizeOfElectricSpindle.Add(elecSpindleSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ElecSpindleSizeExists(elecSpindleSize.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elecSpindleSize.TypeID }, elecSpindleSize);
        }

        // DELETE: api/ElecSpindleSizes/5
        [ResponseType(typeof(ElecSpindleSize))]
        public async Task<IHttpActionResult> DeleteElecSpindleSize(string id)
        {
            ElecSpindleSize elecSpindleSize = await db.SizeOfElectricSpindle.FindAsync(id);
            if (elecSpindleSize == null)
            {
                return NotFound();
            }

            db.SizeOfElectricSpindle.Remove(elecSpindleSize);
            await db.SaveChangesAsync();

            return Ok(elecSpindleSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElecSpindleSizeExists(string id)
        {
            return db.SizeOfElectricSpindle.Count(e => e.TypeID == id) > 0;
        }
    }
}