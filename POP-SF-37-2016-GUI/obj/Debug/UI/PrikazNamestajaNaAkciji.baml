   M S B A M L   `   `   `  ����M  IPOP-SF-37-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_37_2016_GUI.UIPOP_SF_37_2016_GUI.UI  5   	   3    -POP_SF_37_2016_GUI.UI.PrikazNamestajaNaAkciji   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_37_2016_GUI.UI     5   	     � Title$  PrikazNamestajaNaAkciji��5   	   $	��550��6)   $	��600��66    � WindowStartupLocation$ CenterScreen=�6B    � 
ResizeMode$ NoResize=�6g    � 	Resources 5	       �� 
TargetType   Btn �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value��%�  &	        �� 5
   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   $��1,1,1,1q�62   
���   �
�������._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   ��  � ��
 ��  �6?   �� 5   "    � ��
 �����6?   5      5      5      5      5      .��5      � ��5   
   �� 5       �� ImageSource$! /Images/pozadinaZaLogin.jpg��6    � RowDefinitions 5    
   �� 5"      �� 5#      $��60 �6   .+�5%   
   � $��0��6    � ColumnDefinitions 5&      �� 5'      $��30 �6#   �� 5(      �� 5)      $��30 �6#    5+      �� 5-      $��30 �6    �� 5.      .+�50      &   System.Windows.Controls.DataGrid  -   5        $��dgNamestajAkcija��50      $��1��6/   $��1��6?      
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .     Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Namestaj.Naziv+  53      $ TipNamestaja��6)   $ * 6?    6I   �� *Namestaj.TipNamestaja+  54      $
 Cena��6)   $ * 67    6A   �� *Namestaj.JedinicnaCena+  55      $ CenaNaAkciji��6)   $ * 6?    6I   �� *Namestaj.CenaNaAkciji+  56      $ Akcija��6)   $ * 69    6C   �� *Namestaj.AkcijskaProdaja+58      5:      � 5;   
   $��1��6   .+�5<      �� $��Izadji��6   $��30��6&   $��70��62   #��[  6=   $��Right=�6f   $��
0,15,31,15q�6�   5=      5>      5?      