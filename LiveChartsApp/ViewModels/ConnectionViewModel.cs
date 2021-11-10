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

            ComboBoxCommPort = new ComboboxModel<string>();
            comboBoxcommport.SelectedIndex = 0;
            ComboBoxCommPort.List = new BindableCollection<string>();
            
            ComboBoxBaudRate = new ComboboxModel<int>();
            ComboBoxBaudRate.List = new BindableCollection<int>();
            baudrate.SelectedIndex = 0;

            ComboBoxParity = new ComboboxModel<Parity>();
            ComboBoxParity.List = new BindableCollection<Parity>(); 
            parity.SelectedIndex = 0;   

            ComboBoxStopBit = new ComboboxModel<StopBits>();
            ComboBoxStopBit.List = new BindableCollection<StopBits>();
            stopbit.SelectedIndex = 0;
            
            SerialConfig = new SerialConfigModel();           
            
            SetCommPorts(SerialConfig.GetCommPorts());
            SetBaudRates(SerialConfig.SetBaudRates());
            SetParity(SerialConfig.SetParity());
            SetStopBit(SerialConfig.SetStopBit());
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
        private void SetCommPorts(List<string> list)
        {
            int i = 0;
            foreach (var item in list)
            {

                comboBoxcommport.List.Add(list[i]);
                i++;
                                   
            }
        }
        private void SetBaudRates(List<int> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                baudrate.List.Add(list[i]);
                i++;
            }
        }
        private void SetParity(List<Parity> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                parity.List.Add(list[i]);
                i++;
            }
        }
        private void SetStopBit(List<StopBits> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                stopbit.List.Add(list[i]);
                i++;
            }
        }
       
        //Public Methods
        public void CheckNewCommPort()
        {

            if (SerialConfig.CheckForNewPorts())
            {
                comboBoxcommport.List.Clear();
                SetCommPorts(SerialConfig.GetCommPorts());
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
