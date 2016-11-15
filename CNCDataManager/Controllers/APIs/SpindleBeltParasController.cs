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
    [ApiAuthorize]
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    public class SpindleBeltParasController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SpindleBeltParas
        [AllowAnonymous]
        public IQueryable<SpindleBeltPara> GetSpindleBeltParas()
        {
            return db.SpindleBeltParas;
        }

        // GET: api/SpindleBeltParas/5
        [AllowAnonymous]
        [ResponseType(typeof(SpindleBeltPara))]
        public async Task<IHttpActionResult> GetSpindleBeltPara(string id)
        {
            SpindleBeltPara spindleBeltPara = await db.SpindleBeltParas.FindAsync(id);
            if (spindleBeltPara == null)
            {
                return NotFound();
            }

            return Ok(spindleBeltPara);
        }

        // PUT: api/SpindleBeltParas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpindleBeltPara(string id, SpindleBeltPara spindleBeltPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleBeltPara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleBeltPara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleBeltParaExists(id))
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

        // POST: api/SpindleBeltParas
        [ResponseType(typeof(SpindleBeltPara))]
        public async Task<IHttpActionResult> PostSpindleBeltPara(SpindleBeltPara spindleBeltPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleBeltParas.Add(spindleBeltPara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleBeltParaExists(spindleBeltPara.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleBeltPara.TypeID }, spindleBeltPara);
        }

        // DELETE: api/SpindleBeltParas/5
        [ResponseType(typeof(SpindleBeltPara))]
        public async Task<IHttpActionResult> DeleteSpindleBeltPara(string id)
        {
            SpindleBeltPara spindleBeltPara = await db.SpindleBeltParas.FindAsync(id);
            if (spindleBeltPara == null)
            {
                return NotFound();
            }

            db.SpindleBeltParas.Remove(spindleBeltPara);
            await db.SaveChangesAsync();

            return Ok(spindleBeltPara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleBeltParaExists(string id)
        {
            return db.SpindleBeltParas.Count(e => e.TypeID == id) > 0;
        }
    }
}