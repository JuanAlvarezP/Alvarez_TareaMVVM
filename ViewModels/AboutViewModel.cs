using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alvarez_AppApuntes.ViewModels
{
    internal class AboutViewModel
    {
        public string JA_Title => AppInfo.Name;
        public string JA_Version => AppInfo.VersionString;
        public string JA_MoreInfoUrl => "https://aka.ms/maui";
        public string JA_Message => "This app is written in XAML and C# with .NET MAUI.";
        public ICommand ShowMoreInfoCommand { get; }

        public AboutViewModel()
        {
            ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
        }

        async Task ShowMoreInfo() =>
            await Launcher.Default.OpenAsync(JA_MoreInfoUrl);
    }
}
