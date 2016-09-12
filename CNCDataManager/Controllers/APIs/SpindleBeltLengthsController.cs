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
    //[ApiAuthorize]
    public class SpindleBeltLengthsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SpindleBeltLengths
        [AllowAnonymous]
        public IQueryable<SpindleBeltLength> GetSpindleBeltLengths()
        {
            return db.SpindleBeltLengths;
        }

        // GET: api/SpindleBeltLengths/5
        [AllowAnonymous]
        [ResponseType(typeof(SpindleBeltLength))]
        public async Task<IHttpActionResult> GetSpindleBeltLength(int id)
        {
            SpindleBeltLength spindleBeltLength = await db.SpindleBeltLengths.FindAsync(id);
            if (spindleBeltLength == null)
            {
                return NotFound();
            }

            return Ok(spindleBeltLength);
        }

        // PUT: api/SpindleBeltLengths/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpindleBeltLength(int id, SpindleBeltLength spindleBeltLength)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleBeltLength.LengthID)
            {
                return BadRequest();
            }

            db.Entry(spindleBeltLength).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleBeltLengthExists(id))
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

        // POST: api/SpindleBeltLengths
        [ResponseType(typeof(SpindleBeltLength))]
        public async Task<IHttpActionResult> PostSpindleBeltLength(SpindleBeltLength spindleBeltLength)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleBeltLengths.Add(spindleBeltLength);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleBeltLengthExists(spindleBeltLength.LengthID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleBeltLength.LengthID }, spindleBeltLength);
        }

        // DELETE: api/SpindleBeltLengths/5
        [ResponseType(typeof(SpindleBeltLength))]
        public async Task<IHttpActionResult> DeleteSpindleBeltLength(int id)
        {
            SpindleBeltLength spindleBeltLength = await db.SpindleBeltLengths.FindAsync(id);
            if (spindleBeltLength == null)
            {
                return NotFound();
            }

            db.SpindleBeltLengths.Remove(spindleBeltLength);
            await db.SaveChangesAsync();

            return Ok(spindleBeltLength);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleBeltLengthExists(int id)
        {
            return db.SpindleBeltLengths.Count(e => e.LengthID == id) > 0;
        }
    }
}