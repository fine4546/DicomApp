using CWDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDicomTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Ffilename = "C:\\hdd_ext\\PACS\\DACOM\\ConsoleDicom\\ConsoleDicom\\bin\\Debug\\a.dcm";

            DicomDecoder dd = new DicomDecoder();
            ImagePanelControl imagePanelControl = new ImagePanelControl();
            
            //Dicom file Read
            if (!dd.DicomRead(Ffilename))
            {
                System.Console.WriteLine("Don't Read Dimcom");
            }

            //Tag Read
            List<string> str = dd.DicomTag();
            foreach (var words in str)
            {
                System.Console.WriteLine(words);
            }

            string pngname = "C:\\hdd_ext\\PACS\\DACOM\\ConsoleDicom\\ConsoleDicom\\bin\\Debug\\a.png";
            string jpegname = "C:\\hdd_ext\\PACS\\DACOM\\ConsoleDicom\\ConsoleDicom\\bin\\Debug\\a.jpeg";

            //Dicom image convert
            dd.DIProc(imagePanelControl);

            //Dicom convert png
            int rtn = imagePanelControl.SaveImage(pngname, "Png");
            if (rtn > 0) { System.Console.WriteLine("Don't save Png"); }
            //Dicom convert jpeg 
            rtn = imagePanelControl.SaveImage(jpegname, "Jpeg");
            if (rtn > 0) { System.Console.WriteLine("Don't save Jpeg"); }

            Console.ReadKey();

        }
    }
}
