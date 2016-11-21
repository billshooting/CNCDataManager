using CNCDataManager.APIs.Models;
using CNCDataManager.Controllers.Internals;
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
    public class BallLeadScrewSptBrgsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/BallLeadScrewSptBrgs
        [AllowAnonymous]
        public IQueryable<BallLeadScrewSptBrg> GetBallLeadScrewSptBearings()
        {
            return db.BallLeadScrewSptBearings;
        }

        // GET: api/BallLeadScrewSptBrgs/5
        [ResponseType(typeof(BallLeadScrewSptBrg))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetBallLeadScrewSptBrg(string id)
        {
            BallLeadScrewSptBrg ballLeadScrewSptBrg = await db.BallLeadScrewSptBearings.FindAsync(id);
            if (ballLeadScrewSptBrg == null)
            {
                return NotFound();
            }

            return Ok(ballLeadScrewSptBrg);
        }

        // PUT: api/BallLeadScrewSptBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBallLeadScrewSptBrg(string id, BallLeadScrewSptBrg ballLeadScrewSptBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ballLeadScrewSptBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(ballLeadScrewSptBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BallLeadScrewSptBrgExists(id))
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

        // POST: api/BallLeadScrewSptBrgs
        [ResponseType(typeof(BallLeadScrewSptBrg))]
        public async Task<IHttpActionResult> PostBallLeadScrewSptBrg(BallLeadScrewSptBrg ballLeadScrewSptBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BallLeadScrewSptBearings.Add(ballLeadScrewSptBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BallLeadScrewSptBrgExists(ballLeadScrewSptBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ballLeadScrewSptBrg.TypeID }, ballLeadScrewSptBrg);
        }

        // DELETE: api/BallLeadScrewSptBrgs/5
        [ResponseType(typeof(BallLeadScrewSptBrg))]
        public async Task<IHttpActionResult> DeleteBallLeadScrewSptBrg(string id)
        {
            BallLeadScrewSptBrg ballLeadScrewSptBrg = await db.BallLeadScrewSptBearings.FindAsync(id);
            if (ballLeadScrewSptBrg == null)
            {
                return NotFound();
            }

            db.BallLeadScrewSptBearings.Remove(ballLeadScrewSptBrg);
            await db.SaveChangesAsync();

            return Ok(ballLeadScrewSptBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BallLeadScrewSptBrgExists(string id)
        {
            return db.BallLeadScrewSptBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}