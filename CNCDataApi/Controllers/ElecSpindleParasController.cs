﻿using System;
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
    public class ElecSpindleParasController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/ElecSpindleParas
        public IQueryable<ElecSpindlePara> GetParaOfElectricSpindle()
        {
            return db.ParaOfElectricSpindle;
        }

        // GET: api/ElecSpindleParas/5
        [ResponseType(typeof(ElecSpindlePara))]
        public async Task<IHttpActionResult> GetElecSpindlePara(string id)
        {
            ElecSpindlePara elecSpindlePara = await db.ParaOfElectricSpindle.FindAsync(id);
            if (elecSpindlePara == null)
            {
                return NotFound();
            }

            return Ok(elecSpindlePara);
        }

        // PUT: api/ElecSpindleParas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElecSpindlePara(string id, ElecSpindlePara elecSpindlePara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elecSpindlePara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(elecSpindlePara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElecSpindleParaExists(id))
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

        // POST: api/ElecSpindleParas
        [ResponseType(typeof(ElecSpindlePara))]
        public async Task<IHttpActionResult> PostElecSpindlePara(ElecSpindlePara elecSpindlePara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParaOfElectricSpindle.Add(elecSpindlePara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ElecSpindleParaExists(elecSpindlePara.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elecSpindlePara.TypeID }, elecSpindlePara);
        }

        // DELETE: api/ElecSpindleParas/5
        [ResponseType(typeof(ElecSpindlePara))]
        public async Task<IHttpActionResult> DeleteElecSpindlePara(string id)
        {
            ElecSpindlePara elecSpindlePara = await db.ParaOfElectricSpindle.FindAsync(id);
            if (elecSpindlePara == null)
            {
                return NotFound();
            }

            db.ParaOfElectricSpindle.Remove(elecSpindlePara);
            await db.SaveChangesAsync();

            return Ok(elecSpindlePara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElecSpindleParaExists(string id)
        {
            return db.ParaOfElectricSpindle.Count(e => e.TypeID == id) > 0;
        }
    }
}