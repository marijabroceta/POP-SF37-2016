using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_37_2016_GUI.UI.Validacija
{
    class ValidacijaPopust:ValidationRule
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
                if (broj < 2 || broj > 95)
                {
                    return new ValidationResult(false, "Popust ne moze biti veci od 95% i manji od 2%");
                }
            }
            catch
            {
                return new ValidationResult(false, "Morate uneti pozitivan broj");
            }
            return new ValidationResult(true, null);
        }
    }
}
