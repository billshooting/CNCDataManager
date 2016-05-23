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
    //轮毂型联轴器
    public class HubShapedCouplingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/HubShapedCouplings
        public IQueryable<Coupling_HubShapedCouplings> GetCoupling_HubShapedCouplings()
        {
            return db.Coupling_HubShapedCouplings;
        }

        // GET: api/HubShapedCouplings/5
        [ResponseType(typeof(Coupling_HubShapedCouplings))]
        public async Task<IHttpActionResult> GetCoupling_HubShapedCouplings(string id)
        {
            Coupling_HubShapedCouplings coupling_HubShapedCouplings = await db.Coupling_HubShapedCouplings.FindAsync(id);
            if (coupling_HubShapedCouplings == null)
            {
                return NotFound();
            }

            return Ok(coupling_HubShapedCouplings);
        }

        // PUT: api/HubShapedCouplings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoupling_HubShapedCouplings(string id, Coupling_HubShapedCouplings coupling_HubShapedCouplings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupling_HubShapedCouplings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(coupling_HubShapedCouplings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Coupling_HubShapedCouplingsExists(id))
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

        // POST: api/HubShapedCouplings
        [ResponseType(typeof(Coupling_HubShapedCouplings))]
        public async Task<IHttpActionResult> PostCoupling_HubShapedCouplings(Coupling_HubShapedCouplings coupling_HubShapedCouplings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupling_HubShapedCouplings.Add(coupling_HubShapedCouplings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Coupling_HubShapedCouplingsExists(coupling_HubShapedCouplings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = coupling_HubShapedCouplings.TypeNo }, coupling_HubShapedCouplings);
        }

        // DELETE: api/HubShapedCouplings/5
        [ResponseType(typeof(Coupling_HubShapedCouplings))]
        public async Task<IHttpActionResult> DeleteCoupling_HubShapedCouplings(string id)
        {
            Coupling_HubShapedCouplings coupling_HubShapedCouplings = await db.Coupling_HubShapedCouplings.FindAsync(id);
            if (coupling_HubShapedCouplings == null)
            {
                return NotFound();
            }

            db.Coupling_HubShapedCouplings.Remove(coupling_HubShapedCouplings);
            await db.SaveChangesAsync();

            return Ok(coupling_HubShapedCouplings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Coupling_HubShapedCouplingsExists(string id)
        {
            return db.Coupling_HubShapedCouplings.Count(e => e.TypeNo == id) > 0;
        }
    }
}