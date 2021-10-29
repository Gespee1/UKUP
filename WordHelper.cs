using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using System.Configuration;

namespace РасчетКУ
{
    class WordHelper
    {
        private FileInfo _fileInfo;

        public WordHelper(string fileName)
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
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchSoundsLike: missing,
                        Forward:true,
                        Wrap:wrap,
                        Format:false,
                        ReplaceWith: missing,
                        Replace:replace);

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

    }
}
