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

namespace Doc_Builder.View
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://asiec.ru");
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/honseymo");
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            try { System.Diagnostics.Process.Start("Spravk_Miller.pdf"); }
            catch(Exception ex)
            {
                MessageBox.Show("Файл спраки не найден");
            }
            
        }
    }
}
