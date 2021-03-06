﻿using CNCDataManager.APIs.Models;
using CNCDataManager.APIs.Internals;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CNCDataManager.APIs.Controllers
{
    //[ApiAuthorize]
    public class XTaperedRollerBrgsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/XTaperedRollerBrgs
        [AllowAnonymous]
        public IQueryable<XTaperedRollerBrg> GetXTaperedRollerBearings()
        {
            return db.XTaperedRollerBearings;
        }

        // GET: api/XTaperedRollerBrgs/5
        [AllowAnonymous]
        [ResponseType(typeof(XTaperedRollerBrg))]
        public async Task<IHttpActionResult> GetXTaperedRollerBrg(string id)
        {
            XTaperedRollerBrg xTaperedRollerBrg = await db.XTaperedRollerBearings.FindAsync(id);
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

            db.XTaperedRollerBearings.Add(xTaperedRollerBrg);

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
            XTaperedRollerBrg xTaperedRollerBrg = await db.XTaperedRollerBearings.FindAsync(id);
            if (xTaperedRollerBrg == null)
            {
                return NotFound();
            }

            db.XTaperedRollerBearings.Remove(xTaperedRollerBrg);
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
            return db.XTaperedRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}