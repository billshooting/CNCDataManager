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
    //带制动轮弹性套柱销联轴器 
    public class BrakeWheelElasticSleevePinCouplingController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/BrakeWheelElasticSleevePinCoupling
        public IQueryable<Coupling_BrakeWheelElasticSleevePinCoupling> GetCoupling_BrakeWheelElasticSleevePinCoupling()
        {
            return db.Coupling_BrakeWheelElasticSleevePinCoupling;
        }

        // GET: api/BrakeWheelElasticSleevePinCoupling/5
        [ResponseType(typeof(Coupling_BrakeWheelElasticSleevePinCoupling))]
        public async Task<IHttpActionResult> GetCoupling_BrakeWheelElasticSleevePinCoupling(string id)
        {
            Coupling_BrakeWheelElasticSleevePinCoupling coupling_BrakeWheelElasticSleevePinCoupling = await db.Coupling_BrakeWheelElasticSleevePinCoupling.FindAsync(id);
            if (coupling_BrakeWheelElasticSleevePinCoupling == null)
            {
                return NotFound();
            }

            return Ok(coupling_BrakeWheelElasticSleevePinCoupling);
        }

        // PUT: api/BrakeWheelElasticSleevePinCoupling/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoupling_BrakeWheelElasticSleevePinCoupling(string id, Coupling_BrakeWheelElasticSleevePinCoupling coupling_BrakeWheelElasticSleevePinCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupling_BrakeWheelElasticSleevePinCoupling.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(coupling_BrakeWheelElasticSleevePinCoupling).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Coupling_BrakeWheelElasticSleevePinCouplingExists(id))
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

        // POST: api/BrakeWheelElasticSleevePinCoupling
        [ResponseType(typeof(Coupling_BrakeWheelElasticSleevePinCoupling))]
        public async Task<IHttpActionResult> PostCoupling_BrakeWheelElasticSleevePinCoupling(Coupling_BrakeWheelElasticSleevePinCoupling coupling_BrakeWheelElasticSleevePinCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupling_BrakeWheelElasticSleevePinCoupling.Add(coupling_BrakeWheelElasticSleevePinCoupling);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Coupling_BrakeWheelElasticSleevePinCouplingExists(coupling_BrakeWheelElasticSleevePinCoupling.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = coupling_BrakeWheelElasticSleevePinCoupling.TypeNo }, coupling_BrakeWheelElasticSleevePinCoupling);
        }

        // DELETE: api/BrakeWheelElasticSleevePinCoupling/5
        [ResponseType(typeof(Coupling_BrakeWheelElasticSleevePinCoupling))]
        public async Task<IHttpActionResult> DeleteCoupling_BrakeWheelElasticSleevePinCoupling(string id)
        {
            Coupling_BrakeWheelElasticSleevePinCoupling coupling_BrakeWheelElasticSleevePinCoupling = await db.Coupling_BrakeWheelElasticSleevePinCoupling.FindAsync(id);
            if (coupling_BrakeWheelElasticSleevePinCoupling == null)
            {
                return NotFound();
            }

            db.Coupling_BrakeWheelElasticSleevePinCoupling.Remove(coupling_BrakeWheelElasticSleevePinCoupling);
            await db.SaveChangesAsync();

            return Ok(coupling_BrakeWheelElasticSleevePinCoupling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Coupling_BrakeWheelElasticSleevePinCouplingExists(string id)
        {
            return db.Coupling_BrakeWheelElasticSleevePinCoupling.Count(e => e.TypeNo == id) > 0;
        }
    }
}