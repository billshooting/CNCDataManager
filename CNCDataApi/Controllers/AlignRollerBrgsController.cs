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
    public class AlignRollerBrgsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/AlignRollerBrgs
        public IQueryable<AlignRollerBrg> GetAligningRollerBearing()
        {
            return db.AligningRollerBearing;
        }

        // GET: api/AlignRollerBrgs/5
        [ResponseType(typeof(AlignRollerBrg))]
        public async Task<IHttpActionResult> GetAlignRollerBrg(string id)
        {
            AlignRollerBrg alignRollerBrg = await db.AligningRollerBearing.FindAsync(id);
            if (alignRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(alignRollerBrg);
        }

        // PUT: api/AlignRollerBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlignRollerBrg(string id, AlignRollerBrg alignRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alignRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(alignRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlignRollerBrgExists(id))
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

        // POST: api/AlignRollerBrgs
        [ResponseType(typeof(AlignRollerBrg))]
        public async Task<IHttpActionResult> PostAlignRollerBrg(AlignRollerBrg alignRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AligningRollerBearing.Add(alignRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlignRollerBrgExists(alignRollerBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = alignRollerBrg.TypeID }, alignRollerBrg);
        }

        // DELETE: api/AlignRollerBrgs/5
        [ResponseType(typeof(AlignRollerBrg))]
        public async Task<IHttpActionResult> DeleteAlignRollerBrg(string id)
        {
            AlignRollerBrg alignRollerBrg = await db.AligningRollerBearing.FindAsync(id);
            if (alignRollerBrg == null)
            {
                return NotFound();
            }

            db.AligningRollerBearing.Remove(alignRollerBrg);
            await db.SaveChangesAsync();

            return Ok(alignRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlignRollerBrgExists(string id)
        {
            return db.AligningRollerBearing.Count(e => e.TypeID == id) > 0;
        }
    }
}