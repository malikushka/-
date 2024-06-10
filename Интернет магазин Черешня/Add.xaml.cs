using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Интернет_магазин_Черешня
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        string connectionString = "Data Source=WIN-3HCRIBMUHPD\\MALIKA;Initial Catalog=db;Integrated Security=True;MultipleActiveResultSets=True";
        public Add()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
        }
        public void AddProduct(int Id, string surname, string name, string otchestvo, string commission)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Realtor WHERE ID = @ID";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@ID", Id);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Риелтор с таким Id уже существует");
                }
                else
                {
                    string query = "INSERT INTO Realtor (ID, Surname, Name, Otchestvo, Commission) " +
                                   "VALUES (@ID, @Surname, @Name, @Otchestvo, @Commission)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID",Id);
                    command.Parameters.AddWithValue("@Surname",surname);
                    command.Parameters.AddWithValue("@Name",name);
                    command.Parameters.AddWithValue("@Otchestvo",otchestvo);
                    command.Parameters.AddWithValue("@Commission",commission);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Риелтор успешно добавлена");
                        Close(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении риелтора: " + ex.Message);
                    }
                }
            }
        }
        
        private void Id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }


            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length >= 3 && e.Text.Length > 0)
            {
                e.Handled = true;
            }

        }

        private void Фамилия_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]+$"))
            {
                e.Handled = true; 
            }

        }

        private void Имя_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]+$"))
            {
                e.Handled = true;
            }


        }

        private void Отчество_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]+$"))
            {
                e.Handled = true;
            }

        }

        private void Комиссия_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; 
            }

            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length >= 15 && e.Text.Length > 0)
            {
                e.Handled = true; 
            }

        }
        private bool AreAllFieldsFilled()
        {
            if (string.IsNullOrEmpty(Id.Text) || string.IsNullOrEmpty(Фамилия.Text) || string.IsNullOrEmpty(Имя.Text)
                || string.IsNullOrEmpty(Отчество.Text) || string.IsNullOrEmpty(Комиссия.Text))
            {
                messageTextBlock.Text = "Все поля должны быть заполнены";
                return false;
            }
            return true;
        }

        private void NewProduct_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Id.Text, out int Idrealtor))
            {
                string surname = Фамилия.Text;
                string name = Имя.Text;
                string otchestvo = Отчество.Text;
                string сommission = Комиссия.Text;

                AddProduct(Idrealtor, surname, name, otchestvo, сommission);
                Id.Text = "";
                Фамилия.Text = "";
                Имя.Text = "";
                Отчество.Text = "";
                Комиссия.Text = "";
            }
            else
            {
                messageTextBlock.Text = "Пожалуйста, введите корректные данные для добавления риелтора.";
            }

        }
    }
}
