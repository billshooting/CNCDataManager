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
    public class SizeOfStepperMotorController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/SizeOfStepperMotor
        public IQueryable<Motor_SizeOfStepperMotor> GetMotor_SizeOfStepperMotor()
        {
            return db.Motor_SizeOfStepperMotor;
        }

        // GET: api/SizeOfStepperMotor/5
        [ResponseType(typeof(Motor_SizeOfStepperMotor))]
        public async Task<IHttpActionResult> GetMotor_SizeOfStepperMotor(string id)
        {
            Motor_SizeOfStepperMotor motor_SizeOfStepperMotor = await db.Motor_SizeOfStepperMotor.FindAsync(id);
            if (motor_SizeOfStepperMotor == null)
            {
                return NotFound();
            }

            return Ok(motor_SizeOfStepperMotor);
        }

        // PUT: api/SizeOfStepperMotor/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMotor_SizeOfStepperMotor(string id, Motor_SizeOfStepperMotor motor_SizeOfStepperMotor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motor_SizeOfStepperMotor.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(motor_SizeOfStepperMotor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Motor_SizeOfStepperMotorExists(id))
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

        // POST: api/SizeOfStepperMotor
        [ResponseType(typeof(Motor_SizeOfStepperMotor))]
        public async Task<IHttpActionResult> PostMotor_SizeOfStepperMotor(Motor_SizeOfStepperMotor motor_SizeOfStepperMotor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motor_SizeOfStepperMotor.Add(motor_SizeOfStepperMotor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Motor_SizeOfStepperMotorExists(motor_SizeOfStepperMotor.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motor_SizeOfStepperMotor.TypeNo }, motor_SizeOfStepperMotor);
        }

        // DELETE: api/SizeOfStepperMotor/5
        [ResponseType(typeof(Motor_SizeOfStepperMotor))]
        public async Task<IHttpActionResult> DeleteMotor_SizeOfStepperMotor(string id)
        {
            Motor_SizeOfStepperMotor motor_SizeOfStepperMotor = await db.Motor_SizeOfStepperMotor.FindAsync(id);
            if (motor_SizeOfStepperMotor == null)
            {
                return NotFound();
            }

            db.Motor_SizeOfStepperMotor.Remove(motor_SizeOfStepperMotor);
            await db.SaveChangesAsync();

            return Ok(motor_SizeOfStepperMotor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Motor_SizeOfStepperMotorExists(string id)
        {
            return db.Motor_SizeOfStepperMotor.Count(e => e.TypeNo == id) > 0;
        }
    }
}