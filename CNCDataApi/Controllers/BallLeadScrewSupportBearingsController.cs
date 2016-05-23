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
    /*滚珠丝杠支撑轴承*/
    public class BallLeadScrewSupportBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/BallLeadScrewSupportBearings
        public IQueryable<Bearings_BallLeadScrewSupportBearings> GetBearings_BallLeadScrewSupportBearings()
        {
            return db.Bearings_BallLeadScrewSupportBearings;
        }

        // GET: api/BallLeadScrewSupportBearings/5
        [ResponseType(typeof(Bearings_BallLeadScrewSupportBearings))]
        public async Task<IHttpActionResult> GetBearings_BallLeadScrewSupportBearings(string id)
        {
            Bearings_BallLeadScrewSupportBearings bearings_BallLeadScrewSupportBearings = await db.Bearings_BallLeadScrewSupportBearings.FindAsync(id);
            if (bearings_BallLeadScrewSupportBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_BallLeadScrewSupportBearings);
        }

        // PUT: api/BallLeadScrewSupportBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_BallLeadScrewSupportBearings(string id, Bearings_BallLeadScrewSupportBearings bearings_BallLeadScrewSupportBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_BallLeadScrewSupportBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_BallLeadScrewSupportBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_BallLeadScrewSupportBearingsExists(id))
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

        // POST: api/BallLeadScrewSupportBearings
        [ResponseType(typeof(Bearings_BallLeadScrewSupportBearings))]
        public async Task<IHttpActionResult> PostBearings_BallLeadScrewSupportBearings(Bearings_BallLeadScrewSupportBearings bearings_BallLeadScrewSupportBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_BallLeadScrewSupportBearings.Add(bearings_BallLeadScrewSupportBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_BallLeadScrewSupportBearingsExists(bearings_BallLeadScrewSupportBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_BallLeadScrewSupportBearings.TypeNo }, bearings_BallLeadScrewSupportBearings);
        }

        // DELETE: api/BallLeadScrewSupportBearings/5
        [ResponseType(typeof(Bearings_BallLeadScrewSupportBearings))]
        public async Task<IHttpActionResult> DeleteBearings_BallLeadScrewSupportBearings(string id)
        {
            Bearings_BallLeadScrewSupportBearings bearings_BallLeadScrewSupportBearings = await db.Bearings_BallLeadScrewSupportBearings.FindAsync(id);
            if (bearings_BallLeadScrewSupportBearings == null)
            {
                return NotFound();
            }

            db.Bearings_BallLeadScrewSupportBearings.Remove(bearings_BallLeadScrewSupportBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_BallLeadScrewSupportBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_BallLeadScrewSupportBearingsExists(string id)
        {
            return db.Bearings_BallLeadScrewSupportBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}