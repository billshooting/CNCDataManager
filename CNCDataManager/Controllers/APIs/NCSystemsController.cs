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
    [ApiAuthorize]
    public class NCSystemsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/NCSystems
        [AllowAnonymous]
        public IQueryable<NCSystem> GetNCSystems()
        {
            return db.NCSystems;
        }

        // GET: api/NCSystems/5
        [AllowAnonymous]
        [ResponseType(typeof(NCSystem))]
        public async Task<IHttpActionResult> GetNCSystem(int id)
        {
            NCSystem nCSystem = await db.NCSystems.FindAsync(id);
            if (nCSystem == null)
            {
                return NotFound();
            }

            return Ok(nCSystem);
        }

        // PUT: api/NCSystems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNCSystem(int id, NCSystem nCSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystem.Id)
            {
                return BadRequest();
            }

            db.Entry(nCSystem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemExists(id))
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

        // POST: api/NCSystems
        [ResponseType(typeof(NCSystem))]
        public async Task<IHttpActionResult> PostNCSystem(NCSystem nCSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystems.Add(nCSystem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = nCSystem.Id }, nCSystem);
        }

        // DELETE: api/NCSystems/5
        [ResponseType(typeof(NCSystem))]
        public async Task<IHttpActionResult> DeleteNCSystem(int id)
        {
            NCSystem nCSystem = await db.NCSystems.FindAsync(id);
            if (nCSystem == null)
            {
                return NotFound();
            }

            db.NCSystems.Remove(nCSystem);
            await db.SaveChangesAsync();

            return Ok(nCSystem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemExists(int id)
        {
            return db.NCSystems.Count(e => e.Id == id) > 0;
        }
    }
}