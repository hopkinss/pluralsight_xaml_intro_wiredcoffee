using System;
using System.Collections.Generic;
using System.ComponentModel;
using WiredBrainCoffee.CusomtersApp.Base;

#nullable disable

namespace WiredBrainCoffee.CusomtersApp.Models
{
    [TypeConverter(typeof(CustomerConverter))]
    public class Customer : Observable
    {
        private string firstName;
        private string lastName;
        private bool isDeveloper;

        public int Id { get; set; }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName; set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public bool IsDeveloper
        {
            get => isDeveloper; set
            {
                isDeveloper = value;
                OnPropertyChanged();
            }
        }

    }
}
