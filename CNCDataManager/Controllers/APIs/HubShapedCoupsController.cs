﻿using CNCDataManager.APIs.Models;
using CNCDataManager.APIs.Internals;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace CNCDataManager.APIs.Controllers
{
    //[ApiAuthorize]
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    public class HubShapedCoupsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/HubShapedCoups
        [AllowAnonymous]
        public IQueryable<HubShapedCoup> GetHubShapedCouplings()
        {
            return db.HubShapedCouplings;
        }

        // GET: api/HubShapedCoups/5
        [AllowAnonymous]
        [ResponseType(typeof(HubShapedCoup))]
        public async Task<IHttpActionResult> GetHubShapedCoup(string id)
        {
            HubShapedCoup hubShapedCoup = await db.HubShapedCouplings.FindAsync(id);
            if (hubShapedCoup == null)
            {
                return NotFound();
            }

            return Ok(hubShapedCoup);
        }

        // PUT: api/HubShapedCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHubShapedCoup(string id, HubShapedCoup hubShapedCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hubShapedCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(hubShapedCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HubShapedCoupExists(id))
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

        // POST: api/HubShapedCoups
        [ResponseType(typeof(HubShapedCoup))]
        public async Task<IHttpActionResult> PostHubShapedCoup(HubShapedCoup hubShapedCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HubShapedCouplings.Add(hubShapedCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HubShapedCoupExists(hubShapedCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hubShapedCoup.TypeID }, hubShapedCoup);
        }

        // DELETE: api/HubShapedCoups/5
        [ResponseType(typeof(HubShapedCoup))]
        public async Task<IHttpActionResult> DeleteHubShapedCoup(string id)
        {
            HubShapedCoup hubShapedCoup = await db.HubShapedCouplings.FindAsync(id);
            if (hubShapedCoup == null)
            {
                return NotFound();
            }

            db.HubShapedCouplings.Remove(hubShapedCoup);
            await db.SaveChangesAsync();

            return Ok(hubShapedCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HubShapedCoupExists(string id)
        {
            return db.HubShapedCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}