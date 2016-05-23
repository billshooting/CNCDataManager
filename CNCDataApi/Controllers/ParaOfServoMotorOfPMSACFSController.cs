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
    //永磁同步交流进给系统伺服电机技术   ParaOfServoMotorOfPMSACFS (Permanent magnet synchronous AC servo motor feeding system Parameter)
    public class ParaOfServoMotorOfPMSACFSController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/ParaOfServoMotorOfPMSACFS
        public IQueryable<Motor_ParaOfServoMotorOfPMSACFS> GetMotor_ParaOfServoMotorOfPMSACFS()
        {
            return db.Motor_ParaOfServoMotorOfPMSACFS;
        }

        // GET: api/ParaOfServoMotorOfPMSACFS/5
        [ResponseType(typeof(Motor_ParaOfServoMotorOfPMSACFS))]
        public async Task<IHttpActionResult> GetMotor_ParaOfServoMotorOfPMSACFS(string id)
        {
            Motor_ParaOfServoMotorOfPMSACFS motor_ParaOfServoMotorOfPMSACFS = await db.Motor_ParaOfServoMotorOfPMSACFS.FindAsync(id);
            if (motor_ParaOfServoMotorOfPMSACFS == null)
            {
                return NotFound();
            }

            return Ok(motor_ParaOfServoMotorOfPMSACFS);
        }

        // PUT: api/ParaOfServoMotorOfPMSACFS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMotor_ParaOfServoMotorOfPMSACFS(string id, Motor_ParaOfServoMotorOfPMSACFS motor_ParaOfServoMotorOfPMSACFS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motor_ParaOfServoMotorOfPMSACFS.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(motor_ParaOfServoMotorOfPMSACFS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Motor_ParaOfServoMotorOfPMSACFSExists(id))
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

        // POST: api/ParaOfServoMotorOfPMSACFS
        [ResponseType(typeof(Motor_ParaOfServoMotorOfPMSACFS))]
        public async Task<IHttpActionResult> PostMotor_ParaOfServoMotorOfPMSACFS(Motor_ParaOfServoMotorOfPMSACFS motor_ParaOfServoMotorOfPMSACFS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motor_ParaOfServoMotorOfPMSACFS.Add(motor_ParaOfServoMotorOfPMSACFS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Motor_ParaOfServoMotorOfPMSACFSExists(motor_ParaOfServoMotorOfPMSACFS.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motor_ParaOfServoMotorOfPMSACFS.TypeNo }, motor_ParaOfServoMotorOfPMSACFS);
        }

        // DELETE: api/ParaOfServoMotorOfPMSACFS/5
        [ResponseType(typeof(Motor_ParaOfServoMotorOfPMSACFS))]
        public async Task<IHttpActionResult> DeleteMotor_ParaOfServoMotorOfPMSACFS(string id)
        {
            Motor_ParaOfServoMotorOfPMSACFS motor_ParaOfServoMotorOfPMSACFS = await db.Motor_ParaOfServoMotorOfPMSACFS.FindAsync(id);
            if (motor_ParaOfServoMotorOfPMSACFS == null)
            {
                return NotFound();
            }

            db.Motor_ParaOfServoMotorOfPMSACFS.Remove(motor_ParaOfServoMotorOfPMSACFS);
            await db.SaveChangesAsync();

            return Ok(motor_ParaOfServoMotorOfPMSACFS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Motor_ParaOfServoMotorOfPMSACFSExists(string id)
        {
            return db.Motor_ParaOfServoMotorOfPMSACFS.Count(e => e.TypeNo == id) > 0;
        }
    }
}