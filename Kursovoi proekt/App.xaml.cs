using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovoi_proekt
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static KursovikBDEntities Context;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Context = new KursovikBDEntities();
        }
    }
}
