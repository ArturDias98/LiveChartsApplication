using System;
using System.Collections.Generic;
using Caliburn.Micro;
using System.Text;
using LiveChartsApp.Models;
using System.Linq;
using System.Timers;
using System.IO.Ports;

namespace LiveChartsApp.ViewModels
{
    public class ConnectionViewModel : Screen
    {
        //Private Variables
        //private readonly Timer checkNewCommPort = new Timer(200) { AutoReset = true };
        private SerialConfig SerialConfig;
        private BindableCollection<string> commports;
        private string selectedcommport;
        private BindableCollection<string> baudrate;
        private string selectedbaudrate;
        private BindableCollection<string> parity;
        private string selectedparity;
        private BindableCollection<string> stopbit;
        private string selectedstopbit;
        public ConnectionViewModel()
        {
            IsButtonEnable = true;
            CommPortsList = new BindableCollection<string>();
            BaudRateList = new BindableCollection<string>();
            ParityList = new BindableCollection<string>();
            StopBitlist = new BindableCollection<string>();
            SerialConfig = new SerialConfig();           
            SetCommPorts(SerialConfig.GetCommPorts());
            SetBaudRates(SerialConfig.SetBaudRates());
            SetParity(SerialConfig.SetParity());
            SetStopBit(SerialConfig.SetStopBit());
            //checkNewCommPort.Elapsed += CheckNewCommPort_Elapsed;
              
            //checkNewCommPort.Start();
        }      

        //Public Variables
        public BindableCollection<string>  CommPortsList
        {
            get 
            { 
                return commports; 
            }
            set 
            { 
                commports = value;
                NotifyOfPropertyChange(() => CommPortsList);
            }
        }
        public BindableCollection<string> BaudRateList
        {
            get
            {
                return baudrate;
            }
            set
            {
                baudrate = value;
                NotifyOfPropertyChange(() => BaudRateList);
            }
        }
        public BindableCollection<string> ParityList
        {
            get
            {
                return parity;
            }
            set
            {
                parity = value;
                NotifyOfPropertyChange(() => ParityList);
            }
        }
        public BindableCollection<string> StopBitlist
        {
            get
            {
                return stopbit;
            }
            set
            {
                stopbit = value;
                NotifyOfPropertyChange(() => StopBitlist);
            }
        }       
        public string SelectedCommPort
        {
            get 
            {
                return selectedcommport;
            }
            set 
            {
                selectedcommport = value;
                NotifyOfPropertyChange(() => SelectedCommPort);
            }
        }       
        public string SelectedBaudRate
        {
            get 
            { 
                return selectedbaudrate; }
            set 
            { 
                selectedbaudrate = value;
                NotifyOfPropertyChange(() => SelectedBaudRate);
            }
        }        
        public string SelectedParity
        {
            get
            {
                return selectedparity;
            }
            set
            {
                selectedparity = value;
                NotifyOfPropertyChange(() => SelectedParity);
            }
        }       
        public string SelectedStopBit
        {
            get
            {
                return selectedstopbit;
            }
            set
            {
                selectedstopbit = value;
                NotifyOfPropertyChange(() => SelectedStopBit);
            }
        }
        public bool IsButtonEnable { get; set; }
        //Private Methods
        private void SetCommPorts(List<string> list)
        {
            int i = 0;
            foreach (var item in list)
            {

                commports.Add(list[i]);
                i++;
                                   
            }
        }
        private void SetBaudRates(List<string> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                baudrate.Add(list[i]);
                i++;
            }
        }
        private void SetParity(List<string> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                parity.Add(list[i]);
                i++;
            }
        }
        private void SetStopBit(List<string> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                stopbit.Add(list[i]);
                i++;
            }
        }
        //Public Methods
        public void CheckNewCommPort()
        {

            if (SerialConfig.CheckForNewPorts())
            {
                commports.Clear();
                SetCommPorts(SerialConfig.GetCommPorts());
            }

        }




    }
}
