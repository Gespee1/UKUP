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
        //private Excel.Workbook _workbook;
        //private Excel.Worksheet _worksheet;
        //private string _filePath;
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
            //Excel.Application app = null;
            try
            {
                _excel = new Excel.Application();
                string file = _fileInfo.FullName;
                Object missing = Type.Missing;

                _excel.Workbooks.Open(file);
                

                //Табличная часть
                Excel.Range findTxt = _excel.Cells.Find("<Table>", Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart);
                Excel.Range range = findTxt.EntireRow;              

                 if (findTxt != null)
                 {

                     //MessageBox.Show("Текст найден в ячейке: " + findTxt.Address, "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     findTxt.Select();
                 }
                 
                //замена маркеров
                foreach (var item in items)
                {

                    _excel.Cells.Replace(item.Key, item.Value, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByColumns, MatchCase: false, SearchFormat: false, ReplaceFormat: false);
                                   

                }
                
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    
                    for (int j = 0; j < 6; j++)
                    {
                        _excel.Range[Convert.ToChar(Convert.ToByte(65 + j)) + "11"].Value = Table.Rows[i][j];
                    }
                    for (int j = 6; j < 8; j++)
                    {
                        // 2 часть табличной хрени
                        _excel.Range[Convert.ToChar(Convert.ToByte(81 + j - 6)) + "11"].Value = Table.Rows[i][j];
                    }
                    // добавление строки
                    if (i != Table.Rows.Count - 1)
                    {
                        range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
                    }
                    range = _excel.Range[Convert.ToChar(Convert.ToByte(65)) + "11"].EntireRow; //возвращаем выделение на А11
                }


                
                _excel.Visible = true;

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                if (_excel != null)
                    _excel.Visible = true;

            }
            return false;
        }

        internal bool Process2(Dictionary<string, string> items, System.Data.DataTable Table)
        {
            //Excel.Application app = null;
            try
            {
                _excel = new Excel.Application();
                string file = _fileInfo.FullName;
                Object missing = Type.Missing;

                _excel.Workbooks.Open(file);


                //Табличная часть
                Excel.Range findTxt = _excel.Cells.Find("<Table>", Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart);
                Excel.Range range = findTxt.EntireRow;

                if (findTxt != null)
                {

                    //MessageBox.Show("Текст найден в ячейке: " + findTxt.Address, "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    findTxt.Select();
                }
             
                //замена маркеров
                foreach (var item in items)
                {

                    _excel.Cells.Replace(item.Key, item.Value, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByColumns, MatchCase: false, SearchFormat: false, ReplaceFormat: false);
                    

                }

                for (int i = 0; i < Table.Rows.Count; i++)
                {

                    for (int j = 0; j < 5; j++)
                    {
                        _excel.Range[Convert.ToChar(Convert.ToByte(65 + j)) + "10"].Value = Table.Rows[i][j];
                    }
                    for (int j = 5; j < 7; j++)
                    {
                        // 2 часть табличной хрени
                        _excel.Range[Convert.ToChar(Convert.ToByte(79 + j - 4)) + "10"].Value = Table.Rows[i][j];
                    }
                    // добавление строки
                    if (i != Table.Rows.Count - 1)
                    {
                        range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
                    }
                    range = _excel.Range[Convert.ToChar(Convert.ToByte(65)) + "10"].EntireRow; //возвращаем выделение на А10
                }



                _excel.Visible = true;

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                if (_excel != null)
                    _excel.Visible = true;

            }
            return false;
        }

        public void Dispose()
        {
            try
            {
                _excel.Quit();
                //_workbook.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            
        }

        
    }
}