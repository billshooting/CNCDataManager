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
    //梅花形弹性联轴器
    public class PlumShapedFlexibleCouplingController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/PlumShapedFlexibleCoupling
        public IQueryable<Coupling_PlumShapedFlexibleCoupling> GetCoupling_PlumShapedFlexibleCoupling()
        {
            return db.Coupling_PlumShapedFlexibleCoupling;
        }

        // GET: api/PlumShapedFlexibleCoupling/5
        [ResponseType(typeof(Coupling_PlumShapedFlexibleCoupling))]
        public async Task<IHttpActionResult> GetCoupling_PlumShapedFlexibleCoupling(string id)
        {
            Coupling_PlumShapedFlexibleCoupling coupling_PlumShapedFlexibleCoupling = await db.Coupling_PlumShapedFlexibleCoupling.FindAsync(id);
            if (coupling_PlumShapedFlexibleCoupling == null)
            {
                return NotFound();
            }

            return Ok(coupling_PlumShapedFlexibleCoupling);
        }

        // PUT: api/PlumShapedFlexibleCoupling/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoupling_PlumShapedFlexibleCoupling(string id, Coupling_PlumShapedFlexibleCoupling coupling_PlumShapedFlexibleCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupling_PlumShapedFlexibleCoupling.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(coupling_PlumShapedFlexibleCoupling).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Coupling_PlumShapedFlexibleCouplingExists(id))
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

        // POST: api/PlumShapedFlexibleCoupling
        [ResponseType(typeof(Coupling_PlumShapedFlexibleCoupling))]
        public async Task<IHttpActionResult> PostCoupling_PlumShapedFlexibleCoupling(Coupling_PlumShapedFlexibleCoupling coupling_PlumShapedFlexibleCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupling_PlumShapedFlexibleCoupling.Add(coupling_PlumShapedFlexibleCoupling);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Coupling_PlumShapedFlexibleCouplingExists(coupling_PlumShapedFlexibleCoupling.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = coupling_PlumShapedFlexibleCoupling.TypeNo }, coupling_PlumShapedFlexibleCoupling);
        }

        // DELETE: api/PlumShapedFlexibleCoupling/5
        [ResponseType(typeof(Coupling_PlumShapedFlexibleCoupling))]
        public async Task<IHttpActionResult> DeleteCoupling_PlumShapedFlexibleCoupling(string id)
        {
            Coupling_PlumShapedFlexibleCoupling coupling_PlumShapedFlexibleCoupling = await db.Coupling_PlumShapedFlexibleCoupling.FindAsync(id);
            if (coupling_PlumShapedFlexibleCoupling == null)
            {
                return NotFound();
            }

            db.Coupling_PlumShapedFlexibleCoupling.Remove(coupling_PlumShapedFlexibleCoupling);
            await db.SaveChangesAsync();

            return Ok(coupling_PlumShapedFlexibleCoupling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Coupling_PlumShapedFlexibleCouplingExists(string id)
        {
            return db.Coupling_PlumShapedFlexibleCoupling.Count(e => e.TypeNo == id) > 0;
        }
    }
}