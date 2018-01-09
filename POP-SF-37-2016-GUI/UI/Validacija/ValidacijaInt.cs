using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_37_2016_GUI.UI.Validacija
{
    class ValidacijaInt:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;
            int broj;

            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "Popunite polje!");
            }
            try
            {
                broj = int.Parse(str);
                if (broj <= 0)
                {
                    throw new Exception();
                }
                    
            }
            catch(Exception)
            {
                return new ValidationResult(false, "Morate uneti pozitivan broj!");
            }
            return new ValidationResult(true, null);

        }
    }
}
