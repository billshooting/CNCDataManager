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
    public class FlexiblePinCoupsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/FlexiblePinCoups
        public IQueryable<FlexiblePinCoup> GetFlexiblePinCoupling()
        {
            return db.FlexiblePinCoupling;
        }

        // GET: api/FlexiblePinCoups/5
        [ResponseType(typeof(FlexiblePinCoup))]
        public async Task<IHttpActionResult> GetFlexiblePinCoup(string id)
        {
            FlexiblePinCoup flexiblePinCoup = await db.FlexiblePinCoupling.FindAsync(id);
            if (flexiblePinCoup == null)
            {
                return NotFound();
            }

            return Ok(flexiblePinCoup);
        }

        // PUT: api/FlexiblePinCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFlexiblePinCoup(string id, FlexiblePinCoup flexiblePinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flexiblePinCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(flexiblePinCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlexiblePinCoupExists(id))
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

        // POST: api/FlexiblePinCoups
        [ResponseType(typeof(FlexiblePinCoup))]
        public async Task<IHttpActionResult> PostFlexiblePinCoup(FlexiblePinCoup flexiblePinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlexiblePinCoupling.Add(flexiblePinCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlexiblePinCoupExists(flexiblePinCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = flexiblePinCoup.TypeID }, flexiblePinCoup);
        }

        // DELETE: api/FlexiblePinCoups/5
        [ResponseType(typeof(FlexiblePinCoup))]
        public async Task<IHttpActionResult> DeleteFlexiblePinCoup(string id)
        {
            FlexiblePinCoup flexiblePinCoup = await db.FlexiblePinCoupling.FindAsync(id);
            if (flexiblePinCoup == null)
            {
                return NotFound();
            }

            db.FlexiblePinCoupling.Remove(flexiblePinCoup);
            await db.SaveChangesAsync();

            return Ok(flexiblePinCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlexiblePinCoupExists(string id)
        {
            return db.FlexiblePinCoupling.Count(e => e.TypeID == id) > 0;
        }
    }
}