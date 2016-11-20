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
    public class RotaryTablesController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/RotaryTables
        [AllowAnonymous]
        public IQueryable<RotaryTable> GetRotaryTables()
        {
            return db.RotaryTables;
        }

        // GET: api/RotaryTables/5
        [AllowAnonymous]
        [ResponseType(typeof(RotaryTable))]
        public async Task<IHttpActionResult> GetRotaryTable(string id)
        {
            RotaryTable rotaryTable = await db.RotaryTables.FindAsync(id);
            if (rotaryTable == null)
            {
                return NotFound();
            }

            return Ok(rotaryTable);
        }

        // PUT: api/RotaryTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRotaryTable(string id, RotaryTable rotaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rotaryTable.TypeID)
            {
                return BadRequest();
            }

            db.Entry(rotaryTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaryTableExists(id))
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

        // POST: api/RotaryTables
        [ResponseType(typeof(RotaryTable))]
        public async Task<IHttpActionResult> PostRotaryTable(RotaryTable rotaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RotaryTables.Add(rotaryTable);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RotaryTableExists(rotaryTable.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rotaryTable.TypeID }, rotaryTable);
        }

        // DELETE: api/RotaryTables/5
        [ResponseType(typeof(RotaryTable))]
        public async Task<IHttpActionResult> DeleteRotaryTable(string id)
        {
            RotaryTable rotaryTable = await db.RotaryTables.FindAsync(id);
            if (rotaryTable == null)
            {
                return NotFound();
            }

            db.RotaryTables.Remove(rotaryTable);
            await db.SaveChangesAsync();

            return Ok(rotaryTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RotaryTableExists(string id)
        {
            return db.RotaryTables.Count(e => e.TypeID == id) > 0;
        }
    }
}