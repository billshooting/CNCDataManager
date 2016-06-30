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
    public class PMSrvMotorParasController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/PMSrvMotorParas
        public IQueryable<PMSrvMotorPara> GetParaOfServoMotorOfPMSACFS()
        {
            return db.ParaOfServoMotorOfPMSACFS;
        }

        // GET: api/PMSrvMotorParas/5
        [ResponseType(typeof(PMSrvMotorPara))]
        public async Task<IHttpActionResult> GetPMSrvMotorPara(string id)
        {
            PMSrvMotorPara pMSrvMotorPara = await db.ParaOfServoMotorOfPMSACFS.FindAsync(id);
            if (pMSrvMotorPara == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorPara);
        }

        // PUT: api/PMSrvMotorParas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPMSrvMotorPara(string id, PMSrvMotorPara pMSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorPara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorPara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorParaExists(id))
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

        // POST: api/PMSrvMotorParas
        [ResponseType(typeof(PMSrvMotorPara))]
        public async Task<IHttpActionResult> PostPMSrvMotorPara(PMSrvMotorPara pMSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParaOfServoMotorOfPMSACFS.Add(pMSrvMotorPara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorParaExists(pMSrvMotorPara.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorPara.TypeID }, pMSrvMotorPara);
        }

        // DELETE: api/PMSrvMotorParas/5
        [ResponseType(typeof(PMSrvMotorPara))]
        public async Task<IHttpActionResult> DeletePMSrvMotorPara(string id)
        {
            PMSrvMotorPara pMSrvMotorPara = await db.ParaOfServoMotorOfPMSACFS.FindAsync(id);
            if (pMSrvMotorPara == null)
            {
                return NotFound();
            }

            db.ParaOfServoMotorOfPMSACFS.Remove(pMSrvMotorPara);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorPara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorParaExists(string id)
        {
            return db.ParaOfServoMotorOfPMSACFS.Count(e => e.TypeID == id) > 0;
        }
    }
}