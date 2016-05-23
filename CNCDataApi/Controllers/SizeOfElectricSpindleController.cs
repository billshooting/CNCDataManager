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
    public class SizeOfElectricSpindleController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/SizeOfElectricSpindle
        public IQueryable<Motor_SizeOfElectricSpindle> GetMotor_SizeOfElectricSpindle()
        {
            return db.Motor_SizeOfElectricSpindle;
        }

        // GET: api/SizeOfElectricSpindle/5
        [ResponseType(typeof(Motor_SizeOfElectricSpindle))]
        public async Task<IHttpActionResult> GetMotor_SizeOfElectricSpindle(string id)
        {
            Motor_SizeOfElectricSpindle motor_SizeOfElectricSpindle = await db.Motor_SizeOfElectricSpindle.FindAsync(id);
            if (motor_SizeOfElectricSpindle == null)
            {
                return NotFound();
            }

            return Ok(motor_SizeOfElectricSpindle);
        }

        // PUT: api/SizeOfElectricSpindle/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMotor_SizeOfElectricSpindle(string id, Motor_SizeOfElectricSpindle motor_SizeOfElectricSpindle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motor_SizeOfElectricSpindle.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(motor_SizeOfElectricSpindle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Motor_SizeOfElectricSpindleExists(id))
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

        // POST: api/SizeOfElectricSpindle
        [ResponseType(typeof(Motor_SizeOfElectricSpindle))]
        public async Task<IHttpActionResult> PostMotor_SizeOfElectricSpindle(Motor_SizeOfElectricSpindle motor_SizeOfElectricSpindle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motor_SizeOfElectricSpindle.Add(motor_SizeOfElectricSpindle);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Motor_SizeOfElectricSpindleExists(motor_SizeOfElectricSpindle.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motor_SizeOfElectricSpindle.TypeNo }, motor_SizeOfElectricSpindle);
        }

        // DELETE: api/SizeOfElectricSpindle/5
        [ResponseType(typeof(Motor_SizeOfElectricSpindle))]
        public async Task<IHttpActionResult> DeleteMotor_SizeOfElectricSpindle(string id)
        {
            Motor_SizeOfElectricSpindle motor_SizeOfElectricSpindle = await db.Motor_SizeOfElectricSpindle.FindAsync(id);
            if (motor_SizeOfElectricSpindle == null)
            {
                return NotFound();
            }

            db.Motor_SizeOfElectricSpindle.Remove(motor_SizeOfElectricSpindle);
            await db.SaveChangesAsync();

            return Ok(motor_SizeOfElectricSpindle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Motor_SizeOfElectricSpindleExists(string id)
        {
            return db.Motor_SizeOfElectricSpindle.Count(e => e.TypeNo == id) > 0;
        }
    }
}