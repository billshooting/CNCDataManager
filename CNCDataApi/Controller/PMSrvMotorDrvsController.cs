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
    public class PMSrvMotorDrvsController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/PMSrvMotorDrvs
        public IQueryable<PMSrvMotorDrv> GetDriverOfServoMotorOfPMSACFS()
        {
            return db.DriverOfServoMotorOfPMSACFS;
        }

        // GET: api/PMSrvMotorDrvs/5
        [ResponseType(typeof(PMSrvMotorDrv))]
        public async Task<IHttpActionResult> GetPMSrvMotorDrv(string id)
        {
            PMSrvMotorDrv pMSrvMotorDrv = await db.DriverOfServoMotorOfPMSACFS.FindAsync(id);
            if (pMSrvMotorDrv == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorDrv);
        }

        // PUT: api/PMSrvMotorDrvs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPMSrvMotorDrv(string id, PMSrvMotorDrv pMSrvMotorDrv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorDrv.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorDrv).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorDrvExists(id))
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

        // POST: api/PMSrvMotorDrvs
        [ResponseType(typeof(PMSrvMotorDrv))]
        public async Task<IHttpActionResult> PostPMSrvMotorDrv(PMSrvMotorDrv pMSrvMotorDrv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DriverOfServoMotorOfPMSACFS.Add(pMSrvMotorDrv);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorDrvExists(pMSrvMotorDrv.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorDrv.TypeID }, pMSrvMotorDrv);
        }

        // DELETE: api/PMSrvMotorDrvs/5
        [ResponseType(typeof(PMSrvMotorDrv))]
        public async Task<IHttpActionResult> DeletePMSrvMotorDrv(string id)
        {
            PMSrvMotorDrv pMSrvMotorDrv = await db.DriverOfServoMotorOfPMSACFS.FindAsync(id);
            if (pMSrvMotorDrv == null)
            {
                return NotFound();
            }

            db.DriverOfServoMotorOfPMSACFS.Remove(pMSrvMotorDrv);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorDrv);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorDrvExists(string id)
        {
            return db.DriverOfServoMotorOfPMSACFS.Count(e => e.TypeID == id) > 0;
        }
    }
}