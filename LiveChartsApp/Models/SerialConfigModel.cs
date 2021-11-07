using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Linq;

namespace LiveChartsApp.Models
{
    public class SerialConfigModel
    {
        private List<string> commports = new List<string>();
        public SerialConfigModel()
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

        public List<int> SetBaudRates()
        {
            int[] list = { 9600, 38400, 115200};
            var baudList = list.ToList();
            return baudList;    
        }
        public List<Parity> SetParity()
        {

            Parity[] parities = { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
            var parity = parities.ToList();           
            return parity;  
        }

        public List<StopBits> SetStopBit()
        {

            StopBits[] stop = { StopBits.One, StopBits.Two, StopBits.OnePointFive};
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
