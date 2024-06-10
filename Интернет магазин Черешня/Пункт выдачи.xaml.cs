
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Интернет_магазин_Черешня
{
    public partial class Пункт_выдачи : Window
    {
        public List<Predlozheniye> PredlozheniyeList { get; set; }
        private PredlozheniyeList viewModel;
        public Пункт_выдачи()
        {
            InitializeComponent();
            PredlozheniyeList = GetClothingData();
            DataContext = this;
            this.WindowState = WindowState.Maximized;
        }
        private List<Predlozheniye> GetClothingData()
        {
            List<Predlozheniye> realtorList = new List<Predlozheniye>();

            using (var context = new dbEntities())
            {

                var realtorEntities = context.Predlozheniye.ToList();

                foreach (var clothingEntity in realtorEntities)
                {
                    Predlozheniye clothing = new Predlozheniye
                    {
                        ID = clothingEntity.ID,
                        Price = clothingEntity.Price,
                        

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
            Информация_о_товарах информация_о_Товарах = new Информация_о_товарах();
            информация_о_Товарах.WindowState = WindowState.Maximized;
            информация_о_Товарах.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Информация_о_заказах информация_о_Заказах = new Информация_о_заказах();
            информация_о_Заказах.WindowState = WindowState.Maximized;
            информация_о_Заказах.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (viewModel == null)
            {
                viewModel = new PredlozheniyeList ();
            }

            string searchTerm = SearchText.Text;
            Predlozheniye foundUserOrder = viewModel.FindUserByNomber(searchTerm);
            if (foundUserOrder != null)
            {
                HighlightUserFields(foundUserOrder);
                ErrorMessageLabel.Content = $"Цена {foundUserOrder.Price} найдена";

            }
            else
            {
                ClearUserFieldHighlight();
                ErrorMessageLabel.Content = "Цена не найдена";
            }

        }
        private void HighlightUserFields(Predlozheniye foundClient)
        {
            for (int i = 0; i < viewModel.ВсеПредложения.Count; i++)
            {
                TextBlock productTextBox = FindName($"PRODUCTTextBox{i}") as TextBlock;
                if (productTextBox != null)
                {
                    if (viewModel.ВсеПредложения[i].Equals(foundClient))
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
            for (int i = 0; i < viewModel.ВсеПредложения.Count; i++)
            {
                TextBox productTextBox = FindName($"PRODUCTTextBox{i}") as TextBox;
                if (productTextBox != null)
                {
                    productTextBox.ClearValue(BackgroundProperty);
                }
            }
        }

    }
}
