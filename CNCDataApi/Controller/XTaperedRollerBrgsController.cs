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

namespace CNCDataApi.Controller
{
    public class XTaperedRollerBrgsController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/XTaperedRollerBrgs
        public IQueryable<XTaperedRollerBrg> GetCrossTaperedRollerBearings()
        {
            return db.CrossTaperedRollerBearings;
        }

        // GET: api/XTaperedRollerBrgs/5
        [ResponseType(typeof(XTaperedRollerBrg))]
        public async Task<IHttpActionResult> GetXTaperedRollerBrg(string id)
        {
            XTaperedRollerBrg xTaperedRollerBrg = await db.CrossTaperedRollerBearings.FindAsync(id);
            if (xTaperedRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(xTaperedRollerBrg);
        }

        // PUT: api/XTaperedRollerBrgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutXTaperedRollerBrg(string id, XTaperedRollerBrg xTaperedRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xTaperedRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(xTaperedRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XTaperedRollerBrgExists(id))
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

        // POST: api/XTaperedRollerBrgs
        [ResponseType(typeof(XTaperedRollerBrg))]
        public async Task<IHttpActionResult> PostXTaperedRollerBrg(XTaperedRollerBrg xTaperedRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CrossTaperedRollerBearings.Add(xTaperedRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (XTaperedRollerBrgExists(xTaperedRollerBrg.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = xTaperedRollerBrg.TypeID }, xTaperedRollerBrg);
        }

        // DELETE: api/XTaperedRollerBrgs/5
        [ResponseType(typeof(XTaperedRollerBrg))]
        public async Task<IHttpActionResult> DeleteXTaperedRollerBrg(string id)
        {
            XTaperedRollerBrg xTaperedRollerBrg = await db.CrossTaperedRollerBearings.FindAsync(id);
            if (xTaperedRollerBrg == null)
            {
                return NotFound();
            }

            db.CrossTaperedRollerBearings.Remove(xTaperedRollerBrg);
            await db.SaveChangesAsync();

            return Ok(xTaperedRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool XTaperedRollerBrgExists(string id)
        {
            return db.CrossTaperedRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}