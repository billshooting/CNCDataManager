using CNCDataManager.APIs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Novacode;
using System.Drawing;

namespace CNCDataManager.APIs.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UploadFilesController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();
        // GET: api/UploadFile
        public void Get()
        {
        }

        // GET: api/UploadFile/5
        public void Get(string text)
        {
        }

        // POST: api/UploadFile
        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            string name = HttpContext.Current.Request["name"];
            string description = HttpContext.Current.Request["description"];
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;
            if (file == null) return Json(new UploadResult() { IsUploadedSuccessful = false, FileUrl = string.Empty, FailReason = "Uploaded Nothing!" });
            string filename = name + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/App/images/Upload"), filename);
            try
            {
                await Task.Run(() => file.SaveAs(fullPath));
                string returnUrl = Path.Combine("../App/images/Upload/", filename);
                await AddToDB(db, name, description, returnUrl);
                UploadResult result = new UploadResult() { IsUploadedSuccessful = true, FileUrl = returnUrl };
                return Json(result);
            }
            catch (IOException ex)
            {
                UploadResult result = new UploadResult() { IsUploadedSuccessful = false, FileUrl = string.Empty, FailReason = ex.Message };
                return Json(result);
            }
        }

        private async Task AddToDB(CNCMachineData db, string name, string desc, string url)
        {
            CNCMachineType tt = new CNCMachineType() { MachineType = name, MainType = desc, ThumbNailUrl = url };
            db.CNCMachineTypes.Add(tt);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
            }
        }

        // PUT: api/UploadFile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UploadFile/5
        public void Delete(int id)
        {
        }
        private class UploadResult
        {
            public bool IsUploadedSuccessful { get; set; }
            public string FileUrl { get; set; }
            public string FailReason { get; set; }
        }
    }
}
