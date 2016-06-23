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

namespace CNCDataApi.Controller
{
    public class DeepGrvBallBrgsController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/DeepGrvBallBrgs
        public IQueryable<DeepGrvBallBrg> GetDeepGrooveBallBearings()
        {
            return db.DeepGrooveBallBearings;
        }

        // GET: api/DeepGrvBallBrgs/5
        [ResponseType(typeof(DeepGrvBallBrg))]
        public async Task<IHttpActionResult> GetDeepGrvBallBrg(string id)
        {
            DeepGrvBallBrg deepGrvBallBrg = await db.DeepGrooveBallBearings.FindAsync(id);
            if (deepGrvBallBrg == null)
            {
                return NotFound();
            }

            return Ok(deepGrvBallBrg);
        }

        // PUT: api/DeepGrvBallBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeepGrvBallBrg(string id, DeepGrvBallBrg deepGrvBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deepGrvBallBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(deepGrvBallBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeepGrvBallBrgExists(id))
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

        // POST: api/DeepGrvBallBrgs
        [ResponseType(typeof(DeepGrvBallBrg))]
        public async Task<IHttpActionResult> PostDeepGrvBallBrg(DeepGrvBallBrg deepGrvBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeepGrooveBallBearings.Add(deepGrvBallBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeepGrvBallBrgExists(deepGrvBallBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deepGrvBallBrg.TypeID }, deepGrvBallBrg);
        }

        // DELETE: api/DeepGrvBallBrgs/5
        [ResponseType(typeof(DeepGrvBallBrg))]
        public async Task<IHttpActionResult> DeleteDeepGrvBallBrg(string id)
        {
            DeepGrvBallBrg deepGrvBallBrg = await db.DeepGrooveBallBearings.FindAsync(id);
            if (deepGrvBallBrg == null)
            {
                return NotFound();
            }

            db.DeepGrooveBallBearings.Remove(deepGrvBallBrg);
            await db.SaveChangesAsync();

            return Ok(deepGrvBallBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeepGrvBallBrgExists(string id)
        {
            return db.DeepGrooveBallBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}