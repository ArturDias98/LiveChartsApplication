using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveChartsApp.Models
{
    public class ComboboxModel<T>
    {
        public BindableCollection<T> List { get; set; } 
        public T SelectedItem { get; set; } 
        public int SelectedIndex { get; set; }  
    }
}
