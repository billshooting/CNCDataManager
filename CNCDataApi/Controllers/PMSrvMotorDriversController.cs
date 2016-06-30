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
    public class PMSrvMotorDriversController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/PMSrvMotorDrivers
        public IQueryable<PMSrvMotorDriver> GetDriverOfServoMotorOfPMSACFS()
        {
            return db.DriverOfServoMotorOfPMSACFS;
        }

        // GET: api/PMSrvMotorDrivers/5
        [ResponseType(typeof(PMSrvMotorDriver))]
        public async Task<IHttpActionResult> GetPMSrvMotorDriver(string id)
        {
            PMSrvMotorDriver pMSrvMotorDriver = await db.DriverOfServoMotorOfPMSACFS.FindAsync(id);
            if (pMSrvMotorDriver == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorDriver);
        }

        // PUT: api/PMSrvMotorDrivers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPMSrvMotorDriver(string id, PMSrvMotorDriver pMSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorDriver.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorDriver).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorDriverExists(id))
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

        // POST: api/PMSrvMotorDrivers
        [ResponseType(typeof(PMSrvMotorDriver))]
        public async Task<IHttpActionResult> PostPMSrvMotorDriver(PMSrvMotorDriver pMSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DriverOfServoMotorOfPMSACFS.Add(pMSrvMotorDriver);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorDriverExists(pMSrvMotorDriver.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorDriver.TypeID }, pMSrvMotorDriver);
        }

        // DELETE: api/PMSrvMotorDrivers/5
        [ResponseType(typeof(PMSrvMotorDriver))]
        public async Task<IHttpActionResult> DeletePMSrvMotorDriver(string id)
        {
            PMSrvMotorDriver pMSrvMotorDriver = await db.DriverOfServoMotorOfPMSACFS.FindAsync(id);
            if (pMSrvMotorDriver == null)
            {
                return NotFound();
            }

            db.DriverOfServoMotorOfPMSACFS.Remove(pMSrvMotorDriver);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorDriver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorDriverExists(string id)
        {
            return db.DriverOfServoMotorOfPMSACFS.Count(e => e.TypeID == id) > 0;
        }
    }
}