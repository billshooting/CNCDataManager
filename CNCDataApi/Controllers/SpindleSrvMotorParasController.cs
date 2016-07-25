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
    public class SpindleSrvMotorParasController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/SpindleSrvMotorParas
        public IQueryable<SpindleSrvMotorPara> GetSpindleSrvMotorParas()
        {
            return db.SpindleSrvMotorParas;
        }

        // GET: api/SpindleSrvMotorParas/5
        [ResponseType(typeof(SpindleSrvMotorPara))]
        public async Task<IHttpActionResult> GetSpindleSrvMotorPara(string id)
        {
            SpindleSrvMotorPara spindleSrvMotorPara = await db.SpindleSrvMotorParas.FindAsync(id);
            if (spindleSrvMotorPara == null)
            {
                return NotFound();
            }

            return Ok(spindleSrvMotorPara);
        }

        // PUT: api/SpindleSrvMotorParas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpindleSrvMotorPara(string id, SpindleSrvMotorPara spindleSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleSrvMotorPara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleSrvMotorPara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleSrvMotorParaExists(id))
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

        // POST: api/SpindleSrvMotorParas
        [ResponseType(typeof(SpindleSrvMotorPara))]
        public async Task<IHttpActionResult> PostSpindleSrvMotorPara(SpindleSrvMotorPara spindleSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleSrvMotorParas.Add(spindleSrvMotorPara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleSrvMotorParaExists(spindleSrvMotorPara.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleSrvMotorPara.TypeID }, spindleSrvMotorPara);
        }

        // DELETE: api/SpindleSrvMotorParas/5
        [ResponseType(typeof(SpindleSrvMotorPara))]
        public async Task<IHttpActionResult> DeleteSpindleSrvMotorPara(string id)
        {
            SpindleSrvMotorPara spindleSrvMotorPara = await db.SpindleSrvMotorParas.FindAsync(id);
            if (spindleSrvMotorPara == null)
            {
                return NotFound();
            }

            db.SpindleSrvMotorParas.Remove(spindleSrvMotorPara);
            await db.SaveChangesAsync();

            return Ok(spindleSrvMotorPara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleSrvMotorParaExists(string id)
        {
            return db.SpindleSrvMotorParas.Count(e => e.TypeID == id) > 0;
        }
    }
}