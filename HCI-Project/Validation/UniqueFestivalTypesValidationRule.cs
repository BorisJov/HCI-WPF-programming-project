using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HCI_Project.Validation
{
    class UniqueFestivalTypesValidationRule : ValidationRule
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = (string)value;
            var festtypes = _mainWindow.FestivalTypes;
            IEnumerable<string> res = from ft in festtypes
                                      where ft.Id == s
                                      select ft.Id;
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
