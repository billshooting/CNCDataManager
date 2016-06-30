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
    public class OldhamCoupsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/OldhamCoups
        public IQueryable<OldhamCoup> GetOldhamCoupling()
        {
            return db.OldhamCoupling;
        }

        // GET: api/OldhamCoups/5
        [ResponseType(typeof(OldhamCoup))]
        public async Task<IHttpActionResult> GetOldhamCoup(string id)
        {
            OldhamCoup oldhamCoup = await db.OldhamCoupling.FindAsync(id);
            if (oldhamCoup == null)
            {
                return NotFound();
            }

            return Ok(oldhamCoup);
        }

        // PUT: api/OldhamCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOldhamCoup(string id, OldhamCoup oldhamCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oldhamCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(oldhamCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OldhamCoupExists(id))
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

        // POST: api/OldhamCoups
        [ResponseType(typeof(OldhamCoup))]
        public async Task<IHttpActionResult> PostOldhamCoup(OldhamCoup oldhamCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OldhamCoupling.Add(oldhamCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OldhamCoupExists(oldhamCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oldhamCoup.TypeID }, oldhamCoup);
        }

        // DELETE: api/OldhamCoups/5
        [ResponseType(typeof(OldhamCoup))]
        public async Task<IHttpActionResult> DeleteOldhamCoup(string id)
        {
            OldhamCoup oldhamCoup = await db.OldhamCoupling.FindAsync(id);
            if (oldhamCoup == null)
            {
                return NotFound();
            }

            db.OldhamCoupling.Remove(oldhamCoup);
            await db.SaveChangesAsync();

            return Ok(oldhamCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OldhamCoupExists(string id)
        {
            return db.OldhamCoupling.Count(e => e.TypeID == id) > 0;
        }
    }
}