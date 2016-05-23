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
    //弹性柱销联轴器 
    public class FlexiblePinCouplingController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/FlexiblePinCoupling
        public IQueryable<Coupling_FlexiblePinCoupling> GetCoupling_FlexiblePinCoupling()
        {
            return db.Coupling_FlexiblePinCoupling;
        }

        // GET: api/FlexiblePinCoupling/5
        [ResponseType(typeof(Coupling_FlexiblePinCoupling))]
        public async Task<IHttpActionResult> GetCoupling_FlexiblePinCoupling(string id)
        {
            Coupling_FlexiblePinCoupling coupling_FlexiblePinCoupling = await db.Coupling_FlexiblePinCoupling.FindAsync(id);
            if (coupling_FlexiblePinCoupling == null)
            {
                return NotFound();
            }

            return Ok(coupling_FlexiblePinCoupling);
        }

        // PUT: api/FlexiblePinCoupling/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoupling_FlexiblePinCoupling(string id, Coupling_FlexiblePinCoupling coupling_FlexiblePinCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupling_FlexiblePinCoupling.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(coupling_FlexiblePinCoupling).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Coupling_FlexiblePinCouplingExists(id))
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

        // POST: api/FlexiblePinCoupling
        [ResponseType(typeof(Coupling_FlexiblePinCoupling))]
        public async Task<IHttpActionResult> PostCoupling_FlexiblePinCoupling(Coupling_FlexiblePinCoupling coupling_FlexiblePinCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupling_FlexiblePinCoupling.Add(coupling_FlexiblePinCoupling);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Coupling_FlexiblePinCouplingExists(coupling_FlexiblePinCoupling.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = coupling_FlexiblePinCoupling.TypeNo }, coupling_FlexiblePinCoupling);
        }

        // DELETE: api/FlexiblePinCoupling/5
        [ResponseType(typeof(Coupling_FlexiblePinCoupling))]
        public async Task<IHttpActionResult> DeleteCoupling_FlexiblePinCoupling(string id)
        {
            Coupling_FlexiblePinCoupling coupling_FlexiblePinCoupling = await db.Coupling_FlexiblePinCoupling.FindAsync(id);
            if (coupling_FlexiblePinCoupling == null)
            {
                return NotFound();
            }

            db.Coupling_FlexiblePinCoupling.Remove(coupling_FlexiblePinCoupling);
            await db.SaveChangesAsync();

            return Ok(coupling_FlexiblePinCoupling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Coupling_FlexiblePinCouplingExists(string id)
        {
            return db.Coupling_FlexiblePinCoupling.Count(e => e.TypeNo == id) > 0;
        }
    }
}