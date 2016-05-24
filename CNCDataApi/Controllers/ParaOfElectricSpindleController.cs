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
    public class ParaOfElectricSpindleController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/ParaOfElectricSpindle
        public IQueryable<Motor_ParaOfElectricSpindle> GetMotor_ParaOfElectricSpindle()
        {
            return db.Motor_ParaOfElectricSpindle;
        }

        // GET: api/ParaOfElectricSpindle/5
        [ResponseType(typeof(Motor_ParaOfElectricSpindle))]
        public async Task<IHttpActionResult> GetMotor_ParaOfElectricSpindle(string id)
        {
            Motor_ParaOfElectricSpindle motor_ParaOfElectricSpindle = await db.Motor_ParaOfElectricSpindle.FindAsync(id);
            if (motor_ParaOfElectricSpindle == null)
            {
                return NotFound();
            }

            return Ok(motor_ParaOfElectricSpindle);
        }

        // PUT: api/ParaOfElectricSpindle/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMotor_ParaOfElectricSpindle(string id, Motor_ParaOfElectricSpindle motor_ParaOfElectricSpindle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motor_ParaOfElectricSpindle.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(motor_ParaOfElectricSpindle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Motor_ParaOfElectricSpindleExists(id))
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

        // POST: api/ParaOfElectricSpindle
        [ResponseType(typeof(Motor_ParaOfElectricSpindle))]
        public async Task<IHttpActionResult> PostMotor_ParaOfElectricSpindle(Motor_ParaOfElectricSpindle motor_ParaOfElectricSpindle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motor_ParaOfElectricSpindle.Add(motor_ParaOfElectricSpindle);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Motor_ParaOfElectricSpindleExists(motor_ParaOfElectricSpindle.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motor_ParaOfElectricSpindle.TypeNo }, motor_ParaOfElectricSpindle);
        }

        // DELETE: api/ParaOfElectricSpindle/5
        [ResponseType(typeof(Motor_ParaOfElectricSpindle))]
        public async Task<IHttpActionResult> DeleteMotor_ParaOfElectricSpindle(string id)
        {
            Motor_ParaOfElectricSpindle motor_ParaOfElectricSpindle = await db.Motor_ParaOfElectricSpindle.FindAsync(id);
            if (motor_ParaOfElectricSpindle == null)
            {
                return NotFound();
            }

            db.Motor_ParaOfElectricSpindle.Remove(motor_ParaOfElectricSpindle);
            await db.SaveChangesAsync();

            return Ok(motor_ParaOfElectricSpindle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Motor_ParaOfElectricSpindleExists(string id)
        {
            return db.Motor_ParaOfElectricSpindle.Count(e => e.TypeNo == id) > 0;
        }
    }
}