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
    //斜齿圆柱齿轮
    public class HelicalCylindricalGearController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/HelicalCylindricalGear
        public IQueryable<Gear_HelicalCylindricalGear> GetGear_HelicalCylindricalGear()
        {
            return db.Gear_HelicalCylindricalGear;
        }

        // GET: api/HelicalCylindricalGear/5
        [ResponseType(typeof(Gear_HelicalCylindricalGear))]
        public async Task<IHttpActionResult> GetGear_HelicalCylindricalGear(string id)
        {
            Gear_HelicalCylindricalGear gear_HelicalCylindricalGear = await db.Gear_HelicalCylindricalGear.FindAsync(id);
            if (gear_HelicalCylindricalGear == null)
            {
                return NotFound();
            }

            return Ok(gear_HelicalCylindricalGear);
        }

        // PUT: api/HelicalCylindricalGear/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGear_HelicalCylindricalGear(string id, Gear_HelicalCylindricalGear gear_HelicalCylindricalGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gear_HelicalCylindricalGear.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(gear_HelicalCylindricalGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Gear_HelicalCylindricalGearExists(id))
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

        // POST: api/HelicalCylindricalGear
        [ResponseType(typeof(Gear_HelicalCylindricalGear))]
        public async Task<IHttpActionResult> PostGear_HelicalCylindricalGear(Gear_HelicalCylindricalGear gear_HelicalCylindricalGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gear_HelicalCylindricalGear.Add(gear_HelicalCylindricalGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Gear_HelicalCylindricalGearExists(gear_HelicalCylindricalGear.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gear_HelicalCylindricalGear.TypeNo }, gear_HelicalCylindricalGear);
        }

        // DELETE: api/HelicalCylindricalGear/5
        [ResponseType(typeof(Gear_HelicalCylindricalGear))]
        public async Task<IHttpActionResult> DeleteGear_HelicalCylindricalGear(string id)
        {
            Gear_HelicalCylindricalGear gear_HelicalCylindricalGear = await db.Gear_HelicalCylindricalGear.FindAsync(id);
            if (gear_HelicalCylindricalGear == null)
            {
                return NotFound();
            }

            db.Gear_HelicalCylindricalGear.Remove(gear_HelicalCylindricalGear);
            await db.SaveChangesAsync();

            return Ok(gear_HelicalCylindricalGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Gear_HelicalCylindricalGearExists(string id)
        {
            return db.Gear_HelicalCylindricalGear.Count(e => e.TypeNo == id) > 0;
        }
    }
}