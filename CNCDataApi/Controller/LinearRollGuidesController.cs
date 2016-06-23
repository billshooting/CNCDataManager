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

namespace CNCDataApi.Controller
{
    public class LinearRollGuidesController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/LinearRollGuides
        public IQueryable<LinearRollGuide> GetLinearRollingGuide()
        {
            return db.LinearRollingGuide;
        }

        // GET: api/LinearRollGuides/5
        [ResponseType(typeof(LinearRollGuide))]
        public async Task<IHttpActionResult> GetLinearRollGuide(string id)
        {
            LinearRollGuide linearRollGuide = await db.LinearRollingGuide.FindAsync(id);
            if (linearRollGuide == null)
            {
                return NotFound();
            }

            return Ok(linearRollGuide);
        }

        // PUT: api/LinearRollGuides/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLinearRollGuide(string id, LinearRollGuide linearRollGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linearRollGuide.TypeID)
            {
                return BadRequest();
            }

            db.Entry(linearRollGuide).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinearRollGuideExists(id))
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

        // POST: api/LinearRollGuides
        [ResponseType(typeof(LinearRollGuide))]
        public async Task<IHttpActionResult> PostLinearRollGuide(LinearRollGuide linearRollGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LinearRollingGuide.Add(linearRollGuide);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LinearRollGuideExists(linearRollGuide.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = linearRollGuide.TypeID }, linearRollGuide);
        }

        // DELETE: api/LinearRollGuides/5
        [ResponseType(typeof(LinearRollGuide))]
        public async Task<IHttpActionResult> DeleteLinearRollGuide(string id)
        {
            LinearRollGuide linearRollGuide = await db.LinearRollingGuide.FindAsync(id);
            if (linearRollGuide == null)
            {
                return NotFound();
            }

            db.LinearRollingGuide.Remove(linearRollGuide);
            await db.SaveChangesAsync();

            return Ok(linearRollGuide);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinearRollGuideExists(string id)
        {
            return db.LinearRollingGuide.Count(e => e.TypeID == id) > 0;
        }
    }
}