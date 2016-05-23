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
    //凸缘联轴器
    public class FlangeCouplingController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/FlangeCoupling
        public IQueryable<Coupling_FlangeCoupling> GetCoupling_FlangeCoupling()
        {
            return db.Coupling_FlangeCoupling;
        }

        // GET: api/FlangeCoupling/5
        [ResponseType(typeof(Coupling_FlangeCoupling))]
        public async Task<IHttpActionResult> GetCoupling_FlangeCoupling(string id)
        {
            Coupling_FlangeCoupling coupling_FlangeCoupling = await db.Coupling_FlangeCoupling.FindAsync(id);
            if (coupling_FlangeCoupling == null)
            {
                return NotFound();
            }

            return Ok(coupling_FlangeCoupling);
        }

        // PUT: api/FlangeCoupling/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoupling_FlangeCoupling(string id, Coupling_FlangeCoupling coupling_FlangeCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupling_FlangeCoupling.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(coupling_FlangeCoupling).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Coupling_FlangeCouplingExists(id))
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

        // POST: api/FlangeCoupling
        [ResponseType(typeof(Coupling_FlangeCoupling))]
        public async Task<IHttpActionResult> PostCoupling_FlangeCoupling(Coupling_FlangeCoupling coupling_FlangeCoupling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupling_FlangeCoupling.Add(coupling_FlangeCoupling);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Coupling_FlangeCouplingExists(coupling_FlangeCoupling.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = coupling_FlangeCoupling.TypeNo }, coupling_FlangeCoupling);
        }

        // DELETE: api/FlangeCoupling/5
        [ResponseType(typeof(Coupling_FlangeCoupling))]
        public async Task<IHttpActionResult> DeleteCoupling_FlangeCoupling(string id)
        {
            Coupling_FlangeCoupling coupling_FlangeCoupling = await db.Coupling_FlangeCoupling.FindAsync(id);
            if (coupling_FlangeCoupling == null)
            {
                return NotFound();
            }

            db.Coupling_FlangeCoupling.Remove(coupling_FlangeCoupling);
            await db.SaveChangesAsync();

            return Ok(coupling_FlangeCoupling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Coupling_FlangeCouplingExists(string id)
        {
            return db.Coupling_FlangeCoupling.Count(e => e.TypeNo == id) > 0;
        }
    }
}