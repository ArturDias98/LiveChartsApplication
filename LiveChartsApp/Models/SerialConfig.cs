using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Linq;

namespace LiveChartsApp.Models
{
    public class SerialConfig
    {
        private List<string> commports = new List<string>();
        public SerialConfig()
        {                    
            GetCommPorts();
            SetBaudRates();
            SetParity();
            SetStopBit();
        }

        public List<string> GetCommPorts()
        {
            commports = SerialPort.GetPortNames().ToList();
            return commports;   
        }

        public List<string> SetBaudRates()
        {
            string[] list = { "9600", "38400", "115200"};
            var baudList = list.ToList();
            return baudList;    
        }
        public List<string> SetParity()
        {

            string[] parities = {"None", "Odd", "Even", "Mark", "Space"};
            var parity = parities.ToList();           
            return parity;  
        }

        public List<string> SetStopBit()
        {

            string[] stop = { "None", "One", "Two", "One point Five"};
            var stopBit = stop.ToList();
            return stopBit;
        }

        public bool CheckForNewPorts()
        {
            var oldList = commports;
            var newList = SerialPort.GetPortNames().ToList();
            if (newList.Count() > oldList.Count())
            {
                return true;
            }
            else if (newList.Count() < oldList.Count())
            {
                return true;
            }

            else return false;  
        }

    }
}
