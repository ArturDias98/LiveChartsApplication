using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveChartsApp.ViewModels
{
    public class GaugeChartViewModel : Screen
    {
        private double _valuesGauge1;
        private double _valuesGauge2;

        public GaugeChartViewModel()
        {

        }

        public double ValuesGauge1
        {
            get 
            { 
                return _valuesGauge1;
            }
            set 
            { 
                _valuesGauge1 = value;
                NotifyOfPropertyChange(()=> ValuesGauge1);
            }
        }
       

        public double ValuesGauge2
        {
            get 
            { 
                return _valuesGauge2; 
            }
            set 
            { 
                _valuesGauge2 = value;
                NotifyOfPropertyChange(() => ValuesGauge2);
            }
        }

    }
}
