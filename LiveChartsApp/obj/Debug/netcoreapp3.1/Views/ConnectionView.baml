   M S B A M L   `   `   `  ����H  DLiveChartsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LiveChartsApp.ViewsLiveChartsApp.Views  5      C&clr-namespace:LiveChartsApp.ViewModelsLiveChartsApp.ViewModels  5	      (    "LiveChartsApp.Views.ConnectionView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:LiveChartsApp.Views     5      ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f"calhttp://caliburnmicro.com  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      7
viewmodels&clr-namespace:LiveChartsApp.ViewModels  5	      .��5      �   � ColumnDefinitions  5   
   �� 5      $��5 �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��5 �6   .+�5   
   �� $��1��6   $��2��6!   $��	Configure��61   $��Center=�6B   $��Center=�6]   $��15(�6z   �� 5    
   -   5         ��Name$ ComboBoxCommPort_List��5    0   $��2��6   $��2��6     �� SelectedItem 6O   �� *ComboBoxCommPort.SelectedItem+ �� Mode$ OneWayToSource=� �� SelectedIndex 6�   �� * ComboBoxCommPort.SelectedIndex+$ TwoWay=��� 5!   
   -   5        $ ComboBoxBaudRate_List��5!   1   $��3��6   $��2��6     6P   �� *ComboBoxBaudRate.SelectedItem+$ OneWayToSource=� 6�   �� * ComboBoxBaudRate.SelectedIndex+�� 5"   
   -   5        $ ComboBoxParity_List��5"   1   $��4��6   $��2��6     6N   �� *ComboBoxParity.SelectedItem+$ OneWayToSource=� 6�   �� *ComboBoxParity.SelectedIndex+�� 5#   
   -   5        $ ComboBoxStopBit_List��5#   1   $��5��6   $��2��6     6O   �� *ComboBoxStopBit.SelectedItem+$ OneWayToSource=� 6�   �� *ComboBoxStopBit.SelectedIndex+�� 5$   
   $��2��6   $��1��6!   $��Port: ��61   $��Center=�6?   $��Center=�6Z   �� 5%   
   $��3��6   $��1��6!   $��Baud: ��61   $��Center=�6?   $��Center=�6Z   �� 5&   
   $��4��6   $��1��6!   $��Parity: ��61   $��Center=�6A   $��Center=�6\   �� 5'   
   $��5��6   $��1��6!   $��
Stop Bit: ��61   $��Center=�6C   $��Center=�6^   �� 5(   
   -   5         ��Name$ ConnectButtonClick��5(   0   $��6��6   $��2��6    $��Connect��6L   {�6^   �� *IsButtonEnable+5/      50      51      