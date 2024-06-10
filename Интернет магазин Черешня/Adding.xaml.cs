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
using System.Windows.Shapes;

namespace Интернет_магазин_Черешня
{
    /// <summary>
    /// Логика взаимодействия для Adding.xaml
    /// </summary>
    public partial class Adding : Window
    {
        string connectionString = "Data Source=WIN-3HCRIBMUHPD\\MALIKA;Initial Catalog=db;Integrated Security=True;MultipleActiveResultSets=True";
        public Adding()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
        }
        public void AddClient(int Id, string surname, string name, string otchestvo, int telephone, string email )
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Client WHERE ID = @ID";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@ID", Id);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Клиент с таким Id уже существует");
                }
                else
                {
                    string query = "INSERT INTO Client (ID, Surname, Name, Otchestvo, Telephone, Email) " +
                                   "VALUES (@ID, @Surname, @Name, @Otchestvo, @Telephone, @Email)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", Id);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Otchestvo", otchestvo);
                    command.Parameters.AddWithValue("@Telephone", telephone);
                    command.Parameters.AddWithValue("@Email", email);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Клиент успешно добавлена");
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении клиента: " + ex.Message);
                    }
                }
            }
        }
        private bool AreAllFieldsFilled()
        {
            if (string.IsNullOrEmpty(Id.Text) || string.IsNullOrEmpty(Фамилия.Text) || string.IsNullOrEmpty(Имя.Text)
                || string.IsNullOrEmpty(Отчество.Text) || string.IsNullOrEmpty(Телефон.Text) || string.IsNullOrEmpty(Email.Text))
            {
                messageTextBlock.Text = "Все поля должны быть заполнены";
                return false;
            }
            return true;
        }
        private void NewClient_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Id.Text, out int clothingId) && int.TryParse(Телефон.Text, out int telephone))
            {
                string surname = Фамилия.Text;
                string name = Имя.Text;
                string otchestvo = Отчество.Text;
                string email = Email.Text;

                AddClient(clothingId, surname, name, otchestvo, telephone, email);
                Id.Text = "";
                Фамилия.Text = "";
                Имя.Text = "";
                Отчество.Text = "";
                Телефон.Text = "";
                Email.Text = "";

            }
            else
            {
                messageTextBlock.Text = "Пожалуйста, введите корректные данные для добавления клиента.";
            }

        }

        private void Email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length >= 16 && e.Text.Length > 0)
            {
                e.Handled = true;
            }
        }

        private void Телефон_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }

            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length >= 11 && e.Text.Length > 0)
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

        private void Имя_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]+$"))
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
    }
}
