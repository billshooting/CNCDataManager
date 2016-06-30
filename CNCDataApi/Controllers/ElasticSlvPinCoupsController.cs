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
    public class ElasticSlvPinCoupsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/ElasticSlvPinCoups
        public IQueryable<ElasticSlvPinCoup> GetElasticSleevePinCoupling()
        {
            return db.ElasticSleevePinCoupling;
        }

        // GET: api/ElasticSlvPinCoups/5
        [ResponseType(typeof(ElasticSlvPinCoup))]
        public async Task<IHttpActionResult> GetElasticSlvPinCoup(string id)
        {
            ElasticSlvPinCoup elasticSlvPinCoup = await db.ElasticSleevePinCoupling.FindAsync(id);
            if (elasticSlvPinCoup == null)
            {
                return NotFound();
            }

            return Ok(elasticSlvPinCoup);
        }

        // PUT: api/ElasticSlvPinCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElasticSlvPinCoup(string id, ElasticSlvPinCoup elasticSlvPinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elasticSlvPinCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(elasticSlvPinCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElasticSlvPinCoupExists(id))
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

        // POST: api/ElasticSlvPinCoups
        [ResponseType(typeof(ElasticSlvPinCoup))]
        public async Task<IHttpActionResult> PostElasticSlvPinCoup(ElasticSlvPinCoup elasticSlvPinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ElasticSleevePinCoupling.Add(elasticSlvPinCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ElasticSlvPinCoupExists(elasticSlvPinCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elasticSlvPinCoup.TypeID }, elasticSlvPinCoup);
        }

        // DELETE: api/ElasticSlvPinCoups/5
        [ResponseType(typeof(ElasticSlvPinCoup))]
        public async Task<IHttpActionResult> DeleteElasticSlvPinCoup(string id)
        {
            ElasticSlvPinCoup elasticSlvPinCoup = await db.ElasticSleevePinCoupling.FindAsync(id);
            if (elasticSlvPinCoup == null)
            {
                return NotFound();
            }

            db.ElasticSleevePinCoupling.Remove(elasticSlvPinCoup);
            await db.SaveChangesAsync();

            return Ok(elasticSlvPinCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElasticSlvPinCoupExists(string id)
        {
            return db.ElasticSleevePinCoupling.Count(e => e.TypeID == id) > 0;
        }
    }
}