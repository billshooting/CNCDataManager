using CNCDataManager.APIs.Models;
using CNCDataManager.APIs.Internals;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CNCDataManager.APIs.Controllers
{
    [ApiAuthorize]
    public class SpindleSrvMotorDriversController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SpindleSrvMotorDrivers
        [AllowAnonymous]
        public IQueryable<SpindleSrvMotorDriver> GetSpindleSrvMotorDrivers()
        {
            return db.SpindleSrvMotorDrivers;
        }

        // GET: api/SpindleSrvMotorDrivers/5
        [AllowAnonymous]
        [ResponseType(typeof(SpindleSrvMotorDriver))]
        public async Task<IHttpActionResult> GetSpindleSrvMotorDriver(string id)
        {
            SpindleSrvMotorDriver spindleSrvMotorDriver = await db.SpindleSrvMotorDrivers.FindAsync(id);
            if (spindleSrvMotorDriver == null)
            {
                return NotFound();
            }

            return Ok(spindleSrvMotorDriver);
        }

        // PUT: api/SpindleSrvMotorDrivers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpindleSrvMotorDriver(string id, SpindleSrvMotorDriver spindleSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleSrvMotorDriver.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleSrvMotorDriver).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleSrvMotorDriverExists(id))
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

        // POST: api/SpindleSrvMotorDrivers
        [ResponseType(typeof(SpindleSrvMotorDriver))]
        public async Task<IHttpActionResult> PostSpindleSrvMotorDriver(SpindleSrvMotorDriver spindleSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleSrvMotorDrivers.Add(spindleSrvMotorDriver);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleSrvMotorDriverExists(spindleSrvMotorDriver.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleSrvMotorDriver.TypeID }, spindleSrvMotorDriver);
        }

        // DELETE: api/SpindleSrvMotorDrivers/5
        [ResponseType(typeof(SpindleSrvMotorDriver))]
        public async Task<IHttpActionResult> DeleteSpindleSrvMotorDriver(string id)
        {
            SpindleSrvMotorDriver spindleSrvMotorDriver = await db.SpindleSrvMotorDrivers.FindAsync(id);
            if (spindleSrvMotorDriver == null)
            {
                return NotFound();
            }

            db.SpindleSrvMotorDrivers.Remove(spindleSrvMotorDriver);
            await db.SaveChangesAsync();

            return Ok(spindleSrvMotorDriver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleSrvMotorDriverExists(string id)
        {
            return db.SpindleSrvMotorDrivers.Count(e => e.TypeID == id) > 0;
        }
    }
}