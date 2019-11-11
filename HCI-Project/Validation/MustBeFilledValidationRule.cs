using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_Project.Validation
{
    class MustBeFilledValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "This field must be filled");
            }
            if (value.Equals(""))
            {
                return new ValidationResult(false, "This field must be filled");
            }
            return new ValidationResult(true, null);
        }
    }
}
