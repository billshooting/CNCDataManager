using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Novacode;
using System.IO;
using CNCDataManager.Controllers.Internals;

namespace CNCDataManager.Controllers.Internals
{
    internal class DocxGenerator: IDisposable
    {
        private const int machinePictureIndex = 1;
        private const int transmissionMethodIndex = 2;
        private const int componentsTableIndex = 3;
        private const int essentialPartsIndex = 4;
        private const int servoMotorIndex = 5;
        private const int servoDriverIndex = 6;
        private const int guideTableIndex = 7;
        private const int ballScrewIndex = 8;
        private const int simuPictureIndex = 9;

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
            var p = document.Tables[machinePictureIndex].Rows.FirstOrDefault().Paragraphs.FirstOrDefault();
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
                var p = document.Tables[simuPictureIndex].Rows[index++].Paragraphs.FirstOrDefault();
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

        public DocxGenerator AddContent(SelectionResult result)
        {

            return this;
        }

        private void AddTransMissionMethod(TransmissionMethod tm)
        {
            var cellX = document.Tables[transmissionMethodIndex].Rows[1].Cells[1].Paragraphs.FirstOrDefault();
            cellX.Append(tm.XAxis);
            var cellY = document.Tables[transmissionMethodIndex].Rows[2].Cells[1].Paragraphs.FirstOrDefault();
            cellY.Append(tm.YAxis);
            var cellZ = document.Tables[transmissionMethodIndex].Rows[3].Cells[1].Paragraphs.FirstOrDefault();
            cellZ.Append(tm.ZAxis);
        }

        private void AddComponents(IList<Component> comps)
        {
            Paragraph p;
            for (int i = 0; i < Math.Min(comps.Count(), 47); i++)
            {
                p = document.Tables[componentsTableIndex].Rows[i + 1].Cells[1].Paragraphs.FirstOrDefault();
                p.Append(comps[i].AxisAndName);
                p = document.Tables[componentsTableIndex].Rows[i + 1].Cells[2].Paragraphs.FirstOrDefault();
                p.Append(comps[i].Manufacturer);
                p = document.Tables[componentsTableIndex].Rows[i + 1].Cells[3].Paragraphs.FirstOrDefault();
                p.Append(comps[i].TypeID);
            }
        }

        public void Dispose()
        {
            ((IDisposable)DocStream).Dispose();
            ((IDisposable)document).Dispose();
        }
    }
}