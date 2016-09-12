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
    public class OldhamCoupsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/OldhamCoups
        [AllowAnonymous]
        public IQueryable<OldhamCoup> GetOldhamCouplings()
        {
            return db.OldhamCouplings;
        }

        // GET: api/OldhamCoups/5
        [AllowAnonymous]
        [ResponseType(typeof(OldhamCoup))]
        public async Task<IHttpActionResult> GetOldhamCoup(string id)
        {
            OldhamCoup oldhamCoup = await db.OldhamCouplings.FindAsync(id);
            if (oldhamCoup == null)
            {
                return NotFound();
            }

            return Ok(oldhamCoup);
        }

        // PUT: api/OldhamCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOldhamCoup(string id, OldhamCoup oldhamCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oldhamCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(oldhamCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OldhamCoupExists(id))
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

        // POST: api/OldhamCoups
        [ResponseType(typeof(OldhamCoup))]
        public async Task<IHttpActionResult> PostOldhamCoup(OldhamCoup oldhamCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OldhamCouplings.Add(oldhamCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OldhamCoupExists(oldhamCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oldhamCoup.TypeID }, oldhamCoup);
        }

        // DELETE: api/OldhamCoups/5
        [ResponseType(typeof(OldhamCoup))]
        public async Task<IHttpActionResult> DeleteOldhamCoup(string id)
        {
            OldhamCoup oldhamCoup = await db.OldhamCouplings.FindAsync(id);
            if (oldhamCoup == null)
            {
                return NotFound();
            }

            db.OldhamCouplings.Remove(oldhamCoup);
            await db.SaveChangesAsync();

            return Ok(oldhamCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OldhamCoupExists(string id)
        {
            return db.OldhamCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}