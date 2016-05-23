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
    //直线滚动导轨
    public class LinearRollingGuideController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/LinearRollingGuide
        public IQueryable<Guide_LinearRollingGuide> GetGuide_LinearRollingGuide()
        {
            return db.Guide_LinearRollingGuide;
        }

        // GET: api/LinearRollingGuide/5
        [ResponseType(typeof(Guide_LinearRollingGuide))]
        public async Task<IHttpActionResult> GetGuide_LinearRollingGuide(string id)
        {
            Guide_LinearRollingGuide guide_LinearRollingGuide = await db.Guide_LinearRollingGuide.FindAsync(id);
            if (guide_LinearRollingGuide == null)
            {
                return NotFound();
            }

            return Ok(guide_LinearRollingGuide);
        }

        // PUT: api/LinearRollingGuide/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGuide_LinearRollingGuide(string id, Guide_LinearRollingGuide guide_LinearRollingGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guide_LinearRollingGuide.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(guide_LinearRollingGuide).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Guide_LinearRollingGuideExists(id))
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

        // POST: api/LinearRollingGuide
        [ResponseType(typeof(Guide_LinearRollingGuide))]
        public async Task<IHttpActionResult> PostGuide_LinearRollingGuide(Guide_LinearRollingGuide guide_LinearRollingGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guide_LinearRollingGuide.Add(guide_LinearRollingGuide);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Guide_LinearRollingGuideExists(guide_LinearRollingGuide.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guide_LinearRollingGuide.TypeNo }, guide_LinearRollingGuide);
        }

        // DELETE: api/LinearRollingGuide/5
        [ResponseType(typeof(Guide_LinearRollingGuide))]
        public async Task<IHttpActionResult> DeleteGuide_LinearRollingGuide(string id)
        {
            Guide_LinearRollingGuide guide_LinearRollingGuide = await db.Guide_LinearRollingGuide.FindAsync(id);
            if (guide_LinearRollingGuide == null)
            {
                return NotFound();
            }

            db.Guide_LinearRollingGuide.Remove(guide_LinearRollingGuide);
            await db.SaveChangesAsync();

            return Ok(guide_LinearRollingGuide);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Guide_LinearRollingGuideExists(string id)
        {
            return db.Guide_LinearRollingGuide.Count(e => e.TypeNo == id) > 0;
        }
    }
}