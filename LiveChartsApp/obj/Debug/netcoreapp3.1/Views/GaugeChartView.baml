   M S B A M L   `   `   `  ����H  DLiveChartsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LiveChartsApp.ViewsLiveChartsApp.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      (    "LiveChartsApp.Views.GaugeChartView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:LiveChartsApp.Views     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      .��5
      �   � RowDefinitions  5   
   �� 5      $	��300��6    � ColumnDefinitions 5   
   �� 5      $	��150��6   �� 5      $	��150��6   $��* �6.   .+�5   
     LiveCharts.Wpf.Gauge  $��0��6   $��0��6!   $��5q�61      Uses360Mode$
 True��5         From$ 0Q�5      	   To$	 100Q�6      Value 5      �� *ValuesGauge1+!  LiveCharts.Wpf.AngularGauge  5   
   $��0��6   $��1��6(      	FromValue$ 50Q�6W      ToValue$	 250Q�6f      
LabelsStep$ 50Q�5      	   	TicksStep$	 25Q�6+   
   Wedge$	
 300Q�6:      TicksForeground
 �����
�������$
��Bold"�5      $��16(�6-      SectionsInnerRadius$ .5Q�5         Value 5   8   �� *ValuesGauge2+   Sections 5      #  LiveCharts.Wpf.AngularSection     	FromValue$ 50Q�6%      ToValue$	 200Q�64      Fill �#F8A7256B     5      $	 200Q�6%   $	 250Q�65    �#FF39396C   5      5       5!      