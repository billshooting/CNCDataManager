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
    public class RotaryTableController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/RotaryTable
        public IQueryable<Table_RotaryTable> GetTable_RotaryTable()
        {
            return db.Table_RotaryTable;
        }

        // GET: api/RotaryTable/5
        [ResponseType(typeof(Table_RotaryTable))]
        public async Task<IHttpActionResult> GetTable_RotaryTable(string id)
        {
            Table_RotaryTable table_RotaryTable = await db.Table_RotaryTable.FindAsync(id);
            if (table_RotaryTable == null)
            {
                return NotFound();
            }

            return Ok(table_RotaryTable);
        }

        // PUT: api/RotaryTable/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTable_RotaryTable(string id, Table_RotaryTable table_RotaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != table_RotaryTable.TypeNo)
            {
                return BadRequest();
            }

            db.Entry(table_RotaryTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Table_RotaryTableExists(id))
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

        // POST: api/RotaryTable
        [ResponseType(typeof(Table_RotaryTable))]
        public async Task<IHttpActionResult> PostTable_RotaryTable(Table_RotaryTable table_RotaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Table_RotaryTable.Add(table_RotaryTable);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Table_RotaryTableExists(table_RotaryTable.TypeNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = table_RotaryTable.TypeNo }, table_RotaryTable);
        }

        // DELETE: api/RotaryTable/5
        [ResponseType(typeof(Table_RotaryTable))]
        public async Task<IHttpActionResult> DeleteTable_RotaryTable(string id)
        {
            Table_RotaryTable table_RotaryTable = await db.Table_RotaryTable.FindAsync(id);
            if (table_RotaryTable == null)
            {
                return NotFound();
            }

            db.Table_RotaryTable.Remove(table_RotaryTable);
            await db.SaveChangesAsync();

            return Ok(table_RotaryTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Table_RotaryTableExists(string id)
        {
            return db.Table_RotaryTable.Count(e => e.TypeNo == id) > 0;
        }
    }
}