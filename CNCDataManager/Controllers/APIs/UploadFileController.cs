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
            string basePath = HttpContext.Current.Server.MapPath("~/App/images/Upload");
            string fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/App/images/Upload"), "Test.docx");
            using (DocX document = DocX.Create(fileName))
            {
                //首先创建1个格式对象
                Formatting formatting = new Formatting();
                formatting.Bold = true;
                formatting.FontColor = Color.Red;
                formatting.Size = 30;
                //控制段落插入的位置
                int index = document.Text.Length / 2;
                //将文本插入到指定位置，并控制格式
                var p = document.InsertParagraph("Test File", false, formatting);
                Novacode.Image img = document.AddImage(Path.Combine(basePath, @"顾星炜.png"));
                p.InsertPicture(img.CreatePicture(), 2);
                document.Save();//保存文档
                HttpContext.Current.Response.WriteFile(fileName);
            }
        }

        // GET: api/UploadFile/5
        public void Get(string text)
        {
            string fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/App/images/Upload"), "Test.docx");
            using (DocX document = DocX.Create(fileName))
            {
                //首先创建1个格式对象
                Formatting formatting = new Formatting();
                formatting.Bold = true;
                formatting.FontColor = Color.Red;
                formatting.Size = 30;
                //控制段落插入的位置
                int index = document.Text.Length / 2;
                //将文本插入到指定位置，并控制格式
                document.InsertParagraph(index, text, false, formatting);
                document.Save();//保存文档
                HttpContext.Current.Response.WriteFile(fileName);
            }
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
