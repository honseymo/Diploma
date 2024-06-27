using Doc_Builder.ClassesForGenerate;
using Doc_Builder.Core;
using Doc_Builder.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Doc_Builder.View
{
    /// <summary>
    /// Логика взаимодействия для DiscoveryView.xaml
    /// </summary>
    public partial class DiscoveryView : UserControl
    {
       
        public DiscoveryView()
        {

            InitializeComponent();
            



            User10_Sgr1Entities conn = new User10_Sgr1Entities();
            List<string> types = new List<string>();
            listView.ItemsSource = conn.Mil_Templates.ToList();
            List<Mil_Type> type = conn.Mil_Type.ToList();
           
            var list = new List<string>();
            foreach (Mil_Type item in type)
            {
                TreeViewItem tritem = new TreeViewItem();
                tritem.Tag = item.Name;
                tritem.Header = item.Name.ToString();
               List<Mil_Templates> templates =  conn.Mil_Templates.Where(C => C.TypeName == item.Name).ToList();
                //list.Add(item.Name);
                foreach(Mil_Templates template in templates)
                {
                    tritem.Items.Add(template.Header);
                }
                treeView.Items.Add(tritem);
            }
            

           
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            User10_Sgr1Entities conn = new User10_Sgr1Entities();
              if(treeView.SelectedItem.GetType().ToString()== "System.Windows.Controls.TreeViewItem")
              {
                TreeViewItem selectedTreeViewItem = treeView.SelectedItem as TreeViewItem;
                string groupName = selectedTreeViewItem.Header.ToString();
                List<Mil_Templates> templates = conn.Mil_Templates.Where(C => C.TypeName == groupName).ToList();
                listView.ItemsSource = templates.ToList();
            }
              else
             {
                 listView.ItemsSource = conn.Mil_Templates.Where(C => C.Header == treeView.SelectedItem.ToString()).ToList();
             }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WordViewCommand logoutVM = new WordViewCommand();
            User10_Sgr1Entities conn = new User10_Sgr1Entities();
            if (listView.SelectedItem!=null)
            {
                var selectedListItem = (Mil_Templates)listView.SelectedItem;


                string selectedName = selectedListItem.Header;

                Mil_Templates templates = conn.Mil_Templates.FirstOrDefault(c=>c.ID==selectedListItem.ID);
                if(templates.FieldData!=null)
                {
                    var window = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.DataContext is MainViewModel);
                    if (window != null)
                    {
                       // SharedData shar_ = new SharedData();
                        // Получаем DataContext окна
                        var mainViewModel = (window.DataContext as MainViewModel);
                        GlobalVariables.SharedData = selectedListItem.ID;
                        //shar_.Data = CselectedListItem.ID;
                        // Выполняем команду с нужным параметром
                        mainViewModel.ChangeViewCommand.Execute("Word");
                    }
                    
                }
                else
                {
                    DocumentGeneration document_form = new DocumentGeneration(selectedName);
                    document_form.ShowDialog();
                }
               
            }
            else
            {
                MessageBox.Show("Выберите шаблон для создания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
