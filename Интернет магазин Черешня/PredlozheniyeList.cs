using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интернет_магазин_Черешня
{
    internal class PredlozheniyeList : INotifyPropertyChanged
    {
        private dbEntities _dbContext;

        public ObservableCollection<Predlozheniye> ВсеПредложения { get; set; }
        public Predlozheniye[] ПредложенияArray { get; set; }

        private Predlozheniye selectedProduct;
        public Predlozheniye SelectedProduct
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
        public PredlozheniyeList()
        {
            _dbContext = new dbEntities();
            ВсеПредложения = new ObservableCollection<Predlozheniye>(_dbContext.Predlozheniye.Take(100).ToList());
            ПредложенияArray = ВсеПредложения.ToArray();
        }
        public Predlozheniye FindUserByNomber(string searchTerm)
        {
            if (ВсеПредложения != null && ВсеПредложения.Any())
            {
                return ВсеПредложения.FirstOrDefault(user => user.Price.ToString().Contains(searchTerm));
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
