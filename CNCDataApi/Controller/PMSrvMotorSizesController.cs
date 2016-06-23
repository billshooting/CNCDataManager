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
    public class PMSrvMotorSizesController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/PMSrvMotorSizes
        public IQueryable<PMSrvMotorSize> GetSizeOfServoMotorOfPMSACFS()
        {
            return db.SizeOfServoMotorOfPMSACFS;
        }

        // GET: api/PMSrvMotorSizes/5
        [ResponseType(typeof(PMSrvMotorSize))]
        public async Task<IHttpActionResult> GetPMSrvMotorSize(string id)
        {
            PMSrvMotorSize pMSrvMotorSize = await db.SizeOfServoMotorOfPMSACFS.FindAsync(id);
            if (pMSrvMotorSize == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorSize);
        }

        // PUT: api/PMSrvMotorSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPMSrvMotorSize(string id, PMSrvMotorSize pMSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorSizeExists(id))
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

        // POST: api/PMSrvMotorSizes
        [ResponseType(typeof(PMSrvMotorSize))]
        public async Task<IHttpActionResult> PostPMSrvMotorSize(PMSrvMotorSize pMSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SizeOfServoMotorOfPMSACFS.Add(pMSrvMotorSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorSizeExists(pMSrvMotorSize.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorSize.TypeID }, pMSrvMotorSize);
        }

        // DELETE: api/PMSrvMotorSizes/5
        [ResponseType(typeof(PMSrvMotorSize))]
        public async Task<IHttpActionResult> DeletePMSrvMotorSize(string id)
        {
            PMSrvMotorSize pMSrvMotorSize = await db.SizeOfServoMotorOfPMSACFS.FindAsync(id);
            if (pMSrvMotorSize == null)
            {
                return NotFound();
            }

            db.SizeOfServoMotorOfPMSACFS.Remove(pMSrvMotorSize);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorSizeExists(string id)
        {
            return db.SizeOfServoMotorOfPMSACFS.Count(e => e.TypeID == id) > 0;
        }
    }
}