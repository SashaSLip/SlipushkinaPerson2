using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

//Performed by Slipushkina Oleksandra

namespace Laboratory2
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime? _birthDate;
        private bool _isProcessing;
        private Person _person;

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(); ValidateInputs(); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); ValidateInputs(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); ValidateInputs(); }
        }

        public DateTime? BirthDate
        {
            get => _birthDate;
            set { _birthDate = value; OnPropertyChanged(); ValidateInputs(); }
        }

        public bool IsProcessing
        {
            get => _isProcessing;
            private set { _isProcessing = value; OnPropertyChanged(); }
        }

        public bool CanProceed { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ValidateInputs()
        {
            CanProceed = !string.IsNullOrWhiteSpace(FirstName) &&
                         !string.IsNullOrWhiteSpace(LastName) &&
                         !string.IsNullOrWhiteSpace(Email) &&
                         BirthDate.HasValue;
            OnPropertyChanged(nameof(CanProceed));
        }

        public async void ProceedAsync()
        {
            IsProcessing = true;
            await Task.Delay(1000); 

            if (BirthDate.Value > DateTime.Today || (DateTime.Today.Year - BirthDate.Value.Year) > 135)
            {
                MessageBox.Show("Неправильна дата народження!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                IsProcessing = false;
                return;
            }

            _person = new Person(FirstName, LastName, Email, BirthDate.Value);

            if (_person.IsBirthday)
            {
                MessageBox.Show("З Днем народження!", "Привітання", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            MessageBox.Show($"Ім'я: {_person.FirstName}\n" +
                            $"Прізвище: {_person.LastName}\n" +
                            $"Email: {_person.Email}\n" +
                            $"Дата народження: {_person.BirthDate:dd.MM.yyyy}\n" +
                            $"Дорослий: {_person.IsAdult}\n" +
                            $"Західний знак: {_person.SunSign}\n" +
                            $"Китайський знак: {_person.ChineseSign}\n" +
                            $"День народження сьогодні: {_person.IsBirthday}",
                            "Результати", MessageBoxButton.OK, MessageBoxImage.Information);

            IsProcessing = false;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

