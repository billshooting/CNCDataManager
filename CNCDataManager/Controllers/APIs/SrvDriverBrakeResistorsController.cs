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
    public class SrvDriverBrakeResistorsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SrvDriverBrakeResistors
        [AllowAnonymous]
        public IQueryable<SrvDriverBrakeResistor> GetSrvDriverBrakeResistors()
        {
            return db.SrvDriverBrakeResistors;
        }

        // GET: api/SrvDriverBrakeResistors/5
        [AllowAnonymous]
        [ResponseType(typeof(SrvDriverBrakeResistor))]
        public async Task<IHttpActionResult> GetSrvDriverBrakeResistor(string id)
        {
            SrvDriverBrakeResistor srvDriverBrakeResistor = await db.SrvDriverBrakeResistors.FindAsync(id);
            if (srvDriverBrakeResistor == null)
            {
                return NotFound();
            }

            return Ok(srvDriverBrakeResistor);
        }

        // PUT: api/SrvDriverBrakeResistors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSrvDriverBrakeResistor(string id, SrvDriverBrakeResistor srvDriverBrakeResistor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != srvDriverBrakeResistor.TypeID)
            {
                return BadRequest();
            }

            db.Entry(srvDriverBrakeResistor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SrvDriverBrakeResistorExists(id))
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

        // POST: api/SrvDriverBrakeResistors
        [ResponseType(typeof(SrvDriverBrakeResistor))]
        public async Task<IHttpActionResult> PostSrvDriverBrakeResistor(SrvDriverBrakeResistor srvDriverBrakeResistor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SrvDriverBrakeResistors.Add(srvDriverBrakeResistor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SrvDriverBrakeResistorExists(srvDriverBrakeResistor.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = srvDriverBrakeResistor.TypeID }, srvDriverBrakeResistor);
        }

        // DELETE: api/SrvDriverBrakeResistors/5
        [ResponseType(typeof(SrvDriverBrakeResistor))]
        public async Task<IHttpActionResult> DeleteSrvDriverBrakeResistor(string id)
        {
            SrvDriverBrakeResistor srvDriverBrakeResistor = await db.SrvDriverBrakeResistors.FindAsync(id);
            if (srvDriverBrakeResistor == null)
            {
                return NotFound();
            }

            db.SrvDriverBrakeResistors.Remove(srvDriverBrakeResistor);
            await db.SaveChangesAsync();

            return Ok(srvDriverBrakeResistor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SrvDriverBrakeResistorExists(string id)
        {
            return db.SrvDriverBrakeResistors.Count(e => e.TypeID == id) > 0;
        }
    }
}