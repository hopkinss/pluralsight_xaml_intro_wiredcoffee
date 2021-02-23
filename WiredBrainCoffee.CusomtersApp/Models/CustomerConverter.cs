using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace WiredBrainCoffee.CusomtersApp.Models
{
    public class CustomerConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return base.CanConvertFrom(context, sourceType);
            }
            return base.CanConvertFrom(context, sourceType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, 
            CultureInfo culture, 
            object value)
        {
            if (value is string inputString)
            {
                var values = inputString.Split(',');
                return new Customer
                {
                    FirstName = values[0],
                    LastName = values[1],
                    IsDeveloper = bool.Parse(values[2])
                };

            }
            return base.ConvertFrom(context, culture, value);
        }

    }
}
