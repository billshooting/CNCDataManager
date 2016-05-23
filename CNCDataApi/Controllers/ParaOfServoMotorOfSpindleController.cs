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
    public class ParaOfServoMotorOfSpindleController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/ParaOfServoMotorOfSpindle
        public IQueryable<Motor_ParaOfServoMotorOfSpindle> GetMotor_ParaOfServoMotorOfSpindle()
        {
            return db.Motor_ParaOfServoMotorOfSpindle;
        }

        // GET: api/ParaOfServoMotorOfSpindle/5
        [ResponseType(typeof(Motor_ParaOfServoMotorOfSpindle))]
        public async Task<IHttpActionResult> GetMotor_ParaOfServoMotorOfSpindle(string id)
        {
            Motor_ParaOfServoMotorOfSpindle motor_ParaOfServoMotorOfSpindle = await db.Motor_ParaOfServoMotorOfSpindle.FindAsync(id);
            if (motor_ParaOfServoMotorOfSpindle == null)
            {
                return NotFound();
            }

            return Ok(motor_ParaOfServoMotorOfSpindle);
        }

        // PUT: api/ParaOfServoMotorOfSpindle/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMotor_ParaOfServoMotorOfSpindle(string id, Motor_ParaOfServoMotorOfSpindle motor_ParaOfServoMotorOfSpindle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motor_ParaOfServoMotorOfSpindle.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(motor_ParaOfServoMotorOfSpindle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Motor_ParaOfServoMotorOfSpindleExists(id))
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

        // POST: api/ParaOfServoMotorOfSpindle
        [ResponseType(typeof(Motor_ParaOfServoMotorOfSpindle))]
        public async Task<IHttpActionResult> PostMotor_ParaOfServoMotorOfSpindle(Motor_ParaOfServoMotorOfSpindle motor_ParaOfServoMotorOfSpindle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motor_ParaOfServoMotorOfSpindle.Add(motor_ParaOfServoMotorOfSpindle);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Motor_ParaOfServoMotorOfSpindleExists(motor_ParaOfServoMotorOfSpindle.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motor_ParaOfServoMotorOfSpindle.TypeNo }, motor_ParaOfServoMotorOfSpindle);
        }

        // DELETE: api/ParaOfServoMotorOfSpindle/5
        [ResponseType(typeof(Motor_ParaOfServoMotorOfSpindle))]
        public async Task<IHttpActionResult> DeleteMotor_ParaOfServoMotorOfSpindle(string id)
        {
            Motor_ParaOfServoMotorOfSpindle motor_ParaOfServoMotorOfSpindle = await db.Motor_ParaOfServoMotorOfSpindle.FindAsync(id);
            if (motor_ParaOfServoMotorOfSpindle == null)
            {
                return NotFound();
            }

            db.Motor_ParaOfServoMotorOfSpindle.Remove(motor_ParaOfServoMotorOfSpindle);
            await db.SaveChangesAsync();

            return Ok(motor_ParaOfServoMotorOfSpindle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Motor_ParaOfServoMotorOfSpindleExists(string id)
        {
            return db.Motor_ParaOfServoMotorOfSpindle.Count(e => e.TypeNo == id) > 0;
        }
    }
}