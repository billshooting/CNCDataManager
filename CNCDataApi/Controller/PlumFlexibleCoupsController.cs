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
    public class PlumFlexibleCoupsController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/PlumFlexibleCoups
        public IQueryable<PlumFlexibleCoup> GetPlumShapedFlexibleCoupling()
        {
            return db.PlumShapedFlexibleCoupling;
        }

        // GET: api/PlumFlexibleCoups/5
        [ResponseType(typeof(PlumFlexibleCoup))]
        public async Task<IHttpActionResult> GetPlumFlexibleCoup(string id)
        {
            PlumFlexibleCoup plumFlexibleCoup = await db.PlumShapedFlexibleCoupling.FindAsync(id);
            if (plumFlexibleCoup == null)
            {
                return NotFound();
            }

            return Ok(plumFlexibleCoup);
        }

        // PUT: api/PlumFlexibleCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlumFlexibleCoup(string id, PlumFlexibleCoup plumFlexibleCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plumFlexibleCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(plumFlexibleCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlumFlexibleCoupExists(id))
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

        // POST: api/PlumFlexibleCoups
        [ResponseType(typeof(PlumFlexibleCoup))]
        public async Task<IHttpActionResult> PostPlumFlexibleCoup(PlumFlexibleCoup plumFlexibleCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlumShapedFlexibleCoupling.Add(plumFlexibleCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlumFlexibleCoupExists(plumFlexibleCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = plumFlexibleCoup.TypeID }, plumFlexibleCoup);
        }

        // DELETE: api/PlumFlexibleCoups/5
        [ResponseType(typeof(PlumFlexibleCoup))]
        public async Task<IHttpActionResult> DeletePlumFlexibleCoup(string id)
        {
            PlumFlexibleCoup plumFlexibleCoup = await db.PlumShapedFlexibleCoupling.FindAsync(id);
            if (plumFlexibleCoup == null)
            {
                return NotFound();
            }

            db.PlumShapedFlexibleCoupling.Remove(plumFlexibleCoup);
            await db.SaveChangesAsync();

            return Ok(plumFlexibleCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlumFlexibleCoupExists(string id)
        {
            return db.PlumShapedFlexibleCoupling.Count(e => e.TypeID == id) > 0;
        }
    }
}