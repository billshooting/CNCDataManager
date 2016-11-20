using CNCDataManager.APIs.Models;
using CNCDataManager.APIs.Internals;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace CNCDataManager.APIs.Controllers
{
    //[ApiAuthorize]
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    public class PMSrvMotorSizesController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/PMSrvMotorSizes
        [AllowAnonymous]
        public IQueryable<PMSrvMotorSize> GetPMSrvMotorSizes()
        {
            return db.PMSrvMotorSizes;
        }

        // GET: api/PMSrvMotorSizes/5
        [AllowAnonymous]
        [ResponseType(typeof(PMSrvMotorSize))]
        public async Task<IHttpActionResult> GetPMSrvMotorSize(string id)
        {
            PMSrvMotorSize pMSrvMotorSize = await db.PMSrvMotorSizes.FindAsync(id);
            if (pMSrvMotorSize == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorSize);
        }

        // PUT: api/PMSrvMotorSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPMSrvMotorSize(string id, PMSrvMotorSize pMSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorSizeExists(id))
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

        // POST: api/PMSrvMotorSizes
        [ResponseType(typeof(PMSrvMotorSize))]
        public async Task<IHttpActionResult> PostPMSrvMotorSize(PMSrvMotorSize pMSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PMSrvMotorSizes.Add(pMSrvMotorSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorSizeExists(pMSrvMotorSize.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorSize.TypeID }, pMSrvMotorSize);
        }

        // DELETE: api/PMSrvMotorSizes/5
        [ResponseType(typeof(PMSrvMotorSize))]
        public async Task<IHttpActionResult> DeletePMSrvMotorSize(string id)
        {
            PMSrvMotorSize pMSrvMotorSize = await db.PMSrvMotorSizes.FindAsync(id);
            if (pMSrvMotorSize == null)
            {
                return NotFound();
            }

            db.PMSrvMotorSizes.Remove(pMSrvMotorSize);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorSizeExists(string id)
        {
            return db.PMSrvMotorSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}