using Doc_Builder.ClassesForGenerate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace Doc_Builder
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
                throw new ArgumentException("File not found");
            }
        }

        internal bool Process(Dictionary<string, string> items, string _type, string _fullName)
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
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }
                // _fileInfo.DirectoryName
                string executablePath = AppDomain.CurrentDomain.BaseDirectory; // Получаем путь к исполняемому файлу
                string readyDocumentsPath = Path.Combine(executablePath, "ReadyDocuments"); // Создаем путь к папке "ReadyDocuments"

                if (!Directory.Exists(readyDocumentsPath))
                {
                    Directory.CreateDirectory(readyDocumentsPath); // Создаем папку, если она не существует
                }
                Object newFileName = Path.Combine(readyDocumentsPath, DateTime.Now.ToString("yyyyMMdd HHmmss") + _fileInfo.Name);
                var request = new RequestWord();
                request.Process(_type, Path.Combine(readyDocumentsPath, newFileName.ToString()), _fullName);
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
                app.Quit();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                if (app != null)
                    app.Quit();
            }
            return false;
        }
    }
}
