   M S B A M L   `   `   `  ����M  IPOP-SF-37-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_37_2016_GUI.UIPOP_SF_37_2016_GUI.UI  5   	   4    .POP_SF_37_2016_GUI.UI.DodajUsluguProdajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_37_2016_GUI.UI     5   	     � Title$  DodajUsluguProdajaWindow��5   	   $	��400��6*   $	��600��67    � WindowStartupLocation$ CenterScreen=�6C    � 
ResizeMode$ NoResize=�6h    � 	Resources 5	       �� 
TargetType   Btn �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value  Lbl��%  &	        &	 �    �� 5
   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   $��1,1,1,1q�62   
���   �
�������._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   ��  � ��
 ��  �6?   �� 5   "    � ��
 �����6?   5      5      5      5      �� 5   
   " ��6   .�5      ��  � ��$ 12(�6)   �� 5       � ��
 �����6+   5      5      .��5       � ��5!   
   �� 5"       �� ImageSource$! /Images/pozadinaZaLogin.jpg��6    � RowDefinitions 5$   
   �� 5%      $��70 �6   �� 5&      �� 5'      $��70 �6    � ColumnDefinitions 5)   
   �� 5*      $��30 �6   �� 5+      �� 5,      $��30 �6   .+�5.   
   � $��0��6   $��1��6    5/      �� 50      $��70 �6#   �� 51      �� 52      $��70 �6#   .+�54      �� $��Pretraga��6   $��30��6'   $��60��63   $��12(�6>   $��0��6L   #��[ 6\   �� 55      -   5        $��
tbPretraga��55      $��30��6(   $��12(�64   $��1��6B   .��6R    56      ��%^   '��       �� 57      " ��6   .�58      ��  �@��CornerRadius$ 5��69   59      5:      .��6%   5;      �� 5<      -   5        $��Pretrazi��5<      #��[  6(   $��2��6Q   $��30��6a   $��60��6m   6x   5=      � 5>   
   $��1��6   $��1��6    5?      �� 5@      $��40 �6    �� 5A      .+�5D      �� $��Dodatna usluga��6   $��30��6-   $	��100��69   $��0��6E   $
��Left=�6R   #��[ 6m   &   System.Windows.Controls.DataGrid  5E      -   5        $��dgUsluga��5E   M   $��1��6      AutoGenerateColumns .  $	��250��6@      CanUserAddRows .   �� SelectedIndex$ 0��6�   ��6]   ��  �� Path$ DodatnaUslugaZaProdaju�   Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Naziv+  5H      $
 Cena��6)   $ * 67    6A   �� *Cena+5J      5L      � 5M   
   $��2��6   $��1��6   .+�5N      �� -   5        $��btnDodaj��5N   %   $��Dodaj��6   #��[  65   $��30��6^   $��70��6j   $��Right=�6�   5O      5P      5Q      