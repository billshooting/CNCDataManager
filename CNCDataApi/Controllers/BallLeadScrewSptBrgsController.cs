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
    public class BallLeadScrewSptBrgsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/BallLeadScrewSptBrgs
        public IQueryable<BallLeadScrewSptBrg> GetBallLeadScrewSupportBearings()
        {
            return db.BallLeadScrewSupportBearings;
        }

        // GET: api/BallLeadScrewSptBrgs/5
        [ResponseType(typeof(BallLeadScrewSptBrg))]
        public async Task<IHttpActionResult> GetBallLeadScrewSptBrg(string id)
        {
            BallLeadScrewSptBrg ballLeadScrewSptBrg = await db.BallLeadScrewSupportBearings.FindAsync(id);
            if (ballLeadScrewSptBrg == null)
            {
                return NotFound();
            }

            return Ok(ballLeadScrewSptBrg);
        }

        // PUT: api/BallLeadScrewSptBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBallLeadScrewSptBrg(string id, BallLeadScrewSptBrg ballLeadScrewSptBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ballLeadScrewSptBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(ballLeadScrewSptBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BallLeadScrewSptBrgExists(id))
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

        // POST: api/BallLeadScrewSptBrgs
        [ResponseType(typeof(BallLeadScrewSptBrg))]
        public async Task<IHttpActionResult> PostBallLeadScrewSptBrg(BallLeadScrewSptBrg ballLeadScrewSptBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BallLeadScrewSupportBearings.Add(ballLeadScrewSptBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BallLeadScrewSptBrgExists(ballLeadScrewSptBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ballLeadScrewSptBrg.TypeID }, ballLeadScrewSptBrg);
        }

        // DELETE: api/BallLeadScrewSptBrgs/5
        [ResponseType(typeof(BallLeadScrewSptBrg))]
        public async Task<IHttpActionResult> DeleteBallLeadScrewSptBrg(string id)
        {
            BallLeadScrewSptBrg ballLeadScrewSptBrg = await db.BallLeadScrewSupportBearings.FindAsync(id);
            if (ballLeadScrewSptBrg == null)
            {
                return NotFound();
            }

            db.BallLeadScrewSupportBearings.Remove(ballLeadScrewSptBrg);
            await db.SaveChangesAsync();

            return Ok(ballLeadScrewSptBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BallLeadScrewSptBrgExists(string id)
        {
            return db.BallLeadScrewSupportBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}