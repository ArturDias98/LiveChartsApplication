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
 
        private SerialConfigModel SerialConfig;
        
        private ComboboxModel<string> comboBoxcommport;
         
        private ComboboxModel<int> baudrate;
        
        private ComboboxModel<Parity> parity;

        private ComboboxModel<StopBits> stopbit;

        private bool isbuttonenable;

        private SerialPort SerialPort;

        public ConnectionViewModel()
        {
            IsButtonEnable = true;
            

            SerialPort = new SerialPort();
            SerialConfig = new SerialConfigModel();

            ComboBoxCommPort = new ComboboxModel<string>();           
            ComboBoxCommPort.List = new BindableCollection<string>();
            ComboBoxCommPort.SetItems(SerialConfig.GetCommPorts());
            ComboBoxCommPort.SelectedIndex = 0;

            ComboBoxBaudRate = new ComboboxModel<int>();
            ComboBoxBaudRate.List = new BindableCollection<int>();
            ComboBoxBaudRate.SetItems(SerialConfig.SetBaudRates());
            ComboBoxBaudRate.SelectedIndex = 0;            

            ComboBoxParity = new ComboboxModel<Parity>();
            ComboBoxParity.List = new BindableCollection<Parity>(); 
            ComboBoxParity.SetItems(SerialConfig.SetParity());
            ComboBoxParity.SelectedIndex = 0;   
            
            ComboBoxStopBit = new ComboboxModel<StopBits>();
            ComboBoxStopBit.List = new BindableCollection<StopBits>();
            ComboBoxStopBit.SetItems(SerialConfig.SetStopBit());
            ComboBoxStopBit.SelectedIndex = 0;

        }

        //Public Variables

        public ComboboxModel<string> ComboBoxCommPort
        {
            get 
            { 
                return comboBoxcommport; 
            }
            set 
            {
                comboBoxcommport = value;
                
                NotifyOfPropertyChange(() => ComboBoxCommPort);
            }
        }

        public ComboboxModel<int> ComboBoxBaudRate
        {
            get
            {
                return baudrate;
            }
            set
            {
                baudrate = value;
                
                NotifyOfPropertyChange(() => ComboBoxBaudRate);
            }
        }

        public ComboboxModel<Parity> ComboBoxParity
        {
            get
            {
                return parity;
            }
            set
            {
                parity = value;
                
                NotifyOfPropertyChange(() => ComboBoxParity);
            }
        }

        public ComboboxModel<StopBits> ComboBoxStopBit
        {
            get
            {
                return stopbit;
            }
            set
            {
                stopbit = value;
                
                NotifyOfPropertyChange(() => ComboBoxStopBit);
            }
        }             

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
       
        //Public Methods
        public void CheckNewCommPort()
        {

            if (SerialConfig.CheckForNewPorts())
            {
                comboBoxcommport.List.Clear();
                ComboBoxCommPort.SetItems(SerialConfig.GetCommPorts());
                comboBoxcommport.SelectedIndex = 0;
            }

        }

        public void ConnectButtonClick()
        {
            try
            {
                IsButtonEnable = false;
                SerialPort.PortName = ComboBoxCommPort.SelectedItem;
                SerialPort.BaudRate = ComboBoxBaudRate.SelectedItem;
                SerialPort.Parity = ComboBoxParity.SelectedItem;
                SerialPort.StopBits = ComboBoxStopBit.SelectedItem;
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
