using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_Project.Validation
{
    class StringPathValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = (string)value;
            try
            {
                Path.GetFullPath(s);
            }
            catch (Exception)
            {

                return new ValidationResult(false, "Please check path");
            }
            return new ValidationResult(true, null);
        }
    }
}
