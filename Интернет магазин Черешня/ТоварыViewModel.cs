
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Интернет_магазин_Черешня
{
    public class ТоварыViewModel : INotifyPropertyChanged
    {
        private dbEntities _dbContext;

        public ObservableCollection<Client> ВсеКлиенты { get; set; }
        public Client[] ТоварыArray { get; set; }

        private Client selectedProduct;
        public Client SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (value != selectedProduct)
                {
                    selectedProduct = value;
                    OnPropertyChanged("SelectedProduct");
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
        public ТоварыViewModel()
        {
            _dbContext = new dbEntities();
            ВсеКлиенты = new ObservableCollection<Client>(_dbContext.Client.Take(100).ToList());
            ТоварыArray = ВсеКлиенты.ToArray();
        }
        public Client FindUserByNomber(string searchTerm)
        {
            if (ВсеКлиенты != null && ВсеКлиенты.Any())
            {
                return ВсеКлиенты.FirstOrDefault(user => user.Surname.Contains(searchTerm) ||
                                    user.Name.Contains(searchTerm) ||
                                    user.Otchestvo.Contains(searchTerm));
            }
            return null;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyProduct)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyProduct));
        }
    }
}
