using Microsoft.Win32;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Интернет_магазин_Черешня
{
    public partial class Информация_о_пользователях : Window
    {
        public List<Риелтор> РиелторList { get; set; }
        //public static АдминистраторEntities3 администраторEntities = new АдминистраторEntities3();
        private MainView_Model viewModel;
        //private MainView_Model productToChange;
        public Информация_о_пользователях()
        {
            InitializeComponent();
            РиелторList = GetClothingData(); 
            DataContext = this;
             this.WindowState = WindowState.Maximized;

            //viewModel = new MainView_Model();
            //this.DataContext = viewModel;
            //MainView_Model model = new MainView_Model();
            //DataContext = new MainView_Model();
            //viewModel = new MainView_Model();


        }
        private List<Риелтор> GetClothingData()
        {
            List<Риелтор> realtorList = new List<Риелтор>();

            using (var context = new dbEntities()) 
            {
               
                var realtorEntities = context.Realtor.ToList(); 

                foreach (var clothingEntity in realtorEntities)
                {
                    Риелтор clothing = new Риелтор
                    {
                        ID = clothingEntity.ID,
                        Surname = clothingEntity.Surname,
                        Name = clothingEntity.Name,
                        Otchestvo = clothingEntity.Otchestvo, 
                        Commission = clothingEntity.Commission
                    };
                    

                    realtorList.Add(clothing);
                }
            }

            return realtorList;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Информация_о_товарах информация_о_Товарах = new Информация_о_товарах();
            информация_о_Товарах.WindowState = WindowState.Maximized;
            информация_о_Товарах.Show();
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
       
        //
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (viewModel == null)
            {
                viewModel = new MainView_Model();
            }

            string searchTerm = SearchText.Text;
            Realtor foundUser = viewModel.FindUserByFIO(searchTerm);
            if (foundUser != null)
            {
                HighlightUserFields(foundUser);
                ErrorMessageLabel.Content = $"Пользователь {foundUser.Surname} {foundUser.Name} {foundUser.Otchestvo} найден";

            }
            else
            {
                ClearUserFieldHighlight();
                ErrorMessageLabel.Content = "Пользователь не найден";
            }
        }

        private void HighlightUserFields(Realtor foundUser)
        {
            //DataTemplate fioCellTemplate = (dataGrid.Columns[0] as DataGridTemplateColumn)?.CellTemplate;
            //if (fioCellTemplate != null)
            //{
            //    FrameworkElement fioContent = LogicalTreeHelper.FindLogicalNode(fioCellTemplate.LoadContent(), "Фамилия") as FrameworkElement;
            //    if (fioContent != null)
            //    {
            //        TextBlock fioGrid_Фамилия = fioContent.FindName("Фамилия") as TextBlock;
            //        TextBlock fioGrid_Имя = fioContent.FindName("Имя") as TextBlock;
            //        TextBlock fioGrid_Отчество = fioContent.FindName("Отчество") as TextBlock;
            //        TextBlock fioGrid_Комиссия = fioContent.FindName("Комиссия") as TextBlock;

            //        if (fioGrid_Фамилия != null && fioGrid_Имя != null && fioGrid_Отчество != null)
            //        {
            //            fioGrid_Фамилия.Background = new SolidColorBrush(Colors.LightGreen);
            //            fioGrid_Имя.Background = new SolidColorBrush(Colors.LightGreen);
            //            fioGrid_Отчество.Background = new SolidColorBrush(Colors.LightGreen);
            //            fioGrid_Комиссия.Background = new SolidColorBrush(Colors.LightGreen);
            //        }
            //    }
            //}
            //DataTemplate surnameCellTemplate = (dataGrid.Columns[1] as DataGridTemplateColumn)?.CellTemplate;
            //DataTemplate nameCellTemplate = (dataGrid.Columns[2] as DataGridTemplateColumn)?.CellTemplate;
            //DataTemplate otchestvoCellTemplate = (dataGrid.Columns[3] as DataGridTemplateColumn)?.CellTemplate;
            //DataTemplate commissionCellTemplate = (dataGrid.Columns[4] as DataGridTemplateColumn)?.CellTemplate;
            //if (surnameCellTemplate != null && nameCellTemplate != null && otchestvoCellTemplate != null && commissionCellTemplate != null)
            //{
            //    FrameworkElement surnameContent = LogicalTreeHelper.FindLogicalNode(surnameCellTemplate.LoadContent(), "Фамилия") as FrameworkElement;
            //    FrameworkElement nameContent = LogicalTreeHelper.FindLogicalNode(nameCellTemplate.LoadContent(), "Имя") as FrameworkElement;
            //    FrameworkElement otchestvoContent = LogicalTreeHelper.FindLogicalNode(otchestvoCellTemplate.LoadContent(), "Отчество") as FrameworkElement;
            //    FrameworkElement commissionContent = LogicalTreeHelper.FindLogicalNode(commissionCellTemplate.LoadContent(), "Комиссия") as FrameworkElement;

            TextBlock surnameGrid_Фамилия = FindName("Фамилия") as TextBlock;
            TextBlock nameGrid_Имя = FindName("Имя") as TextBlock;
            TextBlock otchestvoGrid_Отчество = FindName("Отчество") as TextBlock;
            TextBlock commissionGrid_Комиссия = FindName("Комиссия") as TextBlock;

            if (surnameGrid_Фамилия != null && nameGrid_Имя != null && otchestvoGrid_Отчество != null && commissionGrid_Комиссия != null)
            {
                surnameGrid_Фамилия.Background = new SolidColorBrush(Colors.LightGreen);
                nameGrid_Имя.Background = new SolidColorBrush(Colors.LightGreen);
                otchestvoGrid_Отчество.Background = new SolidColorBrush(Colors.LightGreen);
                commissionGrid_Комиссия.Background = new SolidColorBrush(Colors.LightGreen);
            }
        


        //var columnFio = dataGrid.Columns[0] as DataGridTemplateColumn;
        //var columnName = dataGrid.Columns[1] as DataGridTemplateColumn;
        //var columnOtchestvo = dataGrid.Columns[2] as DataGridTemplateColumn;
        //var columnCommission = dataGrid.Columns[3] as DataGridTemplateColumn;
        //if (columnFio != null && columnName != null && columnOtchestvo != null && columnCommission != null)
        //{
        //    var fioCellTemplate = columnFio.CellTemplate as DataTemplate;
        //    var nameCellTemplate = columnName.CellTemplate as DataTemplate;
        //    var otchestvoCellTemplate = columnOtchestvo.CellTemplate as DataTemplate;
        //    var commissionCellTemplate = columnCommission.CellTemplate as DataTemplate;
        //    if (fioCellTemplate != null && nameCellTemplate != null && otchestvoCellTemplate != null && commissionCellTemplate != null)
        //    {
        //        var fioGrid = fioCellTemplate.FindName("Фамилия", foundUser) as TextBlock;
        //        var nameGrid = nameCellTemplate.FindName("Имя", foundUser) as TextBlock;
        //        var otchestvoGrid = otchestvoCellTemplate.FindName("Отчество", foundUser) as TextBlock;
        //        var commissionGrid = commissionCellTemplate.FindName("Комиссия", foundUser) as TextBlock;
        //        if (fioGrid != null && nameGrid != null && otchestvoGrid != null)
        //        {
        //            fioGrid.Background = new SolidColorBrush(Colors.LightGreen);
        //            nameGrid.Background = new SolidColorBrush(Colors.LightGreen);
        //            otchestvoGrid.Background = new SolidColorBrush(Colors.LightGreen);
        //            commissionGrid.Background = new SolidColorBrush(Colors.LightGreen);
        //        }
        //    }
        //}
        //for (int i = 0; i < viewModel.ВсеРиелторы.Count; i++)
        //{
        //    TextBlock fioTextBox = FindName($"Фамилия{i}") as TextBlock;
        //    TextBlock emailTextBox = FindName($"Имя{i}") as TextBlock;
        //    TextBlock orderNumberTextBox = FindName($"Отчество{i}") as TextBlock;
        //    TextBlock phoneTextBox = FindName($"Комиссия{i}") as TextBlock;
        //    if (fioTextBox != null && emailTextBox != null && orderNumberTextBox != null && phoneTextBox != null)
        //    {
        //        if (viewModel.ВсеРиелторы[i].Equals(foundUser))
        //        {
        //            fioTextBox.Background = new SolidColorBrush(Colors.LightGreen);
        //            emailTextBox.Background = new SolidColorBrush(Colors.LightGreen);
        //            orderNumberTextBox.Background = new SolidColorBrush(Colors.LightGreen);
        //            phoneTextBox.Background = new SolidColorBrush(Colors.LightGreen);
        //        }
        //    }
        //}
    }
        private void ClearUserFieldHighlight()
        {
            for (int i = 0; i < viewModel.ВсеРиелторы.Count; i++)
            {
                TextBox fioTextBox = FindName($"Фамилия{i}") as TextBox;
                TextBox emailTextBox = FindName($"Имя{i}") as TextBox;
                TextBox orderNumberTextBox = FindName($"Отчество{i}") as TextBox;
                TextBox phoneTextBox = FindName($"Комиссия{i}") as TextBox;
                if (fioTextBox != null)
                {
                    fioTextBox.ClearValue(BackgroundProperty);
                    emailTextBox.ClearValue(BackgroundProperty);
                    orderNumberTextBox.ClearValue(BackgroundProperty);
                    phoneTextBox.ClearValue(BackgroundProperty);
                }
            }
        }
        //
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    var textBox = sender as TextBox;
            //    if (textBox != null)
            //    {
            //        MainView_Model viewModel = MainView_Model.Instance;

            //        if (viewModel.SelectedUser == null)
            //        {
            //            viewModel.SelectedUser = new Пользователи();
            //        }

            //        if (textBox.Name == "FIOTextBox0")
            //        {
            //            if (string.IsNullOrWhiteSpace(textBox.Text))
            //            {
            //                viewModel.SelectedUser.ФИО = null;
            //            }
            //            else
            //            {
            //                viewModel.SelectedUser.ФИО = textBox.Text;
            //            }
            //        }
            //        else if (textBox.Name == "EmailTextBox0")
            //        {
            //            if (string.IsNullOrWhiteSpace(textBox.Text))
            //            {
            //                viewModel.SelectedUser.Email = null;
            //            }
            //            else
            //            {
            //                viewModel.SelectedUser.Email = textBox.Text;
            //            }
            //        }
            //        else if (textBox.Name == "OrderNumberTextBox0")
            //        {
            //            if (string.IsNullOrWhiteSpace(textBox.Text))
            //            {
            //                viewModel.SelectedUser.Номер_заказа = 0;
            //            }
            //            else if (int.TryParse(textBox.Text, out int orderNumber))
            //            {
            //                viewModel.SelectedUser.Номер_заказа = orderNumber;
            //            }
            //            else
            //            {
            //                MessageBox.Show("Неверный формат номера заказа");
            //            }
            //        }
            //        else if (textBox.Name == "PhoneTextBox0")
            //        {
            //            if (string.IsNullOrWhiteSpace(textBox.Text))
            //            {
            //                viewModel.SelectedUser.Телефон = null;
            //            }
            //            else
            //            {
            //                viewModel.SelectedUser.Телефон = textBox.Text;
            //            }
            //        }
            //        else if (textBox.Name == "Image")
            //        {
            //            if (string.IsNullOrWhiteSpace(textBox.Text))
            //            {
            //                viewModel.SelectedUser.Изображение = null;
            //            }
            //            else
            //            {
            //                viewModel.SelectedUser.Телефон = textBox.Text;
            //            }
            //        }

            //        viewModel.UpdateUser(viewModel.SelectedUser);
            //        viewModel.SaveChanges();
            //    }
            //}
        }

       

        //private void FIOTextBox11_KeyDown(object sender, KeyEventArgs e)
        //{

        //    {

        //        if (e.Key == Key.Enter)
        //        {
        //            MainView_Model viewModel = MainView_Model.Instance;

        //            if (string.IsNullOrEmpty(FIOTextBox4.Text) || string.IsNullOrEmpty(EmailTextBox4.Text) || string.IsNullOrEmpty(OrderNumberTextBox4.Text) || string.IsNullOrEmpty(PhoneTextBox4.Text))
        //            {
        //                MessageBox.Show("Пожалуйста, заполните все поля");
        //                return;
        //            }

        //            if (viewModel.SelectedUser == null)
        //            {
        //                viewModel.SelectedUser = new Пользователи();
        //            }

        //            viewModel.SelectedUser.ФИО = FIOTextBox4.Text;
        //            viewModel.SelectedUser.Email = EmailTextBox4.Text;


        //            if (int.TryParse(OrderNumberTextBox4.Text, out int orderNumber))
        //            {
        //                viewModel.SelectedUser.Номер_заказа = orderNumber;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Неверный формат номера заказа");
        //                return;
        //            }

        //            viewModel.SelectedUser.Телефон = PhoneTextBox4.Text;

        //            viewModel.AddUser(viewModel.SelectedUser);
        //            viewModel.SaveChanges();

        //            FIOTextBox4.Text = viewModel.SelectedUser.ФИО;
        //            EmailTextBox4.Text = viewModel.SelectedUser.Email;
        //            OrderNumberTextBox4.Text = viewModel.SelectedUser.Номер_заказа.ToString();
        //           PhoneTextBox4.Text = viewModel.SelectedUser.Телефон;
        //        }
        //}   }


        //private void TextBox_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Delete)
        //    {
        //        // Убедитесь, что SelectedUser не null
        //        if (MainView_Model.Instance.SelectedUser != null)
        //        {
        //            // Проверьте, что хотите лишь удалить запись, а не сохранить изменения
        //            var confirmation = MessageBox.Show($"Удалить пользователя {MainView_Model.Instance.SelectedUser.ФИО}?", "Подтверждение", MessageBoxButton.YesNo);
        //            if (confirmation == MessageBoxResult.Yes)
        //            {
        //                MainView_Model.Instance.DeleteUser(MainView_Model.Instance.SelectedUser);
        //                MainView_Model.Instance.ErrorMessage = "Запись успешно удалена.";
        //            }
        //        }
        //    }
        //}

        //private void FIOTextBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        var textBox = sender as TextBox;
        //        if (textBox != null)
        //        {
        //            MainView_Model viewModel = MainView_Model.Instance;

        //            if (viewModel.SelectedUser == null)
        //            {
        //                viewModel.SelectedUser = new Пользователи();
        //            }

        //            if (textBox.Name == "FIOTextBox1")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.ФИО = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.ФИО = textBox.Text;
        //                }
        //            }
        //            else if (textBox.Name == "EmailTextBox1")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Email = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.Email = textBox.Text;
        //                }
        //            }
        //            else if (textBox.Name == "OrderNumberTextBox1")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Номер_заказа = 0;
        //                }
        //                else if (int.TryParse(textBox.Text, out int orderNumber))
        //                {
        //                    viewModel.SelectedUser.Номер_заказа = orderNumber;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Неверный формат номера заказа");
        //                }
        //            }
        //            else if (textBox.Name == "PhoneTextBox1")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Телефон = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.Телефон = textBox.Text;
        //                }
        //            }
        //            else if (textBox.Name == "Image")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Изображение = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.Телефон = textBox.Text;
        //                }
        //            }

        //            viewModel.UpdateUser(viewModel.SelectedUser);
        //            viewModel.SaveChanges();
        //        }
        //    }

        //}

        //private void FIOTextBox2_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        var textBox = sender as TextBox;
        //        if (textBox != null)
        //        {
        //            MainView_Model viewModel = MainView_Model.Instance;

        //            if (viewModel.SelectedUser == null)
        //            {
        //                viewModel.SelectedUser = new Пользователи();
        //            }

        //            if (textBox.Name == "FIOTextBox2")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.ФИО = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.ФИО = textBox.Text;
        //                }
        //            }
        //            else if (textBox.Name == "EmailTextBox2")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Email = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.Email = textBox.Text;
        //                }
        //            }
        //            else if (textBox.Name == "OrderNumberTextBox2")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Номер_заказа = 0;
        //                }
        //                else if (int.TryParse(textBox.Text, out int orderNumber))
        //                {
        //                    viewModel.SelectedUser.Номер_заказа = orderNumber;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Неверный формат номера заказа");
        //                }
        //            }
        //            else if (textBox.Name == "PhoneTextBox2")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Телефон = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.Телефон = textBox.Text;
        //                }
        //            }
        //            else if (textBox.Name == "Image")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Изображение = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.Телефон = textBox.Text;
        //                }
        //            }

        //            viewModel.UpdateUser(viewModel.SelectedUser);
        //            viewModel.SaveChanges();
        //        }
        //    }

        //}

        //private void FIOTextBox3_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        var textBox = sender as TextBox;
        //        if (textBox != null)
        //        {
        //            MainView_Model viewModel = MainView_Model.Instance;

        //            if (viewModel.SelectedUser == null)
        //            {
        //                viewModel.SelectedUser = new Пользователи();
        //            }

        //            if (textBox.Name == "FIOTextBox3")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.ФИО = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.ФИО = textBox.Text;
        //                }
        //            }
        //            else if (textBox.Name == "EmailTextBox3")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Email = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.Email = textBox.Text;
        //                }
        //            }
        //            else if (textBox.Name == "OrderNumberTextBox3")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Номер_заказа = 0;
        //                }
        //                else if (int.TryParse(textBox.Text, out int orderNumber))
        //                {
        //                    viewModel.SelectedUser.Номер_заказа = orderNumber;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Неверный формат номера заказа");
        //                }
        //            }
        //            else if (textBox.Name == "PhoneTextBox3")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Телефон = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.Телефон = textBox.Text;
        //                }
        //            }
        //            else if (textBox.Name == "Image")
        //            {
        //                if (string.IsNullOrWhiteSpace(textBox.Text))
        //                {
        //                    viewModel.SelectedUser.Изображение = null;
        //                }
        //                else
        //                {
        //                    viewModel.SelectedUser.Телефон = textBox.Text;
        //                }
        //            }

        //            viewModel.UpdateUser(viewModel.SelectedUser);
        //            viewModel.SaveChanges();
        //        }
        //    }

        //}

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            addWindow.Show();

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int productId;
            if (!int.TryParse(RealtorId.Text, out productId))
            {
                MessageBox.Show("Введите корректный ID риелтора");
                return;
            }
            using (var context = new dbEntities())
            {
                var productToChange = context.Realtor.FirstOrDefault(p => p.ID == productId);
                if (productToChange != null)
                {
                    Change changeWindow = new Change(productToChange);
                    changeWindow.Show();
                }
                else
                {
                    MessageBox.Show("Риелтор с указанным ID не найден");
                }
            }

        }
        public void DeleteProduct(int productId)
        {
            using (var context = new dbEntities())
            {
                var productToDelete = context.Realtor.FirstOrDefault(p => p.ID == productId);
                if (productToDelete != null)
                {
                    context.Realtor.Remove(productToDelete);
                    context.SaveChanges();
                }
            }
        }

        public void Delite(int productId)
        {
            using (var context = new dbEntities())
            {
                
                var productToDelete = context.Realtor.FirstOrDefault(p => p.ID == productId);
                if (productToDelete != null)
                {
                  
                    context.Realtor.Remove(productToDelete);
                    context.SaveChanges();
                    MessageBox.Show("Риелтор успешно удален");
                }
                else
                {
                    MessageBox.Show("Риелтор с указанным ID не найден");
                }
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RealtorId.Text, out int productId))
            {
                MessageBox.Show("Введите корректный ID риелтора");
                return;
            }
            Delite(productId);


        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Информация_о_пользователях adminWindow = new Информация_о_пользователях();
            adminWindow.Show();
            this.Close();
        }

        private void RealtorId_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
