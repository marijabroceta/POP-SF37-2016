   M S B A M L   `   `   `  ����M  IPOP-SF-37-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:POP_SF_37_2016_GUI.UI.Validacija POP_SF_37_2016_GUI.UI.Validacija  5   	   (    "POP_SF_37_2016_GUI.UI.AkcijaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:POP_SF_37_2016_GUI.UI.Validacija     5   	     � Title$  AkcijaWindow��5   	   $	��650��6   $	��700��6+    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ NoResize=�6\    � 	Resources 5	         ValidationError �� 
TargetType  Btn �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value  Lbl��%�  &	        &	 �     &	 `    �� 5
   
   .R�5      ]� ��. .+�5      �� 
���  ��$��15(�6-   $��Right=�6;   $��Center=�6S   Popunite polje!6�   �� 5      
���  ��$��3q�6+   ._�5      �� 5      5      5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   $��1,1,1,1q�62   
���   �
�������._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   ��  � ��
 ��  �6?   �� 5   "    � ��
 �����6?   5      5      5!      5"      �� 5#   
   " ��6   .�5$      ��  � ��$ 12(�6)   �� 5%       � ��
 �����6+   5&      5'      .��5(      � ��5)   
   �� 5*       �� ImageSource$! /Images/pozadinaZaLogin.jpg��6    � RowDefinitions 5,   
   �� 5-      $	��220 �6   �� 5.      $	��340 �6   �� 5/      .+�51   
   � $��0��6    52      �� 53      �� 54      �� 55      �� 56       � ColumnDefinitions 58      �� 59      $	��200 �6#   �� 5:      .+�5<      �� $��Naziv: ��6   $��15(�6&   $��0��65   $��0��6B   $��	0,0,0,0.2q�6R   $��Center=�6e   #��[ 6�   �� 5=      -   5        $��tbNaziv��5=      $��0��6%   $	��250��62   $��30��6>   $��2��6J   $
��Left=�6[   $��Center=�6w   .��6�   ��5>      �� 5?       �� Path$ Naziv�6    �� UpdateSourceTrigger$ PropertyChanged=�6+    �� ValidationRules 5@      7  1POP_SF_37_2016_GUI.UI.Validacija.ValidacijaString  5A      5C      .��5D        5E      ��%^   '��       �� 5F      " ��6   .�5G      ��  �@��CornerRadius$ 5��69   5H      5I      .��6%   5J      �� 5K      $��0��6   $��Popust: ��6$   $��1��67   $��15(�6D   $��Center=�6R   #��[ 6m   �� 5L      -   5        $��tbPopust��5L   L   $��1��6   $��1��6&   $	��250��64   $��30��6@   $
��Left=�6]   $��Center=�6x   $��0,12.8,0,12.4q�6�   .��6�   ��5M      �� 5N      $ Popust�6   $ PropertyChanged=�6,    5O      7  1POP_SF_37_2016_GUI.UI.Validacija.ValidacijaPopust  5P      5R      .��5S        5T      ��%^   '��       �� 5U      " ��6   .�5V      ��  �@��CornerRadius$ 5��69   5W      5X      .��6%   5Y      �� 5Z      $��2��6   $��0��6!   $��Datum pocetka akcije: ��61   $��15(�6R   $��Center=�6a   #��[ 6|   (  "System.Windows.Controls.DatePicker  5[      -   5        $��dpPocetakAkcije��5[   N   $��2��6   $��1��6&   $	��250��66   $��30��6B   $
��Left=�6�   $��Center=�6�      SelectedDate 6e   �� $ DatumPocetka�6�   �� 5\      $��3��6   $��0��6!   $��Datum zavrsetka akcije: ��61   $��15(�6T   $��Center=�6c     5]      -   5        $��dpZavrsetakAkcije��5]   N   $��3��6   $��1��6&   $	��250��66   $��30��6B   $
��Left=�6�   $��Center=�6�    6g   �� $ DatumZavrsetka�6�   5^      � 5_   
   $��1��6    5`      �� 5a      $	��200 �6#   �� 5b      $	��400 �6#   �� 5c      .+�5e      �� $��Namestaj na akciji: ��6   $��0��64   $��15(�6D   &   System.Windows.Controls.DataGrid  5f      -   5        $��dgNamestajAkcija��5f      $��1��60      AutoGenerateColumns .     CanUserAddRows .   �� SelectedIndex$ 0��6�   ��6\   �� $ IzabranaAkcija�   Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h      ,  &System.Windows.Controls.DataGridColumn   Header$ Sifra��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Namestaj.Sifra+  5i      $ Naziv��6)   $ * 68    6B   �� *Namestaj.Naziv+  5j      $ Tip namestaja��6)   $ * 6@    6J   �� *Namestaj.TipNamestaja+  5k      $
 Cena��6)   $	 100 67    6C   �� *Namestaj.JedinicnaCena+  5l      $ Kolicina��6)   $ 50 6;    6F   �� *Namestaj.KolicinaUMagacinu+5n      �� 5o      -   5        $��Dodaj��5o      #��[ 6%   $��30��6O   $��70��6[   $��2��6f   $��10,0,0,0q�6�   $	��Top=�6�   $
��Left=�6�   �� 5p      -   5        $��Obrisi��5p      #��[ 6&   $��30��6P   $��70��6\   $��2��6g   $��	10,50,0,0q�6w   $	��Top=�6�   $
��Left=�6�   5q      � 5r   
   $��2��6   .+�5s      �� -   5        $��Sacuvaj��5s      $��35��6'   $��80��63   $��519,0,0,4.6q�6T   $
��Left=�6i   $��Center=�6�   ��5t      �� 5u      " ��6   .�5v      ��  � �� 5w      �� 5x   "   " ��62   .R�5y   &   �� $ 5��6-   $��1,1,1,1q�6>   
���   �
�������._�5z   *   �� $��Center=�6;   $��Center=�6X   5{   '   	 5|   &   P� 5}   *   
 �@J�IsMouseOver . . �5~   .   ��  � ��
 ��  �6K   �� 5   .    � ��
 �����6K   5�   +   5�   #   5�      �� 5�       � {� .  66    �� Triggers 5�      ^� 5�       ^� 
Conditions 5�   "   �� 5�   &    �� Binding 60   �� $ (Validation.HasError)� �� ElementName$ tbNaziv�� �� Value	 False6s   �� 5�   &    60   �� $ (Validation.HasError)�$ tbPopust��	 False6t   .0�5�   "   ��  � {� . 6>   5�      5�      5�      �� 5�      -	   5        $��Izadji��5�      #��[ 6'   $��35��6P   $��80��6\   $��Center=�6g   $��604,0,0,4.6q�6�   5�      �� 5�   
   
���  ��$��15(�6'   $
��Left=�5�      $	��206��67   $��21��6C   $	��Top=�6O   $��
467,73,0,0q�6g   ��5�      �� $ tbPopust��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5�   g   �� 5�   
   
���  ��$��15(�6'   $
��Left=�5�      $	��206��67   $��21��6C   $	��Top=�6O   $��
467,20,0,0q�6g   ��5�      �� $ tbNaziv��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5�   g   5�      5�      