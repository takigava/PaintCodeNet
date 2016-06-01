using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PaintCodeNet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var service = FirstFloor.XamlSpy.Services.XamlSpyService.Current;
            service.Connect("10.1.0.208",4530,"68169");
            SfSkinManager.ApplyStylesOnApplication = true;
            base.OnStartup(e);
        }
    }
}
