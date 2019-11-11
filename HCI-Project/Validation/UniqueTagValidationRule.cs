using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HCI_Project.Validation
{
    public class UniqueTagValidationRule : ValidationRule
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = (string)value;
            var tags = _mainWindow.Tags;
            IEnumerable<string> res = from tag in tags
                                      where tag.Id == s
                                      select tag.Id;
            if (res.Count() == 0)
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "This ID has been taken");
            }

        }
    }
}
