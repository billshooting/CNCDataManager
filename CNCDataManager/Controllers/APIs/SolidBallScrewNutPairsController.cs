using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CNCDataManager.APIs.Models;
using CNCDataManager.Controllers.Internals;
using System.Web.Http.Cors;

namespace CNCDataManager.APIs.Controllers
{
    //[ApiAuthorize]
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    public class SolidBallScrewNutPairsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SolidBallScrewNutPairs
        [AllowAnonymous]
        public IQueryable<SolidBallScrewNutPairs> GetSolidBallScrewNutPairs()
        {
            return db.SolidBallScrewNutPairs;
        }

        // GET: api/SolidBallScrewNutPairs/5
        [AllowAnonymous]
        [ResponseType(typeof(SolidBallScrewNutPairs))]
        public async Task<IHttpActionResult> GetSolidBallScrewNutPairs(string id)
        {
            SolidBallScrewNutPairs solidBallScrewNutPairs = await db.SolidBallScrewNutPairs.FindAsync(id);
            if (solidBallScrewNutPairs == null)
            {
                return NotFound();
            }

            return Ok(solidBallScrewNutPairs);
        }

        // PUT: api/SolidBallScrewNutPairs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSolidBallScrewNutPairs(string id, SolidBallScrewNutPairs solidBallScrewNutPairs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solidBallScrewNutPairs.TypeID)
            {
                return BadRequest();
            }

            db.Entry(solidBallScrewNutPairs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolidBallScrewNutPairsExists(id))
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

        // POST: api/SolidBallScrewNutPairs
        [ResponseType(typeof(SolidBallScrewNutPairs))]
        public async Task<IHttpActionResult> PostSolidBallScrewNutPairs(SolidBallScrewNutPairs solidBallScrewNutPairs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SolidBallScrewNutPairs.Add(solidBallScrewNutPairs);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SolidBallScrewNutPairsExists(solidBallScrewNutPairs.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = solidBallScrewNutPairs.TypeID }, solidBallScrewNutPairs);
        }

        // DELETE: api/SolidBallScrewNutPairs/5
        [ResponseType(typeof(SolidBallScrewNutPairs))]
        public async Task<IHttpActionResult> DeleteSolidBallScrewNutPairs(string id)
        {
            SolidBallScrewNutPairs solidBallScrewNutPairs = await db.SolidBallScrewNutPairs.FindAsync(id);
            if (solidBallScrewNutPairs == null)
            {
                return NotFound();
            }

            db.SolidBallScrewNutPairs.Remove(solidBallScrewNutPairs);
            await db.SaveChangesAsync();

            return Ok(solidBallScrewNutPairs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolidBallScrewNutPairsExists(string id)
        {
            return db.SolidBallScrewNutPairs.Count(e => e.TypeID == id) > 0;
        }
    }
}