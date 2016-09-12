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
    public class DeepGrooveBallBrgsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/DeepGrooveBallBrgs
        [AllowAnonymous]
        public IQueryable<DeepGrooveBallBrg> GetDeepGrooveBallBearings()
        {
            return db.DeepGrooveBallBearings;
        }

        // GET: api/DeepGrooveBallBrgs/5
        [AllowAnonymous]
        [ResponseType(typeof(DeepGrooveBallBrg))]
        public async Task<IHttpActionResult> GetDeepGrooveBallBrg(string id)
        {
            DeepGrooveBallBrg deepGrooveBallBrg = await db.DeepGrooveBallBearings.FindAsync(id);
            if (deepGrooveBallBrg == null)
            {
                return NotFound();
            }

            return Ok(deepGrooveBallBrg);
        }

        // PUT: api/DeepGrooveBallBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeepGrooveBallBrg(string id, DeepGrooveBallBrg deepGrooveBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deepGrooveBallBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(deepGrooveBallBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeepGrooveBallBrgExists(id))
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

        // POST: api/DeepGrooveBallBrgs
        [ResponseType(typeof(DeepGrooveBallBrg))]
        public async Task<IHttpActionResult> PostDeepGrooveBallBrg(DeepGrooveBallBrg deepGrooveBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeepGrooveBallBearings.Add(deepGrooveBallBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeepGrooveBallBrgExists(deepGrooveBallBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deepGrooveBallBrg.TypeID }, deepGrooveBallBrg);
        }

        // DELETE: api/DeepGrooveBallBrgs/5
        [ResponseType(typeof(DeepGrooveBallBrg))]
        public async Task<IHttpActionResult> DeleteDeepGrooveBallBrg(string id)
        {
            DeepGrooveBallBrg deepGrooveBallBrg = await db.DeepGrooveBallBearings.FindAsync(id);
            if (deepGrooveBallBrg == null)
            {
                return NotFound();
            }

            db.DeepGrooveBallBearings.Remove(deepGrooveBallBrg);
            await db.SaveChangesAsync();

            return Ok(deepGrooveBallBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeepGrooveBallBrgExists(string id)
        {
            return db.DeepGrooveBallBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}