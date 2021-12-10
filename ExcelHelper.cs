using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

//using ClosedXML.Excel;

namespace РасчетКУ
{
    class ExcelHelper : IDisposable 
    {
        private Excel.Application _excel;
        private Excel.Workbook _workbook;
        private Excel.Worksheet _worksheet;
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

        internal bool Process(Dictionary<string, string> items, System.Data.DataTable Table)
        {
            Excel.Application app = null;
            try
            {
                app = new Excel.Application();
                string file = _fileInfo.FullName;
                Object missing = Type.Missing;
                
                app.Workbooks.Open(file);
                //_worksheet = _workbook.ActiveSheet as Excel.Worksheet;

                //Табличная часть
                Excel.Range findTxt = app.Cells.Find("<Table>", Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart);
                //app.Range[findTxt.Address].Value = "aa";
                Excel.Range range = findTxt.EntireRow;

                // Excel.Range range1 = findTxt.EntireRow.Count;

                 if (findTxt != null)
                 {

                     //MessageBox.Show("Текст найден в ячейке: " + findTxt.Address, "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     findTxt.Select();
                 }
                 //else
                 //{
                    // MessageBox.Show("Текст  не найден!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 //}
                //

                foreach (var item in items)
                {

                    app.Cells.Replace(item.Key, item.Value, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByColumns, MatchCase: false, SearchFormat: false, ReplaceFormat: false);
                    app.Visible = true;                

                }
                
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    
                    for (int j = 0; j < 6; j++)
                    {

                        app.Range[Convert.ToChar(Convert.ToByte(65 + j)) + "11"].Value = Table.Rows[i][j];
                    }
                    for (int j = 6; j < 8; j++)
                    {
                        // 2 часть табличной хрени
                        app.Range[Convert.ToChar(Convert.ToByte(81 + j - 6)) + "11"].Value = Table.Rows[i][j];
                    }
                    // добавление строки
                   
                    range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
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