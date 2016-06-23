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
    public class SpindleSrvMotorSizesController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/SpindleSrvMotorSizes
        public IQueryable<SpindleSrvMotorSize> GetSizeOfServoMotorOfSpindle()
        {
            return db.SizeOfServoMotorOfSpindle;
        }

        // GET: api/SpindleSrvMotorSizes/5
        [ResponseType(typeof(SpindleSrvMotorSize))]
        public async Task<IHttpActionResult> GetSpindleSrvMotorSize(string id)
        {
            SpindleSrvMotorSize spindleSrvMotorSize = await db.SizeOfServoMotorOfSpindle.FindAsync(id);
            if (spindleSrvMotorSize == null)
            {
                return NotFound();
            }

            return Ok(spindleSrvMotorSize);
        }

        // PUT: api/SpindleSrvMotorSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpindleSrvMotorSize(string id, SpindleSrvMotorSize spindleSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleSrvMotorSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleSrvMotorSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleSrvMotorSizeExists(id))
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

        // POST: api/SpindleSrvMotorSizes
        [ResponseType(typeof(SpindleSrvMotorSize))]
        public async Task<IHttpActionResult> PostSpindleSrvMotorSize(SpindleSrvMotorSize spindleSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SizeOfServoMotorOfSpindle.Add(spindleSrvMotorSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleSrvMotorSizeExists(spindleSrvMotorSize.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleSrvMotorSize.TypeID }, spindleSrvMotorSize);
        }

        // DELETE: api/SpindleSrvMotorSizes/5
        [ResponseType(typeof(SpindleSrvMotorSize))]
        public async Task<IHttpActionResult> DeleteSpindleSrvMotorSize(string id)
        {
            SpindleSrvMotorSize spindleSrvMotorSize = await db.SizeOfServoMotorOfSpindle.FindAsync(id);
            if (spindleSrvMotorSize == null)
            {
                return NotFound();
            }

            db.SizeOfServoMotorOfSpindle.Remove(spindleSrvMotorSize);
            await db.SaveChangesAsync();

            return Ok(spindleSrvMotorSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleSrvMotorSizeExists(string id)
        {
            return db.SizeOfServoMotorOfSpindle.Count(e => e.TypeID == id) > 0;
        }
    }
}