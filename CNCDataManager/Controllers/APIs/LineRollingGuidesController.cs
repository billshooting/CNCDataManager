﻿using CNCDataManager.APIs.Models;
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
    public class LineRollingGuidesController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/LineRollingGuides
        [AllowAnonymous]
        public IQueryable<LineRollingGuide> GetLineRollingGuides()
        {
            return db.LineRollingGuides;
        }

        // GET: api/LineRollingGuides/5
        [AllowAnonymous]
        [ResponseType(typeof(LineRollingGuide))]
        public async Task<IHttpActionResult> GetLineRollingGuide(string id)
        {
            LineRollingGuide lineRollingGuide = await db.LineRollingGuides.FindAsync(id);
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

            db.LineRollingGuides.Add(lineRollingGuide);

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
            LineRollingGuide lineRollingGuide = await db.LineRollingGuides.FindAsync(id);
            if (lineRollingGuide == null)
            {
                return NotFound();
            }

            db.LineRollingGuides.Remove(lineRollingGuide);
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
            return db.LineRollingGuides.Count(e => e.TypeID == id) > 0;
        }
    }
}