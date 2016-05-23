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
    public class ParaOfStepperMotorController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/ParaOfStepperMotor
        public IQueryable<Motor_ParaOfStepperMotor> GetMotor_ParaOfStepperMotor()
        {
            return db.Motor_ParaOfStepperMotor;
        }

        // GET: api/ParaOfStepperMotor/5
        [ResponseType(typeof(Motor_ParaOfStepperMotor))]
        public async Task<IHttpActionResult> GetMotor_ParaOfStepperMotor(string id)
        {
            Motor_ParaOfStepperMotor motor_ParaOfStepperMotor = await db.Motor_ParaOfStepperMotor.FindAsync(id);
            if (motor_ParaOfStepperMotor == null)
            {
                return NotFound();
            }

            return Ok(motor_ParaOfStepperMotor);
        }

        // PUT: api/ParaOfStepperMotor/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMotor_ParaOfStepperMotor(string id, Motor_ParaOfStepperMotor motor_ParaOfStepperMotor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motor_ParaOfStepperMotor.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(motor_ParaOfStepperMotor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Motor_ParaOfStepperMotorExists(id))
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

        // POST: api/ParaOfStepperMotor
        [ResponseType(typeof(Motor_ParaOfStepperMotor))]
        public async Task<IHttpActionResult> PostMotor_ParaOfStepperMotor(Motor_ParaOfStepperMotor motor_ParaOfStepperMotor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motor_ParaOfStepperMotor.Add(motor_ParaOfStepperMotor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Motor_ParaOfStepperMotorExists(motor_ParaOfStepperMotor.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motor_ParaOfStepperMotor.TypeNo }, motor_ParaOfStepperMotor);
        }

        // DELETE: api/ParaOfStepperMotor/5
        [ResponseType(typeof(Motor_ParaOfStepperMotor))]
        public async Task<IHttpActionResult> DeleteMotor_ParaOfStepperMotor(string id)
        {
            Motor_ParaOfStepperMotor motor_ParaOfStepperMotor = await db.Motor_ParaOfStepperMotor.FindAsync(id);
            if (motor_ParaOfStepperMotor == null)
            {
                return NotFound();
            }

            db.Motor_ParaOfStepperMotor.Remove(motor_ParaOfStepperMotor);
            await db.SaveChangesAsync();

            return Ok(motor_ParaOfStepperMotor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Motor_ParaOfStepperMotorExists(string id)
        {
            return db.Motor_ParaOfStepperMotor.Count(e => e.TypeNo == id) > 0;
        }
    }
}