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
    public class GearCouplingController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/GearCoupling
        public IQueryable<Coupling_GearCoupling> GetCoupling_GearCoupling()
        {
            return db.Coupling_GearCoupling;
        }

        // GET: api/GearCoupling/5
        [ResponseType(typeof(Coupling_GearCoupling))]
        public async Task<IHttpActionResult> GetCoupling_GearCoupling(string id)
        {
            Coupling_GearCoupling coupling_GearCoupling = await db.Coupling_GearCoupling.FindAsync(id);
            if (coupling_GearCoupling == null)
            {
                return NotFound();
            }

            return Ok(coupling_GearCoupling);
        }

        // PUT: api/GearCoupling/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoupling_GearCoupling(string id, Coupling_GearCoupling coupling_GearCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupling_GearCoupling.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(coupling_GearCoupling).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Coupling_GearCouplingExists(id))
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

        // POST: api/GearCoupling
        [ResponseType(typeof(Coupling_GearCoupling))]
        public async Task<IHttpActionResult> PostCoupling_GearCoupling(Coupling_GearCoupling coupling_GearCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupling_GearCoupling.Add(coupling_GearCoupling);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Coupling_GearCouplingExists(coupling_GearCoupling.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = coupling_GearCoupling.TypeNo }, coupling_GearCoupling);
        }

        // DELETE: api/GearCoupling/5
        [ResponseType(typeof(Coupling_GearCoupling))]
        public async Task<IHttpActionResult> DeleteCoupling_GearCoupling(string id)
        {
            Coupling_GearCoupling coupling_GearCoupling = await db.Coupling_GearCoupling.FindAsync(id);
            if (coupling_GearCoupling == null)
            {
                return NotFound();
            }

            db.Coupling_GearCoupling.Remove(coupling_GearCoupling);
            await db.SaveChangesAsync();

            return Ok(coupling_GearCoupling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Coupling_GearCouplingExists(string id)
        {
            return db.Coupling_GearCoupling.Count(e => e.TypeNo == id) > 0;
        }
    }
}