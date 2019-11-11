using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace HCI_Project.Validation
{
    class UniqueFestivalsValidationRule : ValidationRule
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = (string)value;
            var festivals = _mainWindow.Festivals;
            IEnumerable<string> res = from f in festivals
                                      where f.Id == s
                                      select f.Id;
            if (res.Count() == 0)
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "This ID has been taken. Please choose another.");
            }

        }
    }
}
