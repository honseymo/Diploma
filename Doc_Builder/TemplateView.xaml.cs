using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using Application = Microsoft.Office.Interop.Word.Application;
using Word = Microsoft.Office.Interop.Word;

namespace Doc_Builder
{
    /// <summary>
    /// Логика взаимодействия для TemplateView.xaml
    /// </summary>
    public partial class TemplateView : System.Windows.Window
    {
        private string _path;
        public TemplateView(string path)
        {
            InitializeComponent();
            _path = path;
            Load();
        }

        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)

        {
            
            // Create a WordApplication and add Document to it

            Microsoft.Office.Interop.Word.Application

                wordApplication = new Microsoft.Office.Interop.Word.Application();

            wordApplication.Documents.Add(wordDocName);





            Document doc = wordApplication.ActiveDocument;


            try

            {

                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);
                wordApplication.Quit();


                XpsDocument xpsDoc = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);

                return xpsDoc;

            }

            catch (Exception exp)

            {

                string str = exp.Message;

            }

            return null;

        }


        private bool Load()
        {
            
                if (File.Exists(_path))
                {
                    SelectedFileTextBox.Text = _path;

                    string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(_path), "\\",
                        System.IO.Path.GetFileNameWithoutExtension(_path), ".xps");
               
                    documentViewer1.Document =
                        ConvertWordDocToXPSDoc(_path, newXPSDocumentName).GetFixedDocumentSequence();
                    return true;
               
                    
                }
                else
                {
                MessageBox.Show("Путь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
         
           

        }

    }
}
