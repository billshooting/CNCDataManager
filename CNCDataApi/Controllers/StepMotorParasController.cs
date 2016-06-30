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
    public class StepMotorParasController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/StepMotorParas
        public IQueryable<StepMotorPara> GetParaOfStepperMotor()
        {
            return db.ParaOfStepperMotor;
        }

        // GET: api/StepMotorParas/5
        [ResponseType(typeof(StepMotorPara))]
        public async Task<IHttpActionResult> GetStepMotorPara(string id)
        {
            StepMotorPara stepMotorPara = await db.ParaOfStepperMotor.FindAsync(id);
            if (stepMotorPara == null)
            {
                return NotFound();
            }

            return Ok(stepMotorPara);
        }

        // PUT: api/StepMotorParas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStepMotorPara(string id, StepMotorPara stepMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stepMotorPara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(stepMotorPara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepMotorParaExists(id))
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

        // POST: api/StepMotorParas
        [ResponseType(typeof(StepMotorPara))]
        public async Task<IHttpActionResult> PostStepMotorPara(StepMotorPara stepMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParaOfStepperMotor.Add(stepMotorPara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StepMotorParaExists(stepMotorPara.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stepMotorPara.TypeID }, stepMotorPara);
        }

        // DELETE: api/StepMotorParas/5
        [ResponseType(typeof(StepMotorPara))]
        public async Task<IHttpActionResult> DeleteStepMotorPara(string id)
        {
            StepMotorPara stepMotorPara = await db.ParaOfStepperMotor.FindAsync(id);
            if (stepMotorPara == null)
            {
                return NotFound();
            }

            db.ParaOfStepperMotor.Remove(stepMotorPara);
            await db.SaveChangesAsync();

            return Ok(stepMotorPara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StepMotorParaExists(string id)
        {
            return db.ParaOfStepperMotor.Count(e => e.TypeID == id) > 0;
        }
    }
}