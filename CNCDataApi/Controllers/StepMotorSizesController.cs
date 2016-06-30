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
    public class StepMotorSizesController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/StepMotorSizes
        public IQueryable<StepMotorSize> GetSizeOfStepperMotor()
        {
            return db.SizeOfStepperMotor;
        }

        // GET: api/StepMotorSizes/5
        [ResponseType(typeof(StepMotorSize))]
        public async Task<IHttpActionResult> GetStepMotorSize(string id)
        {
            StepMotorSize stepMotorSize = await db.SizeOfStepperMotor.FindAsync(id);
            if (stepMotorSize == null)
            {
                return NotFound();
            }

            return Ok(stepMotorSize);
        }

        // PUT: api/StepMotorSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStepMotorSize(string id, StepMotorSize stepMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stepMotorSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(stepMotorSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepMotorSizeExists(id))
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

        // POST: api/StepMotorSizes
        [ResponseType(typeof(StepMotorSize))]
        public async Task<IHttpActionResult> PostStepMotorSize(StepMotorSize stepMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SizeOfStepperMotor.Add(stepMotorSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StepMotorSizeExists(stepMotorSize.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stepMotorSize.TypeID }, stepMotorSize);
        }

        // DELETE: api/StepMotorSizes/5
        [ResponseType(typeof(StepMotorSize))]
        public async Task<IHttpActionResult> DeleteStepMotorSize(string id)
        {
            StepMotorSize stepMotorSize = await db.SizeOfStepperMotor.FindAsync(id);
            if (stepMotorSize == null)
            {
                return NotFound();
            }

            db.SizeOfStepperMotor.Remove(stepMotorSize);
            await db.SaveChangesAsync();

            return Ok(stepMotorSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StepMotorSizeExists(string id)
        {
            return db.SizeOfStepperMotor.Count(e => e.TypeID == id) > 0;
        }
    }
}