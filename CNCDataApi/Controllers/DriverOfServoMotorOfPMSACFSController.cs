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
    //永磁同步交流进给系统伺服电机驱动器
    public class DriverOfServoMotorOfPMSACFSController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/DriverOfServoMotorOfPMSACFS
        public IQueryable<Driver_DriverOfServoMotorOfPMSACFS> GetDriver_DriverOfServoMotorOfPMSACFS()
        {
            return db.Driver_DriverOfServoMotorOfPMSACFS;
        }

        // GET: api/DriverOfServoMotorOfPMSACFS/5
        [ResponseType(typeof(Driver_DriverOfServoMotorOfPMSACFS))]
        public async Task<IHttpActionResult> GetDriver_DriverOfServoMotorOfPMSACFS(string id)
        {
            Driver_DriverOfServoMotorOfPMSACFS driver_DriverOfServoMotorOfPMSACFS = await db.Driver_DriverOfServoMotorOfPMSACFS.FindAsync(id);
            if (driver_DriverOfServoMotorOfPMSACFS == null)
            {
                return NotFound();
            }

            return Ok(driver_DriverOfServoMotorOfPMSACFS);
        }

        // PUT: api/DriverOfServoMotorOfPMSACFS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDriver_DriverOfServoMotorOfPMSACFS(string id, Driver_DriverOfServoMotorOfPMSACFS driver_DriverOfServoMotorOfPMSACFS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driver_DriverOfServoMotorOfPMSACFS.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(driver_DriverOfServoMotorOfPMSACFS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Driver_DriverOfServoMotorOfPMSACFSExists(id))
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

        // POST: api/DriverOfServoMotorOfPMSACFS
        [ResponseType(typeof(Driver_DriverOfServoMotorOfPMSACFS))]
        public async Task<IHttpActionResult> PostDriver_DriverOfServoMotorOfPMSACFS(Driver_DriverOfServoMotorOfPMSACFS driver_DriverOfServoMotorOfPMSACFS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Driver_DriverOfServoMotorOfPMSACFS.Add(driver_DriverOfServoMotorOfPMSACFS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Driver_DriverOfServoMotorOfPMSACFSExists(driver_DriverOfServoMotorOfPMSACFS.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = driver_DriverOfServoMotorOfPMSACFS.TypeNo }, driver_DriverOfServoMotorOfPMSACFS);
        }

        // DELETE: api/DriverOfServoMotorOfPMSACFS/5
        [ResponseType(typeof(Driver_DriverOfServoMotorOfPMSACFS))]
        public async Task<IHttpActionResult> DeleteDriver_DriverOfServoMotorOfPMSACFS(string id)
        {
            Driver_DriverOfServoMotorOfPMSACFS driver_DriverOfServoMotorOfPMSACFS = await db.Driver_DriverOfServoMotorOfPMSACFS.FindAsync(id);
            if (driver_DriverOfServoMotorOfPMSACFS == null)
            {
                return NotFound();
            }

            db.Driver_DriverOfServoMotorOfPMSACFS.Remove(driver_DriverOfServoMotorOfPMSACFS);
            await db.SaveChangesAsync();

            return Ok(driver_DriverOfServoMotorOfPMSACFS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Driver_DriverOfServoMotorOfPMSACFSExists(string id)
        {
            return db.Driver_DriverOfServoMotorOfPMSACFS.Count(e => e.TypeNo == id) > 0;
        }
    }
}