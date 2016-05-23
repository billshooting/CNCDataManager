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
    /*交叉圆锥滚子轴承*/
    public class CrossTaperedRollerBearingsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/CrossTaperedRollerBearings
        public IQueryable<Bearings_CrossTaperedRollerBearings> GetBearings_CrossTaperedRollerBearings()
        {
            return db.Bearings_CrossTaperedRollerBearings;
        }

        // GET: api/CrossTaperedRollerBearings/5
        [ResponseType(typeof(Bearings_CrossTaperedRollerBearings))]
        public async Task<IHttpActionResult> GetBearings_CrossTaperedRollerBearings(string id)
        {
            Bearings_CrossTaperedRollerBearings bearings_CrossTaperedRollerBearings = await db.Bearings_CrossTaperedRollerBearings.FindAsync(id);
            if (bearings_CrossTaperedRollerBearings == null)
            {
                return NotFound();
            }

            return Ok(bearings_CrossTaperedRollerBearings);
        }

        // PUT: api/CrossTaperedRollerBearings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBearings_CrossTaperedRollerBearings(string id, Bearings_CrossTaperedRollerBearings bearings_CrossTaperedRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bearings_CrossTaperedRollerBearings.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(bearings_CrossTaperedRollerBearings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bearings_CrossTaperedRollerBearingsExists(id))
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

        // POST: api/CrossTaperedRollerBearings
        [ResponseType(typeof(Bearings_CrossTaperedRollerBearings))]
        public async Task<IHttpActionResult> PostBearings_CrossTaperedRollerBearings(Bearings_CrossTaperedRollerBearings bearings_CrossTaperedRollerBearings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bearings_CrossTaperedRollerBearings.Add(bearings_CrossTaperedRollerBearings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Bearings_CrossTaperedRollerBearingsExists(bearings_CrossTaperedRollerBearings.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bearings_CrossTaperedRollerBearings.TypeNo }, bearings_CrossTaperedRollerBearings);
        }

        // DELETE: api/CrossTaperedRollerBearings/5
        [ResponseType(typeof(Bearings_CrossTaperedRollerBearings))]
        public async Task<IHttpActionResult> DeleteBearings_CrossTaperedRollerBearings(string id)
        {
            Bearings_CrossTaperedRollerBearings bearings_CrossTaperedRollerBearings = await db.Bearings_CrossTaperedRollerBearings.FindAsync(id);
            if (bearings_CrossTaperedRollerBearings == null)
            {
                return NotFound();
            }

            db.Bearings_CrossTaperedRollerBearings.Remove(bearings_CrossTaperedRollerBearings);
            await db.SaveChangesAsync();

            return Ok(bearings_CrossTaperedRollerBearings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bearings_CrossTaperedRollerBearingsExists(string id)
        {
            return db.Bearings_CrossTaperedRollerBearings.Count(e => e.TypeNo == id) > 0;
        }
    }
}