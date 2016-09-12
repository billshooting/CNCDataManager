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
    public class ElecSpindleSizesController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/ElecSpindleSizes
        [AllowAnonymous]
        public IQueryable<ElecSpindleSize> GetElecSpindleSizes()
        {
            return db.ElecSpindleSizes;
        }

        // GET: api/ElecSpindleSizes/5
        [AllowAnonymous]
        [ResponseType(typeof(ElecSpindleSize))]
        public async Task<IHttpActionResult> GetElecSpindleSize(string id)
        {
            ElecSpindleSize elecSpindleSize = await db.ElecSpindleSizes.FindAsync(id);
            if (elecSpindleSize == null)
            {
                return NotFound();
            }

            return Ok(elecSpindleSize);
        }

        // PUT: api/ElecSpindleSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElecSpindleSize(string id, ElecSpindleSize elecSpindleSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elecSpindleSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(elecSpindleSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElecSpindleSizeExists(id))
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

        // POST: api/ElecSpindleSizes
        [ResponseType(typeof(ElecSpindleSize))]
        public async Task<IHttpActionResult> PostElecSpindleSize(ElecSpindleSize elecSpindleSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ElecSpindleSizes.Add(elecSpindleSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ElecSpindleSizeExists(elecSpindleSize.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elecSpindleSize.TypeID }, elecSpindleSize);
        }

        // DELETE: api/ElecSpindleSizes/5
        [ResponseType(typeof(ElecSpindleSize))]
        public async Task<IHttpActionResult> DeleteElecSpindleSize(string id)
        {
            ElecSpindleSize elecSpindleSize = await db.ElecSpindleSizes.FindAsync(id);
            if (elecSpindleSize == null)
            {
                return NotFound();
            }

            db.ElecSpindleSizes.Remove(elecSpindleSize);
            await db.SaveChangesAsync();

            return Ok(elecSpindleSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElecSpindleSizeExists(string id)
        {
            return db.ElecSpindleSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}