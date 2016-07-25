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
using CNCDataManager.Models;

namespace CNCDataManager.Controllers
{
    public class PlumShapedFlexibleCoupsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/PlumShapedFlexibleCoups
        public IQueryable<PlumShapedFlexibleCoup> GetPlumShapedFlexibleCouplings()
        {
            return db.PlumShapedFlexibleCouplings;
        }

        // GET: api/PlumShapedFlexibleCoups/5
        [ResponseType(typeof(PlumShapedFlexibleCoup))]
        public async Task<IHttpActionResult> GetPlumShapedFlexibleCoup(string id)
        {
            PlumShapedFlexibleCoup plumShapedFlexibleCoup = await db.PlumShapedFlexibleCouplings.FindAsync(id);
            if (plumShapedFlexibleCoup == null)
            {
                return NotFound();
            }

            return Ok(plumShapedFlexibleCoup);
        }

        // PUT: api/PlumShapedFlexibleCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlumShapedFlexibleCoup(string id, PlumShapedFlexibleCoup plumShapedFlexibleCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plumShapedFlexibleCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(plumShapedFlexibleCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlumShapedFlexibleCoupExists(id))
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

        // POST: api/PlumShapedFlexibleCoups
        [ResponseType(typeof(PlumShapedFlexibleCoup))]
        public async Task<IHttpActionResult> PostPlumShapedFlexibleCoup(PlumShapedFlexibleCoup plumShapedFlexibleCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlumShapedFlexibleCouplings.Add(plumShapedFlexibleCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlumShapedFlexibleCoupExists(plumShapedFlexibleCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = plumShapedFlexibleCoup.TypeID }, plumShapedFlexibleCoup);
        }

        // DELETE: api/PlumShapedFlexibleCoups/5
        [ResponseType(typeof(PlumShapedFlexibleCoup))]
        public async Task<IHttpActionResult> DeletePlumShapedFlexibleCoup(string id)
        {
            PlumShapedFlexibleCoup plumShapedFlexibleCoup = await db.PlumShapedFlexibleCouplings.FindAsync(id);
            if (plumShapedFlexibleCoup == null)
            {
                return NotFound();
            }

            db.PlumShapedFlexibleCouplings.Remove(plumShapedFlexibleCoup);
            await db.SaveChangesAsync();

            return Ok(plumShapedFlexibleCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlumShapedFlexibleCoupExists(string id)
        {
            return db.PlumShapedFlexibleCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}