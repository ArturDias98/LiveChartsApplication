using System;
using System.Collections.Generic;
using Caliburn.Micro;
using System.Text;
using LiveChartsApp.Models;
using System.Linq;
using System.Timers;
using System.IO.Ports;
using System.Windows;

namespace LiveChartsApp.ViewModels
{
    public class ConnectionViewModel : Screen
    {      
        //Private Variables
        //COMM PORT->
        private SerialConfigModel SerialConfig;
        private BindableCollection<string> commports;
        private string selectedcommport;
        private int commportindex;
        //<-COMM PORT
        
        //BAUD RATE->
        private BindableCollection<int> baudrate;
        private int selectedbaudrate;
        private int baudrateindex;
        //<-BAUD RATE
        
        //PARITY->
        private BindableCollection<Parity> parity;
        private Parity selectedparity;
        private int parityindex;
        //<-PARITY
        
        //STOP BIT->
        private BindableCollection<StopBits> stopbit;
        private StopBits selectedstopbit;
        private int stopbitindex;
        //<-STOP BIT

        private bool isbuttonenable;
        private SerialPort SerialPort;

        public ConnectionViewModel()
        {
            IsButtonEnable = true;
            commportindex = 0;
            baudrateindex = 0;
            parityindex = 0;
            stopbitindex = 0;
            SerialPort = new SerialPort();
            CommPortsList = new BindableCollection<string>();
            BaudRateList = new BindableCollection<int>();
            ParityList = new BindableCollection<Parity>();
            StopBitlist = new BindableCollection<StopBits>();
            SerialConfig = new SerialConfigModel();           
            SetCommPorts(SerialConfig.GetCommPorts());
            SetBaudRates(SerialConfig.SetBaudRates());
            SetParity(SerialConfig.SetParity());
            SetStopBit(SerialConfig.SetStopBit());
        }      

        //Public Variables
        //COMM PORT->
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
        public string SelectedCommPort
        {
            get
            {
                return selectedcommport;
            }
            set
            {
                selectedcommport = value;
                IsButtonEnable = true;
                NotifyOfPropertyChange(() => SelectedCommPort);
            }
        }
        public int CommPortIndex
        {
            get
            {
                return commportindex;
            }
            set
            {
                commportindex = value;
                NotifyOfPropertyChange(() => CommPortIndex);
            }
        }
        //<-COMM PORT

        //BAUD RATE->
        public BindableCollection<int> BaudRateList
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
        public int SelectedBaudRate
        {
            get
            {
                return selectedbaudrate;
            }
            set
            {
                selectedbaudrate = value;
                IsButtonEnable = true;
                NotifyOfPropertyChange(() => SelectedBaudRate);
            }
        }
        public int BaudRateIndex
        {
            get
            {
                return baudrateindex;
            }
            set
            {
                baudrateindex = value;
                NotifyOfPropertyChange(() => BaudRateIndex);
            }
        }
        //<-BAUD RATE

        //PARITY->
        public BindableCollection<Parity> ParityList
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
        public Parity SelectedParity
        {
            get
            {
                return selectedparity;
            }
            set
            {
                selectedparity = value;
                IsButtonEnable = true;
                NotifyOfPropertyChange(() => SelectedParity);
            }
        }
        public int ParityIndex
        {
            get
            {
                return parityindex;
            }
            set
            {
                parityindex = value;
                NotifyOfPropertyChange(() => ParityIndex);
            }
        }
        //<-PARITY

        //STOP BIT->
        public BindableCollection<StopBits> StopBitlist
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
        public StopBits SelectedStopBit
        {
            get
            {
                return selectedstopbit;
            }
            set
            {
                selectedstopbit = value;
                IsButtonEnable = true;
                NotifyOfPropertyChange(() => SelectedStopBit);
            }
        }
        public int StopBitIndex
        {
            get 
            { 
                return stopbitindex; 
            }
            set 
            { 
                stopbitindex = value;
                NotifyOfPropertyChange(() => StopBitIndex);
            }
        }
        //<-STOP BIT

        public bool IsButtonEnable
        {
            get 
            { 
                return isbuttonenable; 
            }
            set
            {
                isbuttonenable = value;
                NotifyOfPropertyChange(() => IsButtonEnable);
            }
        }

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
        private void SetBaudRates(List<int> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                baudrate.Add(list[i]);
                i++;
            }
        }
        private void SetParity(List<Parity> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                parity.Add(list[i]);
                i++;
            }
        }
        private void SetStopBit(List<StopBits> list)
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
                CommPortIndex = 0;


            }

        }

        public void ConnectButtonClick()
        {
            try
            {
                IsButtonEnable = false;
                SerialPort.PortName = SelectedCommPort;
                SerialPort.BaudRate = SelectedBaudRate;
                SerialPort.Parity = SelectedParity;
                SerialPort.StopBits = SelectedStopBit;
                if (SerialPort.IsOpen)
                {
                    SerialPort.Close();
                    SerialPort.Open();

                }
                else SerialPort.Open();
            }
            catch (Exception)
            {
                if(SerialPort.IsOpen) SerialPort.Close();   
                MessageBox.Show("Cannot connect");
            }

        }

        public void CloseSerialPort()
        {
            if (SerialPort.IsOpen)
            {
                SerialPort.Close();
            }
        }



    }
}
