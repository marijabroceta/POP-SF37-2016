using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_37_2016_GUI.UI.Validacija
{
    class ValidacijaString: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;

            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "Popunite polje!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
