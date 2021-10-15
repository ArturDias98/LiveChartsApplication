using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace LiveChartsApp.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private Timer plotTimer = new Timer(250) { AutoReset = false };
        private Random random = new Random();
        private double plotData;
        public ShellViewModel()
        {
            CartesianChartViewModel = new CartesianChartViewModel();           
            GaugeChartViewModel = new GaugeChartViewModel();
            
            
            plotTimer.Elapsed += plotTimer_ElapsedTime;
            plotTimer.Start();
        }

        private void plotTimer_ElapsedTime(object sender, ElapsedEventArgs e)
        {
            plotData = random.Next(50, 100);
            Application.Current.Dispatcher.BeginInvoke(new System.Action(() => {
                GaugeChartViewModel.ValuesGauge1 = plotData;
                GaugeChartViewModel.ValuesGauge2 = plotData + 15;
            }),DispatcherPriority.Background);
            
            plotTimer.Start();
        }

        public void CloseWindow()
        {
            plotTimer.Stop();
        }
        
        public GaugeChartViewModel GaugeChartViewModel { get; set; }
        public CartesianChartViewModel CartesianChartViewModel { get; set; }
    }
}
