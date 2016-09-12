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
    public class CablesController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/Cables
        [AllowAnonymous]
        public IQueryable<Cables> GetCables()
        {
            return db.Cables;
        }

        // GET: api/Cables/5
        [AllowAnonymous]
        [ResponseType(typeof(Cables))]
        public async Task<IHttpActionResult> GetCables(string id)
        {
            Cables cables = await db.Cables.FindAsync(id);
            if (cables == null)
            {
                return NotFound();
            }

            return Ok(cables);
        }

        // PUT: api/Cables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCables(string id, Cables cables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cables.TypeID)
            {
                return BadRequest();
            }

            db.Entry(cables).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CablesExists(id))
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

        // POST: api/Cables
        [ResponseType(typeof(Cables))]
        public async Task<IHttpActionResult> PostCables(Cables cables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cables.Add(cables);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CablesExists(cables.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cables.TypeID }, cables);
        }

        // DELETE: api/Cables/5
        [ResponseType(typeof(Cables))]
        public async Task<IHttpActionResult> DeleteCables(string id)
        {
            Cables cables = await db.Cables.FindAsync(id);
            if (cables == null)
            {
                return NotFound();
            }

            db.Cables.Remove(cables);
            await db.SaveChangesAsync();

            return Ok(cables);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CablesExists(string id)
        {
            return db.Cables.Count(e => e.TypeID == id) > 0;
        }
    }
}