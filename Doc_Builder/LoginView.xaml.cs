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
using System.Windows.Shapes;

namespace Doc_Builder
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private async void SomeMethod()
        {
            await Task.Delay(TimeSpan.FromSeconds(1.7));
            this.Show();
        }
        public LoginView()
        {
            
            SplashScreen splash = new SplashScreen("/Images/VfUI.gif");
            splash.Show(true);
            splash.Close(TimeSpan.FromSeconds(2));

            this.Hide();
            InitializeComponent();

            SomeMethod();





        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User10_Sgr1Entities conn = new User10_Sgr1Entities();

            Mil_UsersDoc select = conn.Mil_UsersDoc.Where(c => c.login == txtUser.Text && c.password == txtPass.Password).FirstOrDefault();
            if (String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtPass.Password))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (select != null)
            {
                if (txtUser.Text == select.login && txtPass.Password == select.password)
                {
                    this.Hide();
                    MainWindow window2 = new MainWindow();
                    window2.ShowDialog();
                }

            }
            else MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }



     
    }
}
