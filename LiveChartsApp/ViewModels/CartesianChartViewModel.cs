using Caliburn.Micro;
using LiveCharts;
using LiveChartsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveChartsApp.ViewModels
{
    public class CartesianChartViewModel : Screen
    {

        private ChartValues<MeasureModel> _values;
        private double _axisMax;
        private double _axisMin;
        private double _axisStep;

        public Func<double, string> DateTimeFormatter { get; set; }
        
        public double AxisUnit { get; set; }

        

        public double AxisStep
        {
            get 
            { 
                return _axisStep; 
            }
            set 
            { 
                _axisStep = value;
                NotifyOfPropertyChange(() => AxisStep);
            }
        }

        public ChartValues<MeasureModel> Values
        {
            get
            {
                return _values; 
            }
            set
            {
                _values = value;
                NotifyOfPropertyChange(()=> Values);
            }
        }

        public double AxisMax
        {
            get 
            { 
                return _axisMax; 
            }
            set 
            { 
                _axisMax = value;
                NotifyOfPropertyChange(() => AxisMax);
            }
        }

        public double AxisMin
        {
            get
            {
                return _axisMin;
            }
            set
            {
                _axisMin = value;
                NotifyOfPropertyChange(() => AxisMin);
            }
        }

    }
}
