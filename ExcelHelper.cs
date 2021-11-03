using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;

namespace РасчетКУ
{
    class ExcelHelper : IDisposable //Пока что большая часть из этого - шняга
    {
        private Excel.Application _excel;
        private Excel.Workbook _workbook;
        private string _filePath;
        private FileInfo _fileInfo;
        private XLWorkbook xlWorkbook;
        
        public ExcelHelper(string fileName)
        {
            //_excel = new Excel.Application();
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);

            }
            else
            {
                throw new ArgumentException("not found");
            }
        }

        internal bool Process(Dictionary<string, string> items)
        {
            Excel.Application app = null;
            try
            {
                app = new Application();
                string file = _fileInfo.FullName;
                Object missing = Type.Missing;

                app.Workbooks.Open(file);

                foreach (var item in items)
                {
                    //Excel.Find find = app.Selection.Find;
                   // find.Text = item.Key;
                   // find.Replacement.Text = item.Value;

                    //Object wrap = Excel. //WdFindWrap.wdFindContinue;
                    //Object replace = Excel. //WdReplace.wdReplaceAll;

                   // xlWorkbook = app.Workbooks.Open(_filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                   // xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                   // _Worksheet.Cells.Replace("SENDER_NAME", "FEDEX", missingValue, missingValue, missingValue, missingValue, missingValue, missingValue);

                    /*find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchSoundsLike: missing,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing,
                        Replace: replace);*/

                }

                app.Visible = true;

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                if (app != null)
                    app.Visible = true;

            }
            return false;
        }


        public void Dispose()
        {
            try
            {
                _workbook.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            _excel.Quit();
        }

        
    }
}