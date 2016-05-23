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
    //十字滑块联轴器
    public class OldhamCouplingController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/OldhamCoupling
        public IQueryable<Coupling_OldhamCoupling> GetCoupling_OldhamCoupling()
        {
            return db.Coupling_OldhamCoupling;
        }

        // GET: api/OldhamCoupling/5
        [ResponseType(typeof(Coupling_OldhamCoupling))]
        public async Task<IHttpActionResult> GetCoupling_OldhamCoupling(string id)
        {
            Coupling_OldhamCoupling coupling_OldhamCoupling = await db.Coupling_OldhamCoupling.FindAsync(id);
            if (coupling_OldhamCoupling == null)
            {
                return NotFound();
            }

            return Ok(coupling_OldhamCoupling);
        }

        // PUT: api/OldhamCoupling/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoupling_OldhamCoupling(string id, Coupling_OldhamCoupling coupling_OldhamCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupling_OldhamCoupling.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(coupling_OldhamCoupling).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Coupling_OldhamCouplingExists(id))
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

        // POST: api/OldhamCoupling
        [ResponseType(typeof(Coupling_OldhamCoupling))]
        public async Task<IHttpActionResult> PostCoupling_OldhamCoupling(Coupling_OldhamCoupling coupling_OldhamCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupling_OldhamCoupling.Add(coupling_OldhamCoupling);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Coupling_OldhamCouplingExists(coupling_OldhamCoupling.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = coupling_OldhamCoupling.TypeNo }, coupling_OldhamCoupling);
        }

        // DELETE: api/OldhamCoupling/5
        [ResponseType(typeof(Coupling_OldhamCoupling))]
        public async Task<IHttpActionResult> DeleteCoupling_OldhamCoupling(string id)
        {
            Coupling_OldhamCoupling coupling_OldhamCoupling = await db.Coupling_OldhamCoupling.FindAsync(id);
            if (coupling_OldhamCoupling == null)
            {
                return NotFound();
            }

            db.Coupling_OldhamCoupling.Remove(coupling_OldhamCoupling);
            await db.SaveChangesAsync();

            return Ok(coupling_OldhamCoupling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Coupling_OldhamCouplingExists(string id)
        {
            return db.Coupling_OldhamCoupling.Count(e => e.TypeNo == id) > 0;
        }
    }
}