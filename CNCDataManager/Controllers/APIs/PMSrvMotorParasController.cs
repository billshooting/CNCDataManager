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
    public class PMSrvMotorParasController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/PMSrvMotorParas
        [AllowAnonymous]
        public IQueryable<PMSrvMotorPara> GetPMSrvMotorParas()
        {
            return db.PMSrvMotorParas;
        }

        // GET: api/PMSrvMotorParas/5
        [AllowAnonymous]
        [ResponseType(typeof(PMSrvMotorPara))]
        public async Task<IHttpActionResult> GetPMSrvMotorPara(string id)
        {
            PMSrvMotorPara pMSrvMotorPara = await db.PMSrvMotorParas.FindAsync(id);
            if (pMSrvMotorPara == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorPara);
        }

        // PUT: api/PMSrvMotorParas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPMSrvMotorPara(string id, PMSrvMotorPara pMSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorPara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorPara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorParaExists(id))
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

        // POST: api/PMSrvMotorParas
        [ResponseType(typeof(PMSrvMotorPara))]
        public async Task<IHttpActionResult> PostPMSrvMotorPara(PMSrvMotorPara pMSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PMSrvMotorParas.Add(pMSrvMotorPara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorParaExists(pMSrvMotorPara.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorPara.TypeID }, pMSrvMotorPara);
        }

        // DELETE: api/PMSrvMotorParas/5
        [ResponseType(typeof(PMSrvMotorPara))]
        public async Task<IHttpActionResult> DeletePMSrvMotorPara(string id)
        {
            PMSrvMotorPara pMSrvMotorPara = await db.PMSrvMotorParas.FindAsync(id);
            if (pMSrvMotorPara == null)
            {
                return NotFound();
            }

            db.PMSrvMotorParas.Remove(pMSrvMotorPara);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorPara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorParaExists(string id)
        {
            return db.PMSrvMotorParas.Count(e => e.TypeID == id) > 0;
        }
    }
}