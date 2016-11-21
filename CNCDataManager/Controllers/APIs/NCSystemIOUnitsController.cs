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
    public class NCSystemIOUnitsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/NCSystemIOUnits
        [AllowAnonymous]
        public IQueryable<NCSystemIOUnit> GetNCSystemIOUnits()
        {
            return db.NCSystemIOUnits;
        }

        // GET: api/NCSystemIOUnits/5
        [AllowAnonymous]
        [ResponseType(typeof(NCSystemIOUnit))]
        public async Task<IHttpActionResult> GetNCSystemIOUnit(string id)
        {
            NCSystemIOUnit nCSystemIOUnit = await db.NCSystemIOUnits.FindAsync(id);
            if (nCSystemIOUnit == null)
            {
                return NotFound();
            }

            return Ok(nCSystemIOUnit);
        }

        // PUT: api/NCSystemIOUnits/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNCSystemIOUnit(string id, NCSystemIOUnit nCSystemIOUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystemIOUnit.TypeID)
            {
                return BadRequest();
            }

            db.Entry(nCSystemIOUnit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemIOUnitExists(id))
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

        // POST: api/NCSystemIOUnits
        [ResponseType(typeof(NCSystemIOUnit))]
        public async Task<IHttpActionResult> PostNCSystemIOUnit(NCSystemIOUnit nCSystemIOUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystemIOUnits.Add(nCSystemIOUnit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemIOUnitExists(nCSystemIOUnit.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSystemIOUnit.TypeID }, nCSystemIOUnit);
        }

        // DELETE: api/NCSystemIOUnits/5
        [ResponseType(typeof(NCSystemIOUnit))]
        public async Task<IHttpActionResult> DeleteNCSystemIOUnit(string id)
        {
            NCSystemIOUnit nCSystemIOUnit = await db.NCSystemIOUnits.FindAsync(id);
            if (nCSystemIOUnit == null)
            {
                return NotFound();
            }

            db.NCSystemIOUnits.Remove(nCSystemIOUnit);
            await db.SaveChangesAsync();

            return Ok(nCSystemIOUnit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemIOUnitExists(string id)
        {
            return db.NCSystemIOUnits.Count(e => e.TypeID == id) > 0;
        }
    }
}