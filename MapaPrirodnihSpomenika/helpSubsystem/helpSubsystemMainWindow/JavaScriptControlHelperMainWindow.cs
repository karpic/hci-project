using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MapaPrirodnihSpomenika.helpSubsystem.helpSubsystemMainWindow
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelperMainWindow
    {
        MainWindow prozor;
        public JavaScriptControlHelperMainWindow(MainWindow w)
        {
            prozor = w;
        }

        public void RunFromJavascript(string param)
        {
            prozor.doThings(param);
        }
    }
}
