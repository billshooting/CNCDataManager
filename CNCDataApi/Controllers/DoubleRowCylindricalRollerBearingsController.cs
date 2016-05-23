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
    //双列圆柱滚子轴承
    public class DoubleRowCylindricalRollerBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/DoubleRowCylindricalRollerBearings
        public IQueryable<Bearings_DoubleRowCylindricalRollerBearings> GetBearings_DoubleRowCylindricalRollerBearings()
        {
            return db.Bearings_DoubleRowCylindricalRollerBearings;
        }

        // GET: api/DoubleRowCylindricalRollerBearings/5
        [ResponseType(typeof(Bearings_DoubleRowCylindricalRollerBearings))]
        public async Task<IHttpActionResult> GetBearings_DoubleRowCylindricalRollerBearings(string id)
        {
            Bearings_DoubleRowCylindricalRollerBearings bearings_DoubleRowCylindricalRollerBearings = await db.Bearings_DoubleRowCylindricalRollerBearings.FindAsync(id);
            if (bearings_DoubleRowCylindricalRollerBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_DoubleRowCylindricalRollerBearings);
        }

        // PUT: api/DoubleRowCylindricalRollerBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_DoubleRowCylindricalRollerBearings(string id, Bearings_DoubleRowCylindricalRollerBearings bearings_DoubleRowCylindricalRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_DoubleRowCylindricalRollerBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_DoubleRowCylindricalRollerBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_DoubleRowCylindricalRollerBearingsExists(id))
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

        // POST: api/DoubleRowCylindricalRollerBearings
        [ResponseType(typeof(Bearings_DoubleRowCylindricalRollerBearings))]
        public async Task<IHttpActionResult> PostBearings_DoubleRowCylindricalRollerBearings(Bearings_DoubleRowCylindricalRollerBearings bearings_DoubleRowCylindricalRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_DoubleRowCylindricalRollerBearings.Add(bearings_DoubleRowCylindricalRollerBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_DoubleRowCylindricalRollerBearingsExists(bearings_DoubleRowCylindricalRollerBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_DoubleRowCylindricalRollerBearings.TypeNo }, bearings_DoubleRowCylindricalRollerBearings);
        }

        // DELETE: api/DoubleRowCylindricalRollerBearings/5
        [ResponseType(typeof(Bearings_DoubleRowCylindricalRollerBearings))]
        public async Task<IHttpActionResult> DeleteBearings_DoubleRowCylindricalRollerBearings(string id)
        {
            Bearings_DoubleRowCylindricalRollerBearings bearings_DoubleRowCylindricalRollerBearings = await db.Bearings_DoubleRowCylindricalRollerBearings.FindAsync(id);
            if (bearings_DoubleRowCylindricalRollerBearings == null)
            {
                return NotFound();
            }

            db.Bearings_DoubleRowCylindricalRollerBearings.Remove(bearings_DoubleRowCylindricalRollerBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_DoubleRowCylindricalRollerBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_DoubleRowCylindricalRollerBearingsExists(string id)
        {
            return db.Bearings_DoubleRowCylindricalRollerBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}