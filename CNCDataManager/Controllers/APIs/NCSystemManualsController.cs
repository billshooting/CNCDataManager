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
    public class NCSystemManualsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/NCSystemManuals
        [AllowAnonymous]
        public IQueryable<NCSystemManual> GetNCSystemManuals()
        {
            return db.NCSystemManuals;
        }

        // GET: api/NCSystemManuals/5
        [AllowAnonymous]
        [ResponseType(typeof(NCSystemManual))]
        public async Task<IHttpActionResult> GetNCSystemManual(string id)
        {
            NCSystemManual nCSystemManual = await db.NCSystemManuals.FindAsync(id);
            if (nCSystemManual == null)
            {
                return NotFound();
            }

            return Ok(nCSystemManual);
        }

        // PUT: api/NCSystemManuals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNCSystemManual(string id, NCSystemManual nCSystemManual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystemManual.TypeID)
            {
                return BadRequest();
            }

            db.Entry(nCSystemManual).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemManualExists(id))
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

        // POST: api/NCSystemManuals
        [ResponseType(typeof(NCSystemManual))]
        public async Task<IHttpActionResult> PostNCSystemManual(NCSystemManual nCSystemManual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystemManuals.Add(nCSystemManual);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemManualExists(nCSystemManual.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSystemManual.TypeID }, nCSystemManual);
        }

        // DELETE: api/NCSystemManuals/5
        [ResponseType(typeof(NCSystemManual))]
        public async Task<IHttpActionResult> DeleteNCSystemManual(string id)
        {
            NCSystemManual nCSystemManual = await db.NCSystemManuals.FindAsync(id);
            if (nCSystemManual == null)
            {
                return NotFound();
            }

            db.NCSystemManuals.Remove(nCSystemManual);
            await db.SaveChangesAsync();

            return Ok(nCSystemManual);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemManualExists(string id)
        {
            return db.NCSystemManuals.Count(e => e.TypeID == id) > 0;
        }
    }
}