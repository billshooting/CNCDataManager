using CNCDataManager.APIs.Models;
using CNCDataManager.Controllers.Internals;
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
    public class PMSrvMotorDriversController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/PMSrvMotorDrivers
        [AllowAnonymous]
        public IQueryable<PMSrvMotorDriver> GetPMSrvMotorDrivers()
        {
            return db.PMSrvMotorDrivers;
        }

        // GET: api/PMSrvMotorDrivers/5
        [AllowAnonymous]
        [ResponseType(typeof(PMSrvMotorDriver))]
        public async Task<IHttpActionResult> GetPMSrvMotorDriver(string id)
        {
            PMSrvMotorDriver pMSrvMotorDriver = await db.PMSrvMotorDrivers.FindAsync(id);
            if (pMSrvMotorDriver == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorDriver);
        }

        // PUT: api/PMSrvMotorDrivers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPMSrvMotorDriver(string id, PMSrvMotorDriver pMSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorDriver.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorDriver).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorDriverExists(id))
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

        // POST: api/PMSrvMotorDrivers
        [ResponseType(typeof(PMSrvMotorDriver))]
        public async Task<IHttpActionResult> PostPMSrvMotorDriver(PMSrvMotorDriver pMSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PMSrvMotorDrivers.Add(pMSrvMotorDriver);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorDriverExists(pMSrvMotorDriver.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorDriver.TypeID }, pMSrvMotorDriver);
        }

        // DELETE: api/PMSrvMotorDrivers/5
        [ResponseType(typeof(PMSrvMotorDriver))]
        public async Task<IHttpActionResult> DeletePMSrvMotorDriver(string id)
        {
            PMSrvMotorDriver pMSrvMotorDriver = await db.PMSrvMotorDrivers.FindAsync(id);
            if (pMSrvMotorDriver == null)
            {
                return NotFound();
            }

            db.PMSrvMotorDrivers.Remove(pMSrvMotorDriver);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorDriver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorDriverExists(string id)
        {
            return db.PMSrvMotorDrivers.Count(e => e.TypeID == id) > 0;
        }
    }
}