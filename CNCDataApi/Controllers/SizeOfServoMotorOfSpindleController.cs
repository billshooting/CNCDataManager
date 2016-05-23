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
    public class SizeOfServoMotorOfSpindleController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/SizeOfServoMotorOfSpindle
        public IQueryable<Motor_SizeOfServoMotorOfSpindle> GetMotor_SizeOfServoMotorOfSpindle()
        {
            return db.Motor_SizeOfServoMotorOfSpindle;
        }

        // GET: api/SizeOfServoMotorOfSpindle/5
        [ResponseType(typeof(Motor_SizeOfServoMotorOfSpindle))]
        public async Task<IHttpActionResult> GetMotor_SizeOfServoMotorOfSpindle(string id)
        {
            Motor_SizeOfServoMotorOfSpindle motor_SizeOfServoMotorOfSpindle = await db.Motor_SizeOfServoMotorOfSpindle.FindAsync(id);
            if (motor_SizeOfServoMotorOfSpindle == null)
            {
                return NotFound();
            }

            return Ok(motor_SizeOfServoMotorOfSpindle);
        }

        // PUT: api/SizeOfServoMotorOfSpindle/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMotor_SizeOfServoMotorOfSpindle(string id, Motor_SizeOfServoMotorOfSpindle motor_SizeOfServoMotorOfSpindle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motor_SizeOfServoMotorOfSpindle.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(motor_SizeOfServoMotorOfSpindle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Motor_SizeOfServoMotorOfSpindleExists(id))
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

        // POST: api/SizeOfServoMotorOfSpindle
        [ResponseType(typeof(Motor_SizeOfServoMotorOfSpindle))]
        public async Task<IHttpActionResult> PostMotor_SizeOfServoMotorOfSpindle(Motor_SizeOfServoMotorOfSpindle motor_SizeOfServoMotorOfSpindle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motor_SizeOfServoMotorOfSpindle.Add(motor_SizeOfServoMotorOfSpindle);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Motor_SizeOfServoMotorOfSpindleExists(motor_SizeOfServoMotorOfSpindle.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motor_SizeOfServoMotorOfSpindle.TypeNo }, motor_SizeOfServoMotorOfSpindle);
        }

        // DELETE: api/SizeOfServoMotorOfSpindle/5
        [ResponseType(typeof(Motor_SizeOfServoMotorOfSpindle))]
        public async Task<IHttpActionResult> DeleteMotor_SizeOfServoMotorOfSpindle(string id)
        {
            Motor_SizeOfServoMotorOfSpindle motor_SizeOfServoMotorOfSpindle = await db.Motor_SizeOfServoMotorOfSpindle.FindAsync(id);
            if (motor_SizeOfServoMotorOfSpindle == null)
            {
                return NotFound();
            }

            db.Motor_SizeOfServoMotorOfSpindle.Remove(motor_SizeOfServoMotorOfSpindle);
            await db.SaveChangesAsync();

            return Ok(motor_SizeOfServoMotorOfSpindle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Motor_SizeOfServoMotorOfSpindleExists(string id)
        {
            return db.Motor_SizeOfServoMotorOfSpindle.Count(e => e.TypeNo == id) > 0;
        }
    }
}