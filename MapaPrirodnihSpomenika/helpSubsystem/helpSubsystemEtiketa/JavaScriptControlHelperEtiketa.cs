using MapaPrirodnihSpomenika.Dijalozi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MapaPrirodnihSpomenika.helpSubsystem.helpSubsystemEtiketa
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelperEtiketa
    {
        IzmenaTag prozor;
        public JavaScriptControlHelperEtiketa(IzmenaTag w)
        {
            prozor = w;
        }

        public void RunFromJavascript(string param)
        {
            prozor.doThings(param);
        }
    }
}
