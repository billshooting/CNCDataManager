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
    public class FlangeCoupsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/FlangeCoups
        [AllowAnonymous]
        public IQueryable<FlangeCoup> GetFlangeCouplings()
        {
            return db.FlangeCouplings;
        }

        // GET: api/FlangeCoups/5
        [AllowAnonymous]
        [ResponseType(typeof(FlangeCoup))]
        public async Task<IHttpActionResult> GetFlangeCoup(string id)
        {
            FlangeCoup flangeCoup = await db.FlangeCouplings.FindAsync(id);
            if (flangeCoup == null)
            {
                return NotFound();
            }

            return Ok(flangeCoup);
        }

        // PUT: api/FlangeCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFlangeCoup(string id, FlangeCoup flangeCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flangeCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(flangeCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlangeCoupExists(id))
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

        // POST: api/FlangeCoups
        [ResponseType(typeof(FlangeCoup))]
        public async Task<IHttpActionResult> PostFlangeCoup(FlangeCoup flangeCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlangeCouplings.Add(flangeCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlangeCoupExists(flangeCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = flangeCoup.TypeID }, flangeCoup);
        }

        // DELETE: api/FlangeCoups/5
        [ResponseType(typeof(FlangeCoup))]
        public async Task<IHttpActionResult> DeleteFlangeCoup(string id)
        {
            FlangeCoup flangeCoup = await db.FlangeCouplings.FindAsync(id);
            if (flangeCoup == null)
            {
                return NotFound();
            }

            db.FlangeCouplings.Remove(flangeCoup);
            await db.SaveChangesAsync();

            return Ok(flangeCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlangeCoupExists(string id)
        {
            return db.FlangeCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}