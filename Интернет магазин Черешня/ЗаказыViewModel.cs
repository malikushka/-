
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Интернет_магазин_Черешня
{
    public class ЗаказыViewModel : INotifyPropertyChanged
    {
        private dbEntities _dbContext;

        public ObservableCollection<Potrebnost> ВсеПотребности { get; set; }
        public Potrebnost[] PotrebnostArray { get; set; }

        private Potrebnost selectedOrder;
        public Potrebnost SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                if (value != selectedOrder)
                {
                    selectedOrder = value;
                    OnPropertyChanged("SelectedOrder");
                }
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (value != errorMessage)
                {
                    errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }
        public ЗаказыViewModel()
        {
            _dbContext = new dbEntities();
            ВсеПотребности = new ObservableCollection<Potrebnost>(_dbContext.Potrebnost.Take(100).ToList());
            PotrebnostArray = ВсеПотребности.ToArray();
        }
        public Potrebnost FindUserByFIOORDER(string searchTerm)
        {
            if (ВсеПотребности != null && ВсеПотребности.Any())
            {
                return ВсеПотребности.FirstOrDefault(userorder => userorder.Adres.Contains(searchTerm));
            }
            return null;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
