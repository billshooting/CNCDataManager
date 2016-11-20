using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Novacode;
using System.IO;
using CNCDataManager.Controllers.Internals;

namespace CNCDataManager.Controllers.Internals
{
    internal class DocxGenerator
    {
        private DocX document;

        public string DocName { get; }
        public Stream DocStream { get; }

        public DocxGenerator(string filename = @"~/App/docTemplate/选型简表结果.docx")
        {
            DocName = filename;
            DocStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            document = DocX.Load(filename);
        }


        public DocxGenerator AddMachinePicture(string machineImage)
        {
            Image image = document.AddImage(machineImage);
            Picture pic = image.CreatePicture(250, 350);
            var p = document.Tables[1].Rows.FirstOrDefault().Paragraphs.FirstOrDefault();
            p.InsertPicture(pic);
            return this;
        }

        public DocxGenerator AddSimulationPictures(params string[] simuImages)
        {
            int index = 0;
            foreach(string simuImage in simuImages)
            {
                Image image = document.AddImage(simuImage);
                Picture pic = image.CreatePicture(250, 350);
                var p = document.Tables[9].Rows[index++].Paragraphs.FirstOrDefault();
                p.InsertPicture(pic);
            }
            return this;
        }

        public DocxGenerator AddAllPictures(params string[] imageFiles)
        {
            string machinePic = imageFiles[0];
            AddMachinePicture(machinePic).AddSimulationPictures(imageFiles.Skip(1).ToArray());
            return this;
        }
    }
}