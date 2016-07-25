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
using CNCDataManager.Models;

namespace CNCDataManager.Controllers
{
    public class CommonCylinWormGearsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/CommonCylinWormGears
        public IQueryable<CommonCylinWormGear> GetCommonCylinWormGears()
        {
            return db.CommonCylinWormGears;
        }

        // GET: api/CommonCylinWormGears/5
        [ResponseType(typeof(CommonCylinWormGear))]
        public async Task<IHttpActionResult> GetCommonCylinWormGear(string id)
        {
            CommonCylinWormGear commonCylinWormGear = await db.CommonCylinWormGears.FindAsync(id);
            if (commonCylinWormGear == null)
            {
                return NotFound();
            }

            return Ok(commonCylinWormGear);
        }

        // PUT: api/CommonCylinWormGears/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCommonCylinWormGear(string id, CommonCylinWormGear commonCylinWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commonCylinWormGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(commonCylinWormGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommonCylinWormGearExists(id))
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

        // POST: api/CommonCylinWormGears
        [ResponseType(typeof(CommonCylinWormGear))]
        public async Task<IHttpActionResult> PostCommonCylinWormGear(CommonCylinWormGear commonCylinWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommonCylinWormGears.Add(commonCylinWormGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommonCylinWormGearExists(commonCylinWormGear.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commonCylinWormGear.TypeID }, commonCylinWormGear);
        }

        // DELETE: api/CommonCylinWormGears/5
        [ResponseType(typeof(CommonCylinWormGear))]
        public async Task<IHttpActionResult> DeleteCommonCylinWormGear(string id)
        {
            CommonCylinWormGear commonCylinWormGear = await db.CommonCylinWormGears.FindAsync(id);
            if (commonCylinWormGear == null)
            {
                return NotFound();
            }

            db.CommonCylinWormGears.Remove(commonCylinWormGear);
            await db.SaveChangesAsync();

            return Ok(commonCylinWormGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommonCylinWormGearExists(string id)
        {
            return db.CommonCylinWormGears.Count(e => e.TypeID == id) > 0;
        }
    }
}