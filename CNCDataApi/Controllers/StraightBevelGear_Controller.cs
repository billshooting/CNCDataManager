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
    //直齿圆锥齿轮
    public class StraightBevelGear_Controller : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/StraightBevelGear_
        public IQueryable<Gear_StraightBevelGear_> GetGear_StraightBevelGear_()
        {
            return db.Gear_StraightBevelGear_;
        }

        // GET: api/StraightBevelGear_/5
        [ResponseType(typeof(Gear_StraightBevelGear_))]
        public async Task<IHttpActionResult> GetGear_StraightBevelGear_(string id)
        {
            Gear_StraightBevelGear_ gear_StraightBevelGear_ = await db.Gear_StraightBevelGear_.FindAsync(id);
            if (gear_StraightBevelGear_ == null)
            {
                return NotFound();
            }

            return Ok(gear_StraightBevelGear_);
        }

        // PUT: api/StraightBevelGear_/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGear_StraightBevelGear_(string id, Gear_StraightBevelGear_ gear_StraightBevelGear_)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gear_StraightBevelGear_.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(gear_StraightBevelGear_).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Gear_StraightBevelGear_Exists(id))
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

        // POST: api/StraightBevelGear_
        [ResponseType(typeof(Gear_StraightBevelGear_))]
        public async Task<IHttpActionResult> PostGear_StraightBevelGear_(Gear_StraightBevelGear_ gear_StraightBevelGear_)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gear_StraightBevelGear_.Add(gear_StraightBevelGear_);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Gear_StraightBevelGear_Exists(gear_StraightBevelGear_.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gear_StraightBevelGear_.TypeNo }, gear_StraightBevelGear_);
        }

        // DELETE: api/StraightBevelGear_/5
        [ResponseType(typeof(Gear_StraightBevelGear_))]
        public async Task<IHttpActionResult> DeleteGear_StraightBevelGear_(string id)
        {
            Gear_StraightBevelGear_ gear_StraightBevelGear_ = await db.Gear_StraightBevelGear_.FindAsync(id);
            if (gear_StraightBevelGear_ == null)
            {
                return NotFound();
            }

            db.Gear_StraightBevelGear_.Remove(gear_StraightBevelGear_);
            await db.SaveChangesAsync();

            return Ok(gear_StraightBevelGear_);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Gear_StraightBevelGear_Exists(string id)
        {
            return db.Gear_StraightBevelGear_.Count(e => e.TypeNo == id) > 0;
        }
    }
}