using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_Project.Validation
{
    public class NoSpacesValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "This field must be filled");
            }
            string name = (string)value;
            if (name.Contains(" "))
            {
                return new ValidationResult(false, "Name may not contain spaces");
            }
            return new ValidationResult(true, null);
        }
    }
}
