using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Интернет_магазин_Черешня
{
    public partial class Информация_о_заказах : Window
    {
        public List<Potrebnost> PotrebnostList { get; set; }
        private ЗаказыViewModel viewModel;
        public Информация_о_заказах()
        {
            InitializeComponent();
            PotrebnostList = GetClothingData();
            DataContext = this;
            this.WindowState = WindowState.Maximized;
            //viewModel = new ЗаказыViewModel();
            //this.DataContext = viewModel;

        }
        private List<Potrebnost> GetClothingData()
        {
            List<Potrebnost> realtorList = new List<Potrebnost>();

            using (var context = new dbEntities())
            {

                var realtorEntities = context.Potrebnost.ToList();

                foreach (var clothingEntity in realtorEntities)
                {
                    Potrebnost clothing = new Potrebnost
                    {
                        ID = clothingEntity.ID,
                        Adres = clothingEntity.Adres,
                        Min_price = clothingEntity.Min_price,
                        Max_price = clothingEntity.Max_price,
                        Min_P = clothingEntity.Min_P,
                        Max_P = clothingEntity.Max_P,
                        Min_R = clothingEntity.Min_R,
                        Max_R = clothingEntity.Max_R,
                        Min_F = clothingEntity.Min_F,
                        Max_F = clothingEntity.Max_F

                    };


                    realtorList.Add(clothing);
                }
            }

            return realtorList;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            Информация_о_товарах информация_о_Товарах = new Информация_о_товарах();
            информация_о_Товарах.WindowState = WindowState.Maximized;
            информация_о_Товарах.Show();
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
                viewModel = new ЗаказыViewModel();
            }

            string searchTerm = SearchText.Text;
            Potrebnost foundUserOrder = viewModel.FindUserByFIOORDER(searchTerm);
            if (foundUserOrder != null)
            {
                HighlightUserFields(foundUserOrder);
                ErrorMessageLabel2.Content = $"Адрес {foundUserOrder.Adres} найден";

            }
            else
            {
                ClearUserFieldHighlight();
                ErrorMessageLabel2.Content = "Адрес не найден";
            }
        }
        private void HighlightUserFields(Potrebnost foundUser)
        {
            for (int i = 0; i < viewModel.ВсеПотребности.Count; i++)
            {
                TextBox fioTextBox = FindName($"FIOTextBox{i}") as TextBox;
                if (fioTextBox != null)
                {
                    if (viewModel.ВсеПотребности[i].Equals(foundUser))
                    {
                        fioTextBox.Background = new SolidColorBrush(Colors.LightGreen);
                    }
                    else
                    {
                        fioTextBox.ClearValue(BackgroundProperty);
                    }
                }
            }
        }

        private void ClearUserFieldHighlight()
        {
            //for (int i = 0; i < viewModel.ВсеЗаказы.Count; i++)
            //{
            //    TextBox fioTextBox = FindName($"FIOTextBox{i}") as TextBox;
            //    if (fioTextBox != null)
            //    {
            //        fioTextBox.ClearValue(BackgroundProperty);
            //    }
            //}
        }
    }
    
}
