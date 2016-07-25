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
    public class SpurGearsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SpurGears
        public IQueryable<SpurGear> GetSpurGears()
        {
            return db.SpurGears;
        }

        // GET: api/SpurGears/5
        [ResponseType(typeof(SpurGear))]
        public async Task<IHttpActionResult> GetSpurGear(string id)
        {
            SpurGear spurGear = await db.SpurGears.FindAsync(id);
            if (spurGear == null)
            {
                return NotFound();
            }

            return Ok(spurGear);
        }

        // PUT: api/SpurGears/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpurGear(string id, SpurGear spurGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spurGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spurGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpurGearExists(id))
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

        // POST: api/SpurGears
        [ResponseType(typeof(SpurGear))]
        public async Task<IHttpActionResult> PostSpurGear(SpurGear spurGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpurGears.Add(spurGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpurGearExists(spurGear.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spurGear.TypeID }, spurGear);
        }

        // DELETE: api/SpurGears/5
        [ResponseType(typeof(SpurGear))]
        public async Task<IHttpActionResult> DeleteSpurGear(string id)
        {
            SpurGear spurGear = await db.SpurGears.FindAsync(id);
            if (spurGear == null)
            {
                return NotFound();
            }

            db.SpurGears.Remove(spurGear);
            await db.SaveChangesAsync();

            return Ok(spurGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpurGearExists(string id)
        {
            return db.SpurGears.Count(e => e.TypeID == id) > 0;
        }
    }
}