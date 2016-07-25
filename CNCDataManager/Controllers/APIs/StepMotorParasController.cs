using CNCDataManager.APIs.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CNCDataManager.APIs.Controllers
{
    public class StepMotorParasController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/StepMotorParas
        public IQueryable<StepMotorPara> GetStepMotorParas()
        {
            return db.StepMotorParas;
        }

        // GET: api/StepMotorParas/5
        [ResponseType(typeof(StepMotorPara))]
        public async Task<IHttpActionResult> GetStepMotorPara(string id)
        {
            StepMotorPara stepMotorPara = await db.StepMotorParas.FindAsync(id);
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

            db.StepMotorParas.Add(stepMotorPara);

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
            StepMotorPara stepMotorPara = await db.StepMotorParas.FindAsync(id);
            if (stepMotorPara == null)
            {
                return NotFound();
            }

            db.StepMotorParas.Remove(stepMotorPara);
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
            return db.StepMotorParas.Count(e => e.TypeID == id) > 0;
        }
    }
}