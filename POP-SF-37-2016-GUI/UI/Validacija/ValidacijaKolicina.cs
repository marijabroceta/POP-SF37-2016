using POP_37_2016.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_37_2016_GUI.UI.Validacija
{
    class ValidacijaKolicina:ValidationRule
    {
        public static Namestaj Namestaj { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;
            int broj;

            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "Popunite polje");
            }
              
            try
            {
                broj = int.Parse(str);
                if (broj <= 0)
                {
                    return new ValidationResult(false, "Morate uneti pozitivan broj");
                }
                else if (broj > Namestaj.KolicinaUMagacinu)
                {
                    return new ValidationResult(false, "Kolicina nije dostupna");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            catch(Exception)
            {
                return new ValidationResult(false, "Morate uneti pozitivan broj");
            }
            

        }
    }
}
