using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WiredBrainCoffee.CusomtersApp.Models;

namespace WiredBrainCoffee.CusomtersApp.Controls
{
    [ContentProperty(nameof(Customer))]
    public partial class CustomerDetailControl : UserControl
    {
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register("Customer", typeof(Customer), typeof(CustomerDetailControl),
                new PropertyMetadata(null));

        public CustomerDetailControl()
        {
            InitializeComponent();
        }

        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }



    }
}
