
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Интернет_магазин_Черешня
{
    public partial class Информация_о_товарах : Window
    {
        public List<Client> ClientList { get; set; }
        //public static АдминистраторEntities3 администраторEntities = new АдминистраторEntities3();
        private ТоварыViewModel viewModel;
        public Информация_о_товарах()
        {
            InitializeComponent();
            ClientList = GetClothingData();
            DataContext = this;
            this.WindowState = WindowState.Maximized;
            // viewModel = new ТоварыViewModel();
            //this.DataContext = viewModel;
        }
        private List<Client> GetClothingData()
        {
            List<Client> realtorList = new List<Client>();

            using (var context = new dbEntities())
            {

                var realtorEntities = context.Client.ToList();

                foreach (var clothingEntity in realtorEntities)
                {
                    Client clothing = new Client
                    {
                        ID = clothingEntity.ID,
                        Surname = clothingEntity.Surname,
                        Name = clothingEntity.Name,
                        Otchestvo = clothingEntity.Otchestvo,
                        Telephone = clothingEntity.Telephone,
                        Email = clothingEntity.Email

                    };


                    realtorList.Add(clothing);
                }
            }

            return realtorList;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Информация_о_пользователях информация_о_Пользователях = new Информация_о_пользователях();
            информация_о_Пользователях.WindowState = WindowState.Maximized;
            информация_о_Пользователях.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Информация_о_заказах информация_о_Заказах = new Информация_о_заказах();
            информация_о_Заказах.WindowState = WindowState.Maximized;
            информация_о_Заказах.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Пункт_выдачи пункт_Выдачи = new Пункт_выдачи();
            пункт_Выдачи.WindowState = WindowState.Maximized;
            пункт_Выдачи.Show();
            this.Close();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (viewModel == null)
            {
                viewModel = new ТоварыViewModel();
            }

            string searchTerm = SearchText.Text;
            Client foundClient = viewModel.FindUserByNomber(searchTerm);
            if (foundClient != null)
            {
                HighlightUserFields(foundClient);
                ErrorMessageLabel1.Content = $"Клиент {foundClient.Surname} {foundClient.Name} {foundClient.Otchestvo} найден";

            }
            else
            {
                ClearUserFieldHighlight();
                ErrorMessageLabel1.Content = "Клиент не найден";
            }
        }
        private void HighlightUserFields(Client foundClient)
        {
            for (int i = 0; i < viewModel.ВсеКлиенты.Count; i++)
            {
                TextBlock productTextBox = FindName($"PRODUCTTextBox{i}") as TextBlock;
                if (productTextBox != null)
                {
                    if (viewModel.ВсеКлиенты[i].Equals(foundClient))
                    {
                        productTextBox.Background = new SolidColorBrush(Colors.LightGreen);
                    }
                    else
                    {
                        productTextBox.ClearValue(BackgroundProperty);
                    }
                }
            }
        }
        private void ClearUserFieldHighlight()
        {
            for (int i = 0; i < viewModel.ВсеКлиенты.Count; i++)
            {
                TextBox productTextBox = FindName($"PRODUCTTextBox{i}") as TextBox;
                if (productTextBox != null)
                {
                    productTextBox.ClearValue(BackgroundProperty);
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Adding addWindow = new Adding();
            addWindow.Show();


        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int productId;
            if (!int.TryParse(RealtorId.Text, out productId))
            {
                MessageBox.Show("Введите корректный ID клиента");
                return;
            }
            using (var context = new dbEntities())
            {
                var productToChange = context.Client.FirstOrDefault(p => p.ID == productId);
                if (productToChange != null)
                {
                    Changing changeWindow = new Changing (productToChange);
                    changeWindow.Show();
                }
                else
                {
                    MessageBox.Show("Клиент с указанным ID не найден");
                }
            }

        }
        public void DeleteProduct(int productId)
        {
            using (var context = new dbEntities())
            {
                var productToDelete = context.Client.FirstOrDefault(p => p.ID == productId);
                if (productToDelete != null)
                {
                    context.Client.Remove(productToDelete);
                    context.SaveChanges();
                }
            }
        }

        public void Delite(int productId)
        {
            using (var context = new dbEntities())
            {

                var productToDelete = context.Client.FirstOrDefault(p => p.ID == productId);
                if (productToDelete != null)
                {

                    context.Client.Remove(productToDelete);
                    context.SaveChanges();
                    MessageBox.Show("Клиент успешно удален");
                }
                else
                {
                    MessageBox.Show("Клиент с указанным ID не найден");
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RealtorId.Text, out int productId))
            {
                MessageBox.Show("Введите корректный ID клиента");
                return;
            }
            Delite(productId);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Информация_о_товарах adminWindow = new Информация_о_товарах();
            adminWindow.Show();
            this.Close();

        }

        private void RealtorId_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
