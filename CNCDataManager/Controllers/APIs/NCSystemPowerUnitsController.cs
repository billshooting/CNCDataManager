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
    public class NCSystemPowerUnitsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/NCSystemPowerUnits
        [AllowAnonymous]
        public IQueryable<NCSystemPowerUnit> GetNCSystemPowerUnits()
        {
            return db.NCSystemPowerUnits;
        }

        // GET: api/NCSystemPowerUnits/5
        [AllowAnonymous]
        [ResponseType(typeof(NCSystemPowerUnit))]
        public async Task<IHttpActionResult> GetNCSystemPowerUnit(string id)
        {
            NCSystemPowerUnit nCSystemPowerUnit = await db.NCSystemPowerUnits.FindAsync(id);
            if (nCSystemPowerUnit == null)
            {
                return NotFound();
            }

            return Ok(nCSystemPowerUnit);
        }

        // PUT: api/NCSystemPowerUnits/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNCSystemPowerUnit(string id, NCSystemPowerUnit nCSystemPowerUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystemPowerUnit.TypeID)
            {
                return BadRequest();
            }

            db.Entry(nCSystemPowerUnit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemPowerUnitExists(id))
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

        // POST: api/NCSystemPowerUnits
        [ResponseType(typeof(NCSystemPowerUnit))]
        public async Task<IHttpActionResult> PostNCSystemPowerUnit(NCSystemPowerUnit nCSystemPowerUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystemPowerUnits.Add(nCSystemPowerUnit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemPowerUnitExists(nCSystemPowerUnit.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSystemPowerUnit.TypeID }, nCSystemPowerUnit);
        }

        // DELETE: api/NCSystemPowerUnits/5
        [ResponseType(typeof(NCSystemPowerUnit))]
        public async Task<IHttpActionResult> DeleteNCSystemPowerUnit(string id)
        {
            NCSystemPowerUnit nCSystemPowerUnit = await db.NCSystemPowerUnits.FindAsync(id);
            if (nCSystemPowerUnit == null)
            {
                return NotFound();
            }

            db.NCSystemPowerUnits.Remove(nCSystemPowerUnit);
            await db.SaveChangesAsync();

            return Ok(nCSystemPowerUnit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemPowerUnitExists(string id)
        {
            return db.NCSystemPowerUnits.Count(e => e.TypeID == id) > 0;
        }
    }
}