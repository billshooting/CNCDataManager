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
    public class NCSystemFunctionalOptionsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/NCSystemFunctionalOptions
        public IQueryable<NCSystemFunctionalOptions> GetNCSystemFunctionalOptions()
        {
            return db.NCSystemFunctionalOptions;
        }

        // GET: api/NCSystemFunctionalOptions/5
        [ResponseType(typeof(NCSystemFunctionalOptions))]
        public async Task<IHttpActionResult> GetNCSystemFunctionalOption(string id)
        {
            NCSystemFunctionalOptions nCSystemFunctionalOptions = await db.NCSystemFunctionalOptions.FindAsync(id);
            if (nCSystemFunctionalOptions == null)
            {
                return NotFound();
            }

            return Ok(nCSystemFunctionalOptions);
        }

        // PUT: api/NCSystemFunctionalOptions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNCSystemFunctionalOption(string id, NCSystemFunctionalOptions nCSystemFunctionalOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystemFunctionalOptions.TypeID)
            {
                return BadRequest();
            }

            db.Entry(nCSystemFunctionalOptions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemFunctionalOptionsExists(id))
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

        // POST: api/NCSystemFunctionalOptions
        [ResponseType(typeof(NCSystemFunctionalOptions))]
        public async Task<IHttpActionResult> PostNCSystemFunctionalOption(NCSystemFunctionalOptions nCSystemFunctionalOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystemFunctionalOptions.Add(nCSystemFunctionalOptions);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemFunctionalOptionsExists(nCSystemFunctionalOptions.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSystemFunctionalOptions.TypeID }, nCSystemFunctionalOptions);
        }

        // DELETE: api/NCSystemFunctionalOptions/5
        [ResponseType(typeof(NCSystemFunctionalOptions))]
        public async Task<IHttpActionResult> DeleteNCSystemFunctionalOption(string id)
        {
            NCSystemFunctionalOptions nCSystemFunctionalOptions = await db.NCSystemFunctionalOptions.FindAsync(id);
            if (nCSystemFunctionalOptions == null)
            {
                return NotFound();
            }

            db.NCSystemFunctionalOptions.Remove(nCSystemFunctionalOptions);
            await db.SaveChangesAsync();

            return Ok(nCSystemFunctionalOptions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemFunctionalOptionsExists(string id)
        {
            return db.NCSystemFunctionalOptions.Count(e => e.TypeID == id) > 0;
        }
    }
}