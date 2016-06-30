using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CNCDataApi.Models;

namespace CNCDataApi.Controllers
{
    public class LineRollingGuidesController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/LineRollingGuides
        public IQueryable<LineRollingGuide> GetLinearRollingGuide()
        {
            return db.LinearRollingGuide;
        }

        // GET: api/LineRollingGuides/5
        [ResponseType(typeof(LineRollingGuide))]
        public async Task<IHttpActionResult> GetLineRollingGuide(string id)
        {
            LineRollingGuide lineRollingGuide = await db.LinearRollingGuide.FindAsync(id);
            if (lineRollingGuide == null)
            {
                return NotFound();
            }

            return Ok(lineRollingGuide);
        }

        // PUT: api/LineRollingGuides/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLineRollingGuide(string id, LineRollingGuide lineRollingGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineRollingGuide.TypeID)
            {
                return BadRequest();
            }

            db.Entry(lineRollingGuide).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineRollingGuideExists(id))
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

        // POST: api/LineRollingGuides
        [ResponseType(typeof(LineRollingGuide))]
        public async Task<IHttpActionResult> PostLineRollingGuide(LineRollingGuide lineRollingGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LinearRollingGuide.Add(lineRollingGuide);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LineRollingGuideExists(lineRollingGuide.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lineRollingGuide.TypeID }, lineRollingGuide);
        }

        // DELETE: api/LineRollingGuides/5
        [ResponseType(typeof(LineRollingGuide))]
        public async Task<IHttpActionResult> DeleteLineRollingGuide(string id)
        {
            LineRollingGuide lineRollingGuide = await db.LinearRollingGuide.FindAsync(id);
            if (lineRollingGuide == null)
            {
                return NotFound();
            }

            db.LinearRollingGuide.Remove(lineRollingGuide);
            await db.SaveChangesAsync();

            return Ok(lineRollingGuide);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineRollingGuideExists(string id)
        {
            return db.LinearRollingGuide.Count(e => e.TypeID == id) > 0;
        }
    }
}