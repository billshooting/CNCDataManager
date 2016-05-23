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
    //圆柱滚子轴承
    public class CylindricalRollerBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/CylindricalRollerBearings
        public IQueryable<Bearings_CylindricalRollerBearings> GetBearings_CylindricalRollerBearings()
        {
            return db.Bearings_CylindricalRollerBearings;
        }

        // GET: api/CylindricalRollerBearings/5
        [ResponseType(typeof(Bearings_CylindricalRollerBearings))]
        public async Task<IHttpActionResult> GetBearings_CylindricalRollerBearings(string id)
        {
            Bearings_CylindricalRollerBearings bearings_CylindricalRollerBearings = await db.Bearings_CylindricalRollerBearings.FindAsync(id);
            if (bearings_CylindricalRollerBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_CylindricalRollerBearings);
        }

        // PUT: api/CylindricalRollerBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_CylindricalRollerBearings(string id, Bearings_CylindricalRollerBearings bearings_CylindricalRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_CylindricalRollerBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_CylindricalRollerBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_CylindricalRollerBearingsExists(id))
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

        // POST: api/CylindricalRollerBearings
        [ResponseType(typeof(Bearings_CylindricalRollerBearings))]
        public async Task<IHttpActionResult> PostBearings_CylindricalRollerBearings(Bearings_CylindricalRollerBearings bearings_CylindricalRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_CylindricalRollerBearings.Add(bearings_CylindricalRollerBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_CylindricalRollerBearingsExists(bearings_CylindricalRollerBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_CylindricalRollerBearings.TypeNo }, bearings_CylindricalRollerBearings);
        }

        // DELETE: api/CylindricalRollerBearings/5
        [ResponseType(typeof(Bearings_CylindricalRollerBearings))]
        public async Task<IHttpActionResult> DeleteBearings_CylindricalRollerBearings(string id)
        {
            Bearings_CylindricalRollerBearings bearings_CylindricalRollerBearings = await db.Bearings_CylindricalRollerBearings.FindAsync(id);
            if (bearings_CylindricalRollerBearings == null)
            {
                return NotFound();
            }

            db.Bearings_CylindricalRollerBearings.Remove(bearings_CylindricalRollerBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_CylindricalRollerBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_CylindricalRollerBearingsExists(string id)
        {
            return db.Bearings_CylindricalRollerBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}