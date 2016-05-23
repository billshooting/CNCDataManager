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
    //实心滚珠丝杠螺母副
    public class SolidBallScrewNutPairsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/SolidBallScrewNutPairs
        public IQueryable<NutPairs_SolidBallScrewNutPairs> GetNutPairs_SolidBallScrewNutPairs()
        {
            return db.NutPairs_SolidBallScrewNutPairs;
        }

        // GET: api/SolidBallScrewNutPairs/5
        [ResponseType(typeof(NutPairs_SolidBallScrewNutPairs))]
        public async Task<IHttpActionResult> GetNutPairs_SolidBallScrewNutPairs(string id)
        {
            NutPairs_SolidBallScrewNutPairs nutPairs_SolidBallScrewNutPairs = await db.NutPairs_SolidBallScrewNutPairs.FindAsync(id);
            if (nutPairs_SolidBallScrewNutPairs == null)
            {
                return NotFound();
            }

            return Ok(nutPairs_SolidBallScrewNutPairs);
        }

        // PUT: api/SolidBallScrewNutPairs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNutPairs_SolidBallScrewNutPairs(string id, NutPairs_SolidBallScrewNutPairs nutPairs_SolidBallScrewNutPairs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nutPairs_SolidBallScrewNutPairs.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(nutPairs_SolidBallScrewNutPairs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutPairs_SolidBallScrewNutPairsExists(id))
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

        // POST: api/SolidBallScrewNutPairs
        [ResponseType(typeof(NutPairs_SolidBallScrewNutPairs))]
        public async Task<IHttpActionResult> PostNutPairs_SolidBallScrewNutPairs(NutPairs_SolidBallScrewNutPairs nutPairs_SolidBallScrewNutPairs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NutPairs_SolidBallScrewNutPairs.Add(nutPairs_SolidBallScrewNutPairs);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NutPairs_SolidBallScrewNutPairsExists(nutPairs_SolidBallScrewNutPairs.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nutPairs_SolidBallScrewNutPairs.TypeNo }, nutPairs_SolidBallScrewNutPairs);
        }

        // DELETE: api/SolidBallScrewNutPairs/5
        [ResponseType(typeof(NutPairs_SolidBallScrewNutPairs))]
        public async Task<IHttpActionResult> DeleteNutPairs_SolidBallScrewNutPairs(string id)
        {
            NutPairs_SolidBallScrewNutPairs nutPairs_SolidBallScrewNutPairs = await db.NutPairs_SolidBallScrewNutPairs.FindAsync(id);
            if (nutPairs_SolidBallScrewNutPairs == null)
            {
                return NotFound();
            }

            db.NutPairs_SolidBallScrewNutPairs.Remove(nutPairs_SolidBallScrewNutPairs);
            await db.SaveChangesAsync();

            return Ok(nutPairs_SolidBallScrewNutPairs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NutPairs_SolidBallScrewNutPairsExists(string id)
        {
            return db.NutPairs_SolidBallScrewNutPairs.Count(e => e.TypeNo == id) > 0;
        }
    }
}