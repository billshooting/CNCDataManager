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
    public class AlignBallBrgsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/AlignBallBrgs
        public IQueryable<AlignBallBrg> GetAligningBallBearings()
        {
            return db.AligningBallBearings;
        }

        // GET: api/AlignBallBrgs/5
        [ResponseType(typeof(AlignBallBrg))]
        public async Task<IHttpActionResult> GetAlignBallBrg(string id)
        {
            AlignBallBrg alignBallBrg = await db.AligningBallBearings.FindAsync(id);
            if (alignBallBrg == null)
            {
                return NotFound();
            }

            return Ok(alignBallBrg);
        }

        // PUT: api/AlignBallBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlignBallBrg(string id, AlignBallBrg alignBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alignBallBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(alignBallBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlignBallBrgExists(id))
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

        // POST: api/AlignBallBrgs
        [ResponseType(typeof(AlignBallBrg))]
        public async Task<IHttpActionResult> PostAlignBallBrg(AlignBallBrg alignBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AligningBallBearings.Add(alignBallBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlignBallBrgExists(alignBallBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = alignBallBrg.TypeID }, alignBallBrg);
        }

        // DELETE: api/AlignBallBrgs/5
        [ResponseType(typeof(AlignBallBrg))]
        public async Task<IHttpActionResult> DeleteAlignBallBrg(string id)
        {
            AlignBallBrg alignBallBrg = await db.AligningBallBearings.FindAsync(id);
            if (alignBallBrg == null)
            {
                return NotFound();
            }

            db.AligningBallBearings.Remove(alignBallBrg);
            await db.SaveChangesAsync();

            return Ok(alignBallBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlignBallBrgExists(string id)
        {
            return db.AligningBallBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}