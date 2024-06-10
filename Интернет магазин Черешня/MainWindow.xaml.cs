
using System.Windows;

namespace Интернет_магазин_Черешня
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;  
            this.WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;

            if (CheckCredentials(login, password))
            {
                MessageBox.Show("Авторизация прошла успешно!");

                Информация_о_пользователях информация_о_Пользователях = new Информация_о_пользователях();
                информация_о_Пользователях.WindowState = WindowState.Maximized;
                информация_о_Пользователях.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Попробуйте еще раз.");
            }

        }
        private bool CheckCredentials(string login, string password)
        {
            return (login == "admin.ru" && password == "admin123");
        }
    }
}
