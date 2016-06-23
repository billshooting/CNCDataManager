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
    public class RotaryTablesController : ApiController
    {
        private CNCDataBase db = new CNCDataBase();

        // GET: api/RotaryTables
        public IQueryable<RotaryTable> GetRotaryTable()
        {
            return db.RotaryTable;
        }

        // GET: api/RotaryTables/5
        [ResponseType(typeof(RotaryTable))]
        public async Task<IHttpActionResult> GetRotaryTable(string id)
        {
            RotaryTable rotaryTable = await db.RotaryTable.FindAsync(id);
            if (rotaryTable == null)
            {
                return NotFound();
            }

            return Ok(rotaryTable);
        }

        // PUT: api/RotaryTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRotaryTable(string id, RotaryTable rotaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rotaryTable.TypeID)
            {
                return BadRequest();
            }

            db.Entry(rotaryTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaryTableExists(id))
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

        // POST: api/RotaryTables
        [ResponseType(typeof(RotaryTable))]
        public async Task<IHttpActionResult> PostRotaryTable(RotaryTable rotaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RotaryTable.Add(rotaryTable);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RotaryTableExists(rotaryTable.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rotaryTable.TypeID }, rotaryTable);
        }

        // DELETE: api/RotaryTables/5
        [ResponseType(typeof(RotaryTable))]
        public async Task<IHttpActionResult> DeleteRotaryTable(string id)
        {
            RotaryTable rotaryTable = await db.RotaryTable.FindAsync(id);
            if (rotaryTable == null)
            {
                return NotFound();
            }

            db.RotaryTable.Remove(rotaryTable);
            await db.SaveChangesAsync();

            return Ok(rotaryTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RotaryTableExists(string id)
        {
            return db.RotaryTable.Count(e => e.TypeID == id) > 0;
        }
    }
}