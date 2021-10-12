using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveChartsApp.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            CartesianChartViewModel = new CartesianChartViewModel();
            GaugeChartViewModel = new GaugeChartViewModel();
        }

        public GaugeChartViewModel GaugeChartViewModel { get; set; }
        public CartesianChartViewModel CartesianChartViewModel { get; set; }
    }
}
