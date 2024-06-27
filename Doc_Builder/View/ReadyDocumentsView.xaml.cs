using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Doc_Builder.View
{
    
    /// <summary>
    /// Логика взаимодействия для ReadyDocumentsView.xaml
    /// </summary>
    public partial class ReadyDocumentsView : UserControl
    {
        public class ReadyDocuments
        {
            public string _EmployerID { get; set; }
            public DateTime _Date { get; set; }
            public string _DocumentID { get; set; }
            public string _Path { get; set; }
        }
        int pageIndex = 1;
        private int numberOfRecPerPage;
        //To check the paging direction according to use selection.
        private enum PagingMode
        { First = 1, Next = 2, Previous = 3, Last = 4, PageCountChange = 5 };

        List<ReadyDocuments> myList = new List<ReadyDocuments>();
        public ReadyDocumentsView()
        {
             
            InitializeComponent();
            cbNumberOfRecords.Items.Add("10");
            cbNumberOfRecords.Items.Add("20");
            cbNumberOfRecords.Items.Add("30");
            cbNumberOfRecords.Items.Add("50");
            cbNumberOfRecords.Items.Add("100");
            cbNumberOfRecords.SelectedItem = 10;
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            User10_Sgr1Entities conn = new User10_Sgr1Entities();


            List<ReadyDocuments> documentIDs = new List<ReadyDocuments>();
            var listdoc = conn.Mil_ReadyDocuments.ToList();
            foreach (Mil_ReadyDocuments item in listdoc)
            {
                ReadyDocuments doc = new ReadyDocuments();
                MIL_Employees employer = conn.MIL_Employees.Where(c => c.ID == item.EmployerID).FirstOrDefault();
                if (employer!=null) { 
                    
                    doc._EmployerID = employer.FullName;
                }
                else
                {
                    doc._EmployerID = "—";
                }
                Mil_Templates template = conn.Mil_Templates.Where(c => c.ID == item.DocumentID).FirstOrDefault();
                
                doc._Date = Convert.ToDateTime(item.Date);
                doc._DocumentID = template.Header;
                doc._Path = item.Path;
                documentIDs.Add(doc);
            }


            myList = documentIDs.ToList();

            dataGrid.ItemsSource = myList.Take(numberOfRecPerPage);
            
            int count = myList.Take(numberOfRecPerPage).Count();
            lblpageInformation.Content = count + " of " + myList.Count;
        }


        private List<Mil_ReadyDocuments> GetData()
        {
           User10_Sgr1Entities conn = new User10_Sgr1Entities();
            List<Mil_ReadyDocuments> genericList = conn.Mil_ReadyDocuments.ToList();
            return genericList;
        }


        #region Pagination 
        private void btnFirst_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.First);
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Next);

        }

        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Previous);

        }

        private void btnLast_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Last);
        }

        private void cbNumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigate((int)PagingMode.PageCountChange);
        }

        private void Navigate(int mode)
        {
            int count;
            switch (mode)
            {
                case (int)PagingMode.Next:
                    btnPrev.IsEnabled = true;
                    btnFirst.IsEnabled = true;
                    if (myList.Count >= (pageIndex * numberOfRecPerPage))
                    {
                        if (myList.Skip(pageIndex *
                        numberOfRecPerPage).Take(numberOfRecPerPage).Count() == 0)
                        {
                            dataGrid.ItemsSource = null;
                            dataGrid.ItemsSource = myList.Skip((pageIndex *
                            numberOfRecPerPage) - numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = (pageIndex * numberOfRecPerPage) +
                            (myList.Skip(pageIndex *
                            numberOfRecPerPage).Take(numberOfRecPerPage)).Count();
                        }
                        else
                        {
                            dataGrid.ItemsSource = null;
                            dataGrid.ItemsSource = myList.Skip(pageIndex *
                            numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = (pageIndex * numberOfRecPerPage) +
                            (myList.Skip(pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage)).Count();
                            pageIndex++;
                        }

                        lblpageInformation.Content = count + " of " + myList.Count;
                    }

                    else
                    {
                        btnNext.IsEnabled = false;
                        btnLast.IsEnabled = false;
                    }

                    break;
                case (int)PagingMode.Previous:
                    btnNext.IsEnabled = true;
                    btnLast.IsEnabled = true;
                    if (pageIndex > 1)
                    {
                        pageIndex -= 1;
                        dataGrid.ItemsSource = null;
                        if (pageIndex == 1)
                        {
                            dataGrid.ItemsSource = myList.Take(numberOfRecPerPage);
                            count = myList.Take(numberOfRecPerPage).Count();
                            lblpageInformation.Content = count + " of " + myList.Count;
                        }
                        else
                        {
                            dataGrid.ItemsSource = myList.Skip
                            (pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = Math.Min(pageIndex * numberOfRecPerPage, myList.Count);
                            lblpageInformation.Content = count + " of " + myList.Count;
                        }
                    }
                    else
                    {
                        btnPrev.IsEnabled = false;
                        btnFirst.IsEnabled = false;
                    }
                    break;

                case (int)PagingMode.First:
                    pageIndex = 2;
                    Navigate((int)PagingMode.Previous);
                    break;
                case (int)PagingMode.Last:
                    pageIndex = (myList.Count / numberOfRecPerPage);
                    Navigate((int)PagingMode.Next);
                    break;

                case (int)PagingMode.PageCountChange:
                    pageIndex = 1;
                    numberOfRecPerPage = Convert.ToInt32(cbNumberOfRecords.SelectedItem);
                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = myList.Take(numberOfRecPerPage);
                    count = (myList.Take(numberOfRecPerPage)).Count();
                    lblpageInformation.Content = count + " of " + myList.Count;
                    btnNext.IsEnabled = true;
                    btnLast.IsEnabled = true;
                    btnPrev.IsEnabled = true;
                    btnFirst.IsEnabled = true;
                    break;
            }
        }

        #endregion

       

        private void ViewClick(object sender, RoutedEventArgs e)
        {
              if(dataGrid.SelectedItem!=null) { 
                ReadyDocuments doc = new ReadyDocuments();
                doc = (ReadyDocuments)dataGrid.SelectedItem;
                TemplateView tvform = new TemplateView(doc._Path);
                tvform.ShowDialog();
                }
              else
                MessageBox.Show("Выберите шаблон для просмотра", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid.SelectedItem != null) {
                try
                {
                    ReadyDocuments doc = new ReadyDocuments();
                    doc = (ReadyDocuments)dataGrid.SelectedItem;
                    System.Diagnostics.Process.Start(doc._Path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка, файл не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Нет элементов или не выбран документ", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {

            if (dataGrid.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Внимание!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    try
                    {
                        User10_Sgr1Entities conn = new User10_Sgr1Entities();
                        ReadyDocuments doc = new ReadyDocuments();
                        doc = (ReadyDocuments)dataGrid.SelectedItem;
                        string filePath = doc._Path;

                        try
                        {
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                                Mil_ReadyDocuments select = conn.Mil_ReadyDocuments.Where(c => c.Path == doc._Path).FirstOrDefault();
                                conn.Mil_ReadyDocuments.Remove(select);
                                conn.SaveChanges();
                                MessageBox.Show("Файл успешно удален.");
                            }
                            else
                            {
                                MessageBox.Show("Файл не найден. ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при удалении файла:  " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка, файл не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет элементов или не выбран документ", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
