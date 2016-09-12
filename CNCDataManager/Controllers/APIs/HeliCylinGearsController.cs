using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CNCDataManager.APIs.Models;
using CNCDataManager.Controllers.Internals;

namespace CNCDataManager.APIs.Controllers
{
    //[ApiAuthorize]
    public class HeliCylinGearsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/HeliCylinGears
        [AllowAnonymous]
        public IQueryable<HeliCylinGear> GetHeliCylinGears()
        {
            return db.HeliCylinGears;
        }

        // GET: api/HeliCylinGears/5
        [AllowAnonymous]
        [ResponseType(typeof(HeliCylinGear))]
        public async Task<IHttpActionResult> GetHeliCylinGear(string id)
        {
            HeliCylinGear heliCylinGear = await db.HeliCylinGears.FindAsync(id);
            if (heliCylinGear == null)
            {
                return NotFound();
            }

            return Ok(heliCylinGear);
        }

        // PUT: api/HeliCylinGears/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHeliCylinGear(string id, HeliCylinGear heliCylinGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heliCylinGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(heliCylinGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeliCylinGearExists(id))
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

        // POST: api/HeliCylinGears
        [ResponseType(typeof(HeliCylinGear))]
        public async Task<IHttpActionResult> PostHeliCylinGear(HeliCylinGear heliCylinGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HeliCylinGears.Add(heliCylinGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeliCylinGearExists(heliCylinGear.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = heliCylinGear.TypeID }, heliCylinGear);
        }

        // DELETE: api/HeliCylinGears/5
        [ResponseType(typeof(HeliCylinGear))]
        public async Task<IHttpActionResult> DeleteHeliCylinGear(string id)
        {
            HeliCylinGear heliCylinGear = await db.HeliCylinGears.FindAsync(id);
            if (heliCylinGear == null)
            {
                return NotFound();
            }

            db.HeliCylinGears.Remove(heliCylinGear);
            await db.SaveChangesAsync();

            return Ok(heliCylinGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeliCylinGearExists(string id)
        {
            return db.HeliCylinGears.Count(e => e.TypeID == id) > 0;
        }
    }
}