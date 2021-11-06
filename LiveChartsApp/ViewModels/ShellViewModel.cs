using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Configurations;
using LiveChartsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace LiveChartsApp.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly Timer plotTimer = new Timer(1000) { AutoReset = false };
        private readonly Random random = new Random();
        
        
        public ShellViewModel()
        {
            CartesianChartViewModel = new CartesianChartViewModel();
            GaugeChartViewModel = new GaugeChartViewModel();
            var mapper = Mappers.Xy<MeasureModel>().X(x => x.Time.Ticks).Y(x => x.Value);
            Charting.For<MeasureModel>(mapper);
            CartesianChartViewModel.DateTimeFormatter = value => new DateTime((long)value).ToString("mm:ss");
            CartesianChartViewModel.AxisStep = TimeSpan.FromSeconds(1).Ticks;
            CartesianChartViewModel.AxisMax = DateTime.Now.Ticks ; 
            CartesianChartViewModel.AxisMin = DateTime.Now.Ticks - TimeSpan.FromSeconds(5).Ticks;
            CartesianChartViewModel.Values = new ChartValues<MeasureModel>();
            ConnectionViewModel = new ConnectionViewModel(); 
            plotTimer.Elapsed += plotTimer_ElapsedTime;
            plotTimer.Start();
        }

        private void plotTimer_ElapsedTime(object sender, ElapsedEventArgs e)
        {
            var plotGauge1 = random.Next(50, 100);
            var plotGauge2 = random.Next(50, 250);
            ConnectionViewModel.CheckNewCommPort();
            var now = DateTime.Now;
            Application.Current.Dispatcher.BeginInvoke(new System.Action(() => {
                CartesianChartViewModel.Values.Add(new MeasureModel
                {
                    Time = now,
                    Value = random.Next(10,45)
                }) ;
                GaugeChartViewModel.ValuesGauge1 = plotGauge1;
                GaugeChartViewModel.ValuesGauge2 = plotGauge2 ;
            }),DispatcherPriority.Background);
            CartesianChartViewModel.AxisMax = now.Ticks;
            CartesianChartViewModel.AxisMin = now.Ticks - TimeSpan.FromSeconds(5).Ticks;
            plotTimer.Start();
        }

        public void CloseWindow()
        {
            plotTimer.Stop();
            
        }
        
        public ConnectionViewModel ConnectionViewModel { get; set; }
        public GaugeChartViewModel GaugeChartViewModel { get; set; }
        public CartesianChartViewModel CartesianChartViewModel { get; set; }
    }
}
