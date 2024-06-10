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
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Window
    {
        private Realtor productToChange;
        public Change(Realtor selectedProduct)
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
            Комиссия.Text = productToChange.Commission;
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
            if (textBox.Text.Length >= 5 && e.Text.Length > 0)
            {
                e.Handled = true;
            }

        }

        private void NewRealtor_Click(object sender, RoutedEventArgs e)
        {
           
            if (!AreAllFieldsFilled())
            {
                return;
            }
            int newId;
            if (!int.TryParse(Id.Text, out newId))
            {
                messageTextBlock.Text = "Введите корректный ID товара";
                return;
            }
            string surname = Фамилия.Text;
            string name = Имя.Text;
            string otchestvo = Отчество.Text;
            string сommission = Комиссия.Text;

            
            using (var context = new dbEntities())
            {
                var productToUpdate = context.Realtor.FirstOrDefault(p => p.ID == productToChange.ID);
                if (productToUpdate != null)
                {
                    productToUpdate.ID = newId;
                    productToUpdate.Surname = surname;
                    productToUpdate.Name = name;
                    productToUpdate.Otchestvo = otchestvo;
                    productToUpdate.Commission = сommission;

                    context.SaveChanges();
                    MessageBox.Show("Товар успешно изменён!");
                    Close();
                }
            }

        }
    }
}
