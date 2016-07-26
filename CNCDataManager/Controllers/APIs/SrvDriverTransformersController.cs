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
    public class SrvDriverTransformersController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SrvDriverTransformers
        [AllowAnonymous]
        public IQueryable<SrvDriverTransformer> GetSrvDriverTransformers()
        {
            return db.SrvDriverTransformers;
        }

        // GET: api/SrvDriverTransformers/5
        [AllowAnonymous]
        [ResponseType(typeof(SrvDriverTransformer))]
        public async Task<IHttpActionResult> GetSrvDriverTransformer(string id)
        {
            SrvDriverTransformer srvDriverTransformer = await db.SrvDriverTransformers.FindAsync(id);
            if (srvDriverTransformer == null)
            {
                return NotFound();
            }

            return Ok(srvDriverTransformer);
        }

        // PUT: api/SrvDriverTransformers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSrvDriverTransformer(string id, SrvDriverTransformer srvDriverTransformer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != srvDriverTransformer.TypeID)
            {
                return BadRequest();
            }

            db.Entry(srvDriverTransformer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SrvDriverTransformerExists(id))
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

        // POST: api/SrvDriverTransformers
        [ResponseType(typeof(SrvDriverTransformer))]
        public async Task<IHttpActionResult> PostSrvDriverTransformer(SrvDriverTransformer srvDriverTransformer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SrvDriverTransformers.Add(srvDriverTransformer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SrvDriverTransformerExists(srvDriverTransformer.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = srvDriverTransformer.TypeID }, srvDriverTransformer);
        }

        // DELETE: api/SrvDriverTransformers/5
        [ResponseType(typeof(SrvDriverTransformer))]
        public async Task<IHttpActionResult> DeleteSrvDriverTransformer(string id)
        {
            SrvDriverTransformer srvDriverTransformer = await db.SrvDriverTransformers.FindAsync(id);
            if (srvDriverTransformer == null)
            {
                return NotFound();
            }

            db.SrvDriverTransformers.Remove(srvDriverTransformer);
            await db.SaveChangesAsync();

            return Ok(srvDriverTransformer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SrvDriverTransformerExists(string id)
        {
            return db.SrvDriverTransformers.Count(e => e.TypeID == id) > 0;
        }
    }
}