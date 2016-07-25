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
    public class SpindleSrvMotorSizesController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SpindleSrvMotorSizes
        public IQueryable<SpindleSrvMotorSize> GetSpindleSrvMotorSizes()
        {
            return db.SpindleSrvMotorSizes;
        }

        // GET: api/SpindleSrvMotorSizes/5
        [ResponseType(typeof(SpindleSrvMotorSize))]
        public async Task<IHttpActionResult> GetSpindleSrvMotorSize(string id)
        {
            SpindleSrvMotorSize spindleSrvMotorSize = await db.SpindleSrvMotorSizes.FindAsync(id);
            if (spindleSrvMotorSize == null)
            {
                return NotFound();
            }

            return Ok(spindleSrvMotorSize);
        }

        // PUT: api/SpindleSrvMotorSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpindleSrvMotorSize(string id, SpindleSrvMotorSize spindleSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleSrvMotorSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleSrvMotorSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleSrvMotorSizeExists(id))
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

        // POST: api/SpindleSrvMotorSizes
        [ResponseType(typeof(SpindleSrvMotorSize))]
        public async Task<IHttpActionResult> PostSpindleSrvMotorSize(SpindleSrvMotorSize spindleSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleSrvMotorSizes.Add(spindleSrvMotorSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleSrvMotorSizeExists(spindleSrvMotorSize.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleSrvMotorSize.TypeID }, spindleSrvMotorSize);
        }

        // DELETE: api/SpindleSrvMotorSizes/5
        [ResponseType(typeof(SpindleSrvMotorSize))]
        public async Task<IHttpActionResult> DeleteSpindleSrvMotorSize(string id)
        {
            SpindleSrvMotorSize spindleSrvMotorSize = await db.SpindleSrvMotorSizes.FindAsync(id);
            if (spindleSrvMotorSize == null)
            {
                return NotFound();
            }

            db.SpindleSrvMotorSizes.Remove(spindleSrvMotorSize);
            await db.SaveChangesAsync();

            return Ok(spindleSrvMotorSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleSrvMotorSizeExists(string id)
        {
            return db.SpindleSrvMotorSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}