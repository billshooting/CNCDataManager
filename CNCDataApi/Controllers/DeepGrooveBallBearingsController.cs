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
    public class DeepGrooveBallBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/DeepGrooveBallBearings
        public IQueryable<Bearings_DeepGrooveBallBearings> GetBearings_DeepGrooveBallBearings()
        {
            return db.Bearings_DeepGrooveBallBearings;
        }

        // GET: api/DeepGrooveBallBearings/5
        [ResponseType(typeof(Bearings_DeepGrooveBallBearings))]
        public async Task<IHttpActionResult> GetBearings_DeepGrooveBallBearings(string id)
        {
            Bearings_DeepGrooveBallBearings bearings_DeepGrooveBallBearings = await db.Bearings_DeepGrooveBallBearings.FindAsync(id);
            if (bearings_DeepGrooveBallBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_DeepGrooveBallBearings);
        }

        // PUT: api/DeepGrooveBallBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_DeepGrooveBallBearings(string id, Bearings_DeepGrooveBallBearings bearings_DeepGrooveBallBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_DeepGrooveBallBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_DeepGrooveBallBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_DeepGrooveBallBearingsExists(id))
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

        // POST: api/DeepGrooveBallBearings
        [ResponseType(typeof(Bearings_DeepGrooveBallBearings))]
        public async Task<IHttpActionResult> PostBearings_DeepGrooveBallBearings(Bearings_DeepGrooveBallBearings bearings_DeepGrooveBallBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_DeepGrooveBallBearings.Add(bearings_DeepGrooveBallBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_DeepGrooveBallBearingsExists(bearings_DeepGrooveBallBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_DeepGrooveBallBearings.TypeNo }, bearings_DeepGrooveBallBearings);
        }

        // DELETE: api/DeepGrooveBallBearings/5
        [ResponseType(typeof(Bearings_DeepGrooveBallBearings))]
        public async Task<IHttpActionResult> DeleteBearings_DeepGrooveBallBearings(string id)
        {
            Bearings_DeepGrooveBallBearings bearings_DeepGrooveBallBearings = await db.Bearings_DeepGrooveBallBearings.FindAsync(id);
            if (bearings_DeepGrooveBallBearings == null)
            {
                return NotFound();
            }

            db.Bearings_DeepGrooveBallBearings.Remove(bearings_DeepGrooveBallBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_DeepGrooveBallBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_DeepGrooveBallBearingsExists(string id)
        {
            return db.Bearings_DeepGrooveBallBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}