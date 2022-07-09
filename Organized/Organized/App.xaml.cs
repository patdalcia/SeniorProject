using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Organized
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SplashScreen2 splash = new SplashScreen2("Images/SplashScreenImage.png");
            splash.Show(TimeSpan.FromSeconds(3));//Show for at least 2 seconds min duration
        }
    }
}
