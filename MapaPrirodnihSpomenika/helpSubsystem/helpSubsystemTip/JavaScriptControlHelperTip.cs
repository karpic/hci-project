using MapaPrirodnihSpomenika.Dijalozi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MapaPrirodnihSpomenika.helpSubsystem.helpSubsystemTip
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelperTip
    {
        IzmenaTipSpomenika prozor;
        public JavaScriptControlHelperTip(IzmenaTipSpomenika w)
        {
            prozor = w;
        }

        public void RunFromJavascript(string param)
        {
            prozor.doThings(param);
        }
    }
}
