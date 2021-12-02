﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

//using ClosedXML.Excel;

namespace РасчетКУ
{
    class ExcelHelper : IDisposable 
    {
        private Excel.Application _excel;
        private Excel.Workbook _workbook;
        private string _filePath;
        private FileInfo _fileInfo;
  
        
        public ExcelHelper(string fileName)
        {
            
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
                app = new Excel.Application();
                string file = _fileInfo.FullName;
                Object missing = Type.Missing;

                app.Workbooks.Open(file);

                foreach (var item in items)
                {

                    app.Cells.Replace(item.Key, item.Value, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByColumns, MatchCase: false, SearchFormat: false, ReplaceFormat: false);
                   // string str = app.Cells.Find(item.Key, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByColumns).Address["zalupa"];
                    app.Visible = true;
                    

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