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
    public class DoubleThrustAngContactBallBrgsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/DoubleThrustAngContactBallBrgs
        public IQueryable<DoubleThrustAngContactBallBrg> GetDoubleThrustAngularContactBallBearings()
        {
            return db.DoubleThrustAngularContactBallBearings;
        }

        // GET: api/DoubleThrustAngContactBallBrgs/5
        [ResponseType(typeof(DoubleThrustAngContactBallBrg))]
        public async Task<IHttpActionResult> GetDoubleThrustAngContactBallBrg(string id)
        {
            DoubleThrustAngContactBallBrg doubleThrustAngContactBallBrg = await db.DoubleThrustAngularContactBallBearings.FindAsync(id);
            if (doubleThrustAngContactBallBrg == null)
            {
                return NotFound();
            }

            return Ok(doubleThrustAngContactBallBrg);
        }

        // PUT: api/DoubleThrustAngContactBallBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDoubleThrustAngContactBallBrg(string id, DoubleThrustAngContactBallBrg doubleThrustAngContactBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doubleThrustAngContactBallBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(doubleThrustAngContactBallBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoubleThrustAngContactBallBrgExists(id))
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

        // POST: api/DoubleThrustAngContactBallBrgs
        [ResponseType(typeof(DoubleThrustAngContactBallBrg))]
        public async Task<IHttpActionResult> PostDoubleThrustAngContactBallBrg(DoubleThrustAngContactBallBrg doubleThrustAngContactBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DoubleThrustAngularContactBallBearings.Add(doubleThrustAngContactBallBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoubleThrustAngContactBallBrgExists(doubleThrustAngContactBallBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = doubleThrustAngContactBallBrg.TypeID }, doubleThrustAngContactBallBrg);
        }

        // DELETE: api/DoubleThrustAngContactBallBrgs/5
        [ResponseType(typeof(DoubleThrustAngContactBallBrg))]
        public async Task<IHttpActionResult> DeleteDoubleThrustAngContactBallBrg(string id)
        {
            DoubleThrustAngContactBallBrg doubleThrustAngContactBallBrg = await db.DoubleThrustAngularContactBallBearings.FindAsync(id);
            if (doubleThrustAngContactBallBrg == null)
            {
                return NotFound();
            }

            db.DoubleThrustAngularContactBallBearings.Remove(doubleThrustAngContactBallBrg);
            await db.SaveChangesAsync();

            return Ok(doubleThrustAngContactBallBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoubleThrustAngContactBallBrgExists(string id)
        {
            return db.DoubleThrustAngularContactBallBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}