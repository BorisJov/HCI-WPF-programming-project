using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_Project.Validation
{
    class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = (string)value;
            DateTime dt;
            if (s == null || s.Equals(""))
            {
                return new ValidationResult(false, "This field must be filled");
            }

            if (DateTime.TryParse(s, out dt))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Date format: DD-MMM-YY");
        }
    }
}
