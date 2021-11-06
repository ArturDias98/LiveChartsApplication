using System;
using System.Collections.Generic;
using System.Text;

namespace LiveChartsApp.Models
{
    public class SerialModel
    {
        public List<string> AvaliableCommPorts { get; set; }    
        public List<string> AvaliableBaudRates { get; set; }   
        public List<string> AvaliableParity { get; set; }   
        public List<string> AvaliableStopBits { get; set; } 
        public List<string> AvaliableCharLength { get; set; }   
        public List <string> AvaliableChanelModes { get; set; }  
    }
}
