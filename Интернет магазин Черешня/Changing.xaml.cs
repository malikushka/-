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

namespace Интернет_магазин_Черешня
{
    /// <summary>
    /// Логика взаимодействия для Changing.xaml
    /// </summary>
    public partial class Changing : Window
    {
        private Client productToChange;
        public Changing(Client selectedProduct)
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            productToChange = selectedProduct;
            FillDataFields();
        }
        private void FillDataFields()
        {
            Id.Text = productToChange.ID.ToString();
            Фамилия.Text = productToChange.Surname;
            Имя.Text = productToChange.Name;
            Отчество.Text = productToChange.Otchestvo;
            Телефон.Text = productToChange.Telephone.ToString();
            Email.Text = productToChange.Email;
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

        private void Телефон_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }

            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length >= 30 && e.Text.Length > 0)
            {
                e.Handled = true;
            }
        }

        private void Email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length >= 40 && e.Text.Length > 0)
            {
                e.Handled = true;
            }

        }

        private void NewClient_Click(object sender, RoutedEventArgs e)
        {
            if (!AreAllFieldsFilled())
            {
                messageTextBlock.Text = "Заполните все поля.";
                return;
            }

            int newId;
            int tele;
            bool isIdValid = int.TryParse(Id.Text, out newId);
            bool isTeleValid = int.TryParse(Телефон.Text, out tele);

            if (!isIdValid || !isTeleValid)
            {
                if (!isIdValid)
                {
                    messageTextBlock.Text = "Введите корректный ID клиента.";
                }
                else if (!isTeleValid)
                {
                    messageTextBlock.Text = "Введите корректный номер телефона.";
                }
                return;
            }

            string surname = Фамилия.Text;
            string name = Имя.Text;
            string otchestvo = Отчество.Text;
            string email = Email.Text;

            using (var context = new dbEntities())
            {
                var productToUpdate = context.Client.FirstOrDefault(p => p.ID == productToChange.ID);
            
                if (productToUpdate != null)
                {
                    productToUpdate.ID = newId;
                    productToUpdate.Surname = surname;
                    productToUpdate.Name = name;
                    productToUpdate.Otchestvo = otchestvo;
                    productToUpdate.Telephone = tele; // Используем значение телефона, успешно проверенное ранее
                    productToUpdate.Email = email;

                    context.SaveChanges();
                    MessageBox.Show("Клиент успешно обновлён!");
                    Close();
                }
                else
                {
                    // Если productToUpdate == null, возможно, ID не найден, и нам нужно обработать этот случай
                    messageTextBlock.Text = "Клиент с указанным ID не найден.";
                    return;
                }
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
