using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

//Performed by Slipushkina Oleksandra

namespace Laboratory2
{
    public class Person : INotifyPropertyChanged
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime? BirthDate { get; }

        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.MinValue) { }

        public Person(string firstName, string lastName, DateTime birthDate)
            : this(firstName, lastName, "", birthDate) { }

        public bool IsAdult => BirthDate.HasValue && (DateTime.Today.Year - BirthDate.Value.Year) >= 18;

        public bool IsBirthday => BirthDate.HasValue && BirthDate.Value.Day == DateTime.Today.Day && BirthDate.Value.Month == DateTime.Today.Month;

        public string SunSign => GetWesternZodiacSign(BirthDate);
        public string ChineseSign => GetChineseZodiacSign(BirthDate);

        private string GetWesternZodiacSign(DateTime? birthDate)
        {
            if (!birthDate.HasValue) return "Unknown";
            int day = birthDate.Value.Day;
            int month = birthDate.Value.Month;

            if ((month == 1 && day <= 19) || (month == 12 && day >= 22)) return "Козоріг";
            if ((month == 1 && day >= 20) || (month == 2 && day <= 18)) return "Водолій";
            if ((month == 2 && day >= 19) || (month == 3 && day <= 20)) return "Риби";
            if ((month == 3 && day >= 21) || (month == 4 && day <= 19)) return "Овен";
            if ((month == 4 && day >= 20) || (month == 5 && day <= 20)) return "Телець";
            if ((month == 5 && day >= 21) || (month == 6 && day <= 20)) return "Близнюки";
            if ((month == 6 && day >= 21) || (month == 7 && day <= 22)) return "Рак";
            if ((month == 7 && day >= 23) || (month == 8 && day <= 22)) return "Лев";
            if ((month == 8 && day >= 23) || (month == 9 && day <= 22)) return "Діва";
            if ((month == 9 && day >= 23) || (month == 10 && day <= 22)) return "Терези";
            if ((month == 10 && day >= 23) || (month == 11 && day <= 21)) return "Скорпіон";
            if ((month == 11 && day >= 22) || (month == 12 && day <= 21)) return "Стрілець";

            return "Unknown";
        }

        private string GetChineseZodiacSign(DateTime? birthDate)
        {
            if (!birthDate.HasValue) return "Unknown";
            string[] signs = { "Мавпа", "Півень", "Собака", "Свиня", "Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза" };
            return signs[birthDate.Value.Year % 12];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}