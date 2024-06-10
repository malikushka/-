using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Интернет_магазин_Черешня
{
    
    public class MainView_Model : INotifyPropertyChanged
    {
        public dbEntities _dbContext;


        public ObservableCollection<Realtor> ВсеРиелторы { get; set; }
        public Realtor[] ПользователиArray { get; set; }

        private Realtor selectedUser;
        public Realtor SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (value != selectedUser)
                {
                    selectedUser = value;
                    OnPropertyChanged("SelectedUser");
                }
            }
        }

        //    public void AddUser(Пользователи newUser)
        //    {
        //        try
        //        {
        //            if (newUser == null)
        //            {
        //                newUser = new Пользователи();
        //            }

        //            int maxID = ВсеПользователи.Max(u => u.ID_п);
        //            newUser.ID_п = maxID + 1;

        //            _dbContext.Пользователи.Add(newUser);
        //            _dbContext.SaveChanges();

        //            Debug.WriteLine("Пользователь успешно добавлен в базу данных");

        //            ВсеПользователи.Add(newUser);
        //            OnPropertyChanged(nameof(ВсеПользователи));

        //            Debug.WriteLine("Список пользователей обновлен");

        //            MessageBox.Show("Пользователь успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Ошибка: {ex.Message}");

        //            Exception innerException = ex.InnerException;
        //            while (innerException != null)
        //            {
        //                MessageBox.Show($"Внутреннее исключение: {innerException.Message}");
        //                innerException = innerException.InnerException;
        //            }
        //    }   }

        //    private string errorMessage;
        //    public string ErrorMessage
        //    {
        //        get { return errorMessage; }
        //        set
        //        {
        //            if (value != errorMessage)
        //            {
        //                errorMessage = value;
        //                OnPropertyChanged("ErrorMessage");
        //            }
        //        }
        //    }
        //    private static MainView_Model instance;

        //    public static MainView_Model Instance
        //    {
        //        get
        //        {
        //            if (instance == null)
        //            {
        //                instance = new MainView_Model();
        //            }
        //            return instance;
        //        }
        //    }

        //    private string image;
        //    public string Image
        //    {
        //        get { return image; }
        //        set
        //        {
        //            if (value != image)
        //            {
        //                image = value;
        //                OnPropertyChanged("Image");
        //            }
        //        }
        //    }


        public MainView_Model()
        {
            _dbContext = new dbEntities();
            ВсеРиелторы = new ObservableCollection<Realtor>(_dbContext.Realtor.Take(200).ToList());
            ПользователиArray = ВсеРиелторы.ToArray();

        }

        //    public void UpdateUser(Пользователи updatedUser)
        //    {
        //        var existingUser = _dbContext.Пользователи.Find(updatedUser.ID_п);
        //        if (existingUser != null)
        //        {
        //            try
        //            {
        //                existingUser.ФИО = updatedUser.ФИО;
        //                existingUser.Email = updatedUser.Email;
        //                existingUser.Номер_заказа = updatedUser.Номер_заказа;
        //                existingUser.Телефон = updatedUser.Телефон;
        //                existingUser.Изображение = updatedUser.Изображение;

        //                _dbContext.SaveChanges();
        //                MessageBox.Show("Изменения сохранены успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        //            }
        //            catch (DbEntityValidationException ex)
        //            {
        //                var errorMessages = ex.EntityValidationErrors
        //                    .SelectMany(e => e.ValidationErrors)
        //                    .Select(e => $"{e.PropertyName}: {e.ErrorMessage}"); 


        //                var fullErrorMessage = string.Join(Environment.NewLine, errorMessages);

        //                MessageBox.Show($"Ошибки валидации: {fullErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //            }
        //            catch (DbUpdateException ex)
        //            {

        //                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //            }
        //            catch (Exception ex)
        //            {

        //                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }

        //    public void SaveChanges()
        //    {
        //        try
        //        {
        //            _dbContext.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            ErrorMessage = $"Ошибка при сохранении изменений: {ex.Message}";
        //        }
        //    }

        //    public void DeleteUser(Пользователи deleteUser)
        //    {

        //        using (var transaction = _dbContext.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                _dbContext.Пользователи.Remove(deleteUser);
        //                _dbContext.SaveChanges();
        //                transaction.Commit();
        //                MainView_Model.Instance.ErrorMessage = "Запись успешно удалена.";
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                MainView_Model.Instance.ErrorMessage = $"Ошибка при удалении записи: {ex.Message}";
        //            }
        //        }

        //    }



        public Realtor FindUserByFIO(string searchTerm)
        {
            if (ВсеРиелторы != null && ВсеРиелторы.Any())
            {
                return ВсеРиелторы.FirstOrDefault(user => user.Surname.Contains(searchTerm) ||
                                    user.Name.Contains(searchTerm) ||
                                    user.Otchestvo.Contains(searchTerm));
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
