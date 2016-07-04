using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CNCDataApi.Models;

namespace CNCDataApi.Controllers
{
    public class AngContactBallBrgsController : ApiController
    {
        public CNCMachineData db = new CNCMachineData();

        // GET: api/AngContactBallBrgs
        public IQueryable<AngContactBallBrg> GetAngContactBallBearings()
        {
            return db.AngContactBallBearings;
        }

        // GET: api/AngContactBallBrgs/5
        [ResponseType(typeof(AngContactBallBrg))]
        public async Task<IHttpActionResult> GetAngContactBallBrg(string id)
        {
            AngContactBallBrg angContactBallBrg = await db.AngContactBallBearings.FindAsync(id);
            if (angContactBallBrg == null)
            {
                return NotFound();
            }

            return Ok(angContactBallBrg);
        }

        // PUT: api/AngContactBallBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAngContactBallBrg(string id, AngContactBallBrg angContactBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != angContactBallBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(angContactBallBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AngContactBallBrgExists(id))
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

        // POST: api/AngContactBallBrgs
        [ResponseType(typeof(AngContactBallBrg))]
        public async Task<IHttpActionResult> PostAngContactBallBrg(AngContactBallBrg angContactBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AngContactBallBearings.Add(angContactBallBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AngContactBallBrgExists(angContactBallBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = angContactBallBrg.TypeID }, angContactBallBrg);
        }

        // DELETE: api/AngContactBallBrgs/5
        [ResponseType(typeof(AngContactBallBrg))]
        public async Task<IHttpActionResult> DeleteAngContactBallBrg(string id)
        {
            AngContactBallBrg angContactBallBrg = await db.AngContactBallBearings.FindAsync(id);
            if (angContactBallBrg == null)
            {
                return NotFound();
            }

            db.AngContactBallBearings.Remove(angContactBallBrg);
            await db.SaveChangesAsync();

            return Ok(angContactBallBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AngContactBallBrgExists(string id)
        {
            return db.AngContactBallBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}