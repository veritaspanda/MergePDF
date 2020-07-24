using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MergePDF
{
    class Program
    {
        static void Main(string[] args)
        {
            MergePDF(@"C:\TEMP\PDF1.pdf", @"C:\TEMP\PDF2.pdf", @"C:\TEMP\PDF3.pdf", @"C:\TEMP\PDF4.pdf", @"C:\TEMP\PDF5.pdf", @"C:\TEMP\PDF6.pdf");
        }

        private static void MergePDF(string File1, string File2, string File3 = null, string File4 = null, string File5 = null, string File6 = null, string File7 = null, string File8 = null, string File9 = null, string File10 = null)
        {
            int _fileCount = 1;

            if(isFileValid(File1))
            {
                _fileCount++;
            }

            if (isFileValid(File2))
            {
                _fileCount++;
            }

            if (isFileValid(File3))
            {
                _fileCount++;
            }

            if (isFileValid(File4))
            {
                _fileCount++;
            }

            if (isFileValid(File5))
            {
                _fileCount++;
            }

            if (isFileValid(File6))
            {
                _fileCount++;
            }

            if (isFileValid(File7))
            {
                _fileCount++;
            }

            if (isFileValid(File8))
            {
                _fileCount++;
            }

            if (isFileValid(File9))
            {
                _fileCount++;
            }

            if (isFileValid(File10))
            {
                _fileCount++;
            }

            string[] _tempFileArray = new string[10];
            _tempFileArray[0] = File1;
            _tempFileArray[1] = File2;
            _tempFileArray[2] = File3;
            _tempFileArray[3] = File4;
            _tempFileArray[4] = File5;
            _tempFileArray[5] = File6;
            _tempFileArray[6] = File7;
            _tempFileArray[7] = File8;
            _tempFileArray[8] = File9;
            _tempFileArray[9] = File10;


            string[] fileArray = new string[_fileCount]; //should be files + 1

            for(int i = 0; i < fileArray.Length - 1; i++)
            {
                fileArray[i] = _tempFileArray[i];
            }

            //fileArray[0] = File1;
            //fileArray[1] = File2;
            //fileArray[3] = File3;
            //fileArray[4] = File4;
            //fileArray[5] = File5;
            //fileArray[6] = File6;
            //fileArray[7] = File7;
            //fileArray[8] = File8;
            //fileArray[9] = File9;
            //fileArray[10] = File10;

            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = @"C:\TEMP\mergedPdf.pdf";

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //output file Open  
            sourceDocument.Open();


            //files list wise Loop  
            for (int f = 0; f < fileArray.Length - 1; f++)
            {
                int pages = TotalPageCount(fileArray[f]);

                reader = new PdfReader(fileArray[f]);
                //Add pages in new file  
                for (int i = 1; i <= pages; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }

                reader.Close();
            }
            //save the output file  
            sourceDocument.Close();
        }

        private static int TotalPageCount(string file)
        {
            if (isFileValid(file))
            {
                using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(file)))
                {
                    Regex regex = new Regex(@"/Type\s*/Page[^s]");
                    MatchCollection matches = regex.Matches(sr.ReadToEnd());

                    return matches.Count;
                }
            }
            else
            {
                return 0;
            }
        }

        private static bool isFileValid(string _fileName)
        {
            bool _isValid = false;

            if (_fileName != null && _fileName != "" && _fileName != string.Empty && _fileName.ToUpper().EndsWith(".PDF"))
            {
                _isValid = true;
            }

            return _isValid;
        }


        //iText7 attempt below


        //private static void MergePDF(string File1, string File2)
        //{
        //    string[] fileArray = new string[3];
        //    fileArray[0] = File1;
        //    fileArray[1] = File2;

        //    PdfReader reader = null;
        //    Document sourceDocument = null;
        //    PdfCopy pdfCopyProvider = null;
        //    PdfImportedPage importedPage;
        //    string outputPdfPath = @"E:/newFile.pdf";
        //    PdfReader fileToRead = new PdfReader("");
        //    PdfDocument inputFile = new PdfDocument(fileToRead);
        //    sourceDocument = new Document(inputFile);
        //    pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

        //    //output file Open  
        //    sourceDocument.Open();


        //    //files list wise Loop  
        //    for (int f = 0; f < fileArray.Length - 1; f++)
        //    {
        //        int pages = TotalPageCount(fileArray[f]);

        //        reader = new PdfReader(fileArray[f]);
        //        //Add pages in new file  
        //        for (int i = 1; i <= pages; i++)
        //        {
        //            importedPage = pdfCopyProvider.GetImportedPage(reader, i);
        //            pdfCopyProvider.AddPage(importedPage);
        //        }

        //        reader.Close();
        //    }
        //    //save the output file  
        //    sourceDocument.Close();
        //}

        //private static int TotalPageCount(string file)
        //{
        //    using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(file)))
        //    {
        //        Regex regex = new Regex(@"/Type\s*/Page[^s]");
        //        MatchCollection matches = regex.Matches(sr.ReadToEnd());

        //        return matches.Count;
        //    }
        //}
    }
}