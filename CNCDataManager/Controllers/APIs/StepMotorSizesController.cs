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
    public class StepMotorSizesController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/StepMotorSizes
        public IQueryable<StepMotorSize> GetStepMotorSizes()
        {
            return db.StepMotorSizes;
        }

        // GET: api/StepMotorSizes/5
        [ResponseType(typeof(StepMotorSize))]
        public async Task<IHttpActionResult> GetStepMotorSize(string id)
        {
            StepMotorSize stepMotorSize = await db.StepMotorSizes.FindAsync(id);
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

            db.StepMotorSizes.Add(stepMotorSize);

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
            StepMotorSize stepMotorSize = await db.StepMotorSizes.FindAsync(id);
            if (stepMotorSize == null)
            {
                return NotFound();
            }

            db.StepMotorSizes.Remove(stepMotorSize);
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
            return db.StepMotorSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}