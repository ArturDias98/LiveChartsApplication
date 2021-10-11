using Caliburn.Micro;
using LiveChartsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LiveChartsApp
{
   public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
