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
    //弹性套柱销联轴器 
    public class ElasticSleevePinCouplingController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/ElasticSleevePinCoupling
        public IQueryable<Coupling_ElasticSleevePinCoupling> GetCoupling_ElasticSleevePinCoupling()
        {
            return db.Coupling_ElasticSleevePinCoupling;
        }

        // GET: api/ElasticSleevePinCoupling/5
        [ResponseType(typeof(Coupling_ElasticSleevePinCoupling))]
        public async Task<IHttpActionResult> GetCoupling_ElasticSleevePinCoupling(string id)
        {
            Coupling_ElasticSleevePinCoupling coupling_ElasticSleevePinCoupling = await db.Coupling_ElasticSleevePinCoupling.FindAsync(id);
            if (coupling_ElasticSleevePinCoupling == null)
            {
                return NotFound();
            }

            return Ok(coupling_ElasticSleevePinCoupling);
        }

        // PUT: api/ElasticSleevePinCoupling/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoupling_ElasticSleevePinCoupling(string id, Coupling_ElasticSleevePinCoupling coupling_ElasticSleevePinCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupling_ElasticSleevePinCoupling.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(coupling_ElasticSleevePinCoupling).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Coupling_ElasticSleevePinCouplingExists(id))
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

        // POST: api/ElasticSleevePinCoupling
        [ResponseType(typeof(Coupling_ElasticSleevePinCoupling))]
        public async Task<IHttpActionResult> PostCoupling_ElasticSleevePinCoupling(Coupling_ElasticSleevePinCoupling coupling_ElasticSleevePinCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupling_ElasticSleevePinCoupling.Add(coupling_ElasticSleevePinCoupling);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Coupling_ElasticSleevePinCouplingExists(coupling_ElasticSleevePinCoupling.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = coupling_ElasticSleevePinCoupling.TypeNo }, coupling_ElasticSleevePinCoupling);
        }

        // DELETE: api/ElasticSleevePinCoupling/5
        [ResponseType(typeof(Coupling_ElasticSleevePinCoupling))]
        public async Task<IHttpActionResult> DeleteCoupling_ElasticSleevePinCoupling(string id)
        {
            Coupling_ElasticSleevePinCoupling coupling_ElasticSleevePinCoupling = await db.Coupling_ElasticSleevePinCoupling.FindAsync(id);
            if (coupling_ElasticSleevePinCoupling == null)
            {
                return NotFound();
            }

            db.Coupling_ElasticSleevePinCoupling.Remove(coupling_ElasticSleevePinCoupling);
            await db.SaveChangesAsync();

            return Ok(coupling_ElasticSleevePinCoupling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Coupling_ElasticSleevePinCouplingExists(string id)
        {
            return db.Coupling_ElasticSleevePinCoupling.Count(e => e.TypeNo == id) > 0;
        }
    }
}