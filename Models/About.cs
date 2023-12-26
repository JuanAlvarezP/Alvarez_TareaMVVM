using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alvarez_AppApuntes.Models
{
    internal class About
    {
        public string Titulo_Alvarez => AppInfo.Name;
        public string Version_Alvarez => AppInfo.VersionString;
        public string MoreInfoUrl_ALvarez => "https://aka.ms/maui";
        public string Message_Alvarez => "This app is written in XAML and C# with .NET MAUI.";
    }
}
