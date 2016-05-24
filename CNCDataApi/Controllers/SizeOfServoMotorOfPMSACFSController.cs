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
    public class SizeOfServoMotorOfPMSACFSController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/SizeOfServoMotorOfPMSACFS
        public IQueryable<Motor_SizeOfServoMotorOfPMSACFS> GetMotor_SizeOfServoMotorOfPMSACFS()
        {
            return db.Motor_SizeOfServoMotorOfPMSACFS;
        }

        // GET: api/SizeOfServoMotorOfPMSACFS/5
        [ResponseType(typeof(Motor_SizeOfServoMotorOfPMSACFS))]
        public async Task<IHttpActionResult> GetMotor_SizeOfServoMotorOfPMSACFS(string id)
        {
            Motor_SizeOfServoMotorOfPMSACFS motor_SizeOfServoMotorOfPMSACFS = await db.Motor_SizeOfServoMotorOfPMSACFS.FindAsync(id);
            if (motor_SizeOfServoMotorOfPMSACFS == null)
            {
                return NotFound();
            }

            return Ok(motor_SizeOfServoMotorOfPMSACFS);
        }

        // PUT: api/SizeOfServoMotorOfPMSACFS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMotor_SizeOfServoMotorOfPMSACFS(string id, Motor_SizeOfServoMotorOfPMSACFS motor_SizeOfServoMotorOfPMSACFS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motor_SizeOfServoMotorOfPMSACFS.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(motor_SizeOfServoMotorOfPMSACFS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Motor_SizeOfServoMotorOfPMSACFSExists(id))
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

        // POST: api/SizeOfServoMotorOfPMSACFS
        [ResponseType(typeof(Motor_SizeOfServoMotorOfPMSACFS))]
        public async Task<IHttpActionResult> PostMotor_SizeOfServoMotorOfPMSACFS(Motor_SizeOfServoMotorOfPMSACFS motor_SizeOfServoMotorOfPMSACFS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motor_SizeOfServoMotorOfPMSACFS.Add(motor_SizeOfServoMotorOfPMSACFS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Motor_SizeOfServoMotorOfPMSACFSExists(motor_SizeOfServoMotorOfPMSACFS.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motor_SizeOfServoMotorOfPMSACFS.TypeNo }, motor_SizeOfServoMotorOfPMSACFS);
        }

        // DELETE: api/SizeOfServoMotorOfPMSACFS/5
        [ResponseType(typeof(Motor_SizeOfServoMotorOfPMSACFS))]
        public async Task<IHttpActionResult> DeleteMotor_SizeOfServoMotorOfPMSACFS(string id)
        {
            Motor_SizeOfServoMotorOfPMSACFS motor_SizeOfServoMotorOfPMSACFS = await db.Motor_SizeOfServoMotorOfPMSACFS.FindAsync(id);
            if (motor_SizeOfServoMotorOfPMSACFS == null)
            {
                return NotFound();
            }

            db.Motor_SizeOfServoMotorOfPMSACFS.Remove(motor_SizeOfServoMotorOfPMSACFS);
            await db.SaveChangesAsync();

            return Ok(motor_SizeOfServoMotorOfPMSACFS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Motor_SizeOfServoMotorOfPMSACFSExists(string id)
        {
            return db.Motor_SizeOfServoMotorOfPMSACFS.Count(e => e.TypeNo == id) > 0;
        }
    }
}