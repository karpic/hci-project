using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MapaPrirodnihSpomenika.Dijalozi
{
    class IzmenaSpomenikValidationRules : System.Windows.Controls.ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                if (s.Length < 20)
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Unesite vrednost koja ima manje od 20 karaktera.");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska.");
            }
        }
    }
}
