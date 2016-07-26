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
    public class BWElasticSlvPinCoupsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/BWElasticSlvPinCoups
        [AllowAnonymous]
        public IQueryable<BWElasticSlvPinCoup> GetBWElasticSlvPinCouplings()
        {
            return db.BWElasticSlvPinCouplings;
        }

        // GET: api/BWElasticSlvPinCoups/5
        [AllowAnonymous]
        [ResponseType(typeof(BWElasticSlvPinCoup))]
        public async Task<IHttpActionResult> GetBWElasticSlvPinCoup(string id)
        {
            BWElasticSlvPinCoup bWElasticSlvPinCoup = await db.BWElasticSlvPinCouplings.FindAsync(id);
            if (bWElasticSlvPinCoup == null)
            {
                return NotFound();
            }

            return Ok(bWElasticSlvPinCoup);
        }

        // PUT: api/BWElasticSlvPinCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBWElasticSlvPinCoup(string id, BWElasticSlvPinCoup bWElasticSlvPinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bWElasticSlvPinCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(bWElasticSlvPinCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BWElasticSlvPinCoupExists(id))
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

        // POST: api/BWElasticSlvPinCoups
        [ResponseType(typeof(BWElasticSlvPinCoup))]
        public async Task<IHttpActionResult> PostBWElasticSlvPinCoup(BWElasticSlvPinCoup bWElasticSlvPinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BWElasticSlvPinCouplings.Add(bWElasticSlvPinCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BWElasticSlvPinCoupExists(bWElasticSlvPinCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bWElasticSlvPinCoup.TypeID }, bWElasticSlvPinCoup);
        }

        // DELETE: api/BWElasticSlvPinCoups/5
        [ResponseType(typeof(BWElasticSlvPinCoup))]
        public async Task<IHttpActionResult> DeleteBWElasticSlvPinCoup(string id)
        {
            BWElasticSlvPinCoup bWElasticSlvPinCoup = await db.BWElasticSlvPinCouplings.FindAsync(id);
            if (bWElasticSlvPinCoup == null)
            {
                return NotFound();
            }

            db.BWElasticSlvPinCouplings.Remove(bWElasticSlvPinCoup);
            await db.SaveChangesAsync();

            return Ok(bWElasticSlvPinCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BWElasticSlvPinCoupExists(string id)
        {
            return db.BWElasticSlvPinCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}