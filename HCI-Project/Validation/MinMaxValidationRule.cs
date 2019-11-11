using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_Project.Validation
{
    class MinMaxValidationRule : ValidationRule
    {
        public double Min
        {
            get;
            set;
        }
        public double Max
        {
            get;
            set;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is double || value is int)
            {
                int d = (int)value;
                if (d < Min)
                {
                    return new ValidationResult(false, "Value cannot be under " + Min);
                }
                if (d > Max)
                {
                    return new ValidationResult(false, "Value cannot be over " + Max);
                }
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Value must be a number");
            }
        }
    }
}
