   M S B A M L   `   `   `  ����M  IPOP-SF-37-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:POP_SF_37_2016_GUI.UI.Validacija POP_SF_37_2016_GUI.UI.Validacija  5   	   .    (POP_SF_37_2016_GUI.UI.TipNamestajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:POP_SF_37_2016_GUI.UI.Validacija     5   	     � Title$  TipNamestajaWindow��5   	   $	��160��6$   $	��400��61    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ NoResize=�6b    � 	Resources 5	         ValidationError �� 
TargetType  Btn �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value  Lbl��%�  &	        &	 �     &	 a    �� 5
   
   .R�5      ]� ��. .+�5      �� 
���  ��$��15(�6-   $��Bottom=�6;   $��Center=�6T   Popunite polje!6�   �� 5      
���  ��$��3q�6+   ._�5      �� 5      5      5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   $��1,1,1,1q�62   
���   �
�������._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   ��  � ��
 ��  �6?   �� 5   "    � ��
 �����6?   5      5      5!      5"      �� 5#   
   " ��6   .�5$      ��  � ��$ 12(�6)   �� 5%       � ��
 �����6+   5&      5'      .��5(      � ��5)   
   �� 5*       �� ImageSource$! /Images/pozadinaZaLogin.jpg��6    � ColumnDefinitions 5,   
   �� 5-      $	��100 �6   �� 5.      $	��300 �6    � RowDefinitions 50   
   �� 51      $��80 �6   �� 52      $��80 �6   .+�54   
   �� $��0��6   $��0��6   $��Naziv: ��6-   $��15(�6?   $
��Left=�6M   $��Center=�6h   #��[ 6�   �� 55   
   -   5        $��
tbTipNaziv��55   G   $��0��6   $��1��6   $��35��6/   $	��280��6;    =� ErrorTemplate# [  6Y   $
��Left=�6�   $��Center=�6�   .��6�   ��56      �� 57       �� Path$ Naziv�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 58      7  1POP_SF_37_2016_GUI.UI.Validacija.ValidacijaString  59      5;      .��5<       5=      ��%^   '��       �� 5>      " ��6   .�5?      ��  �@��CornerRadius$ 5��65   5@      5A      .��6!   5B      �� 5C   
   -   5        $��Sacuvaj��5C      $��1��6$   $��30��6K   $��60��6W   $��1��6b   $��
155,10,0,0q�6o   $
��Left=�6�   $	��Top=�6�   ��5D      �� 5E      " ��6   .�5F      ��  � �� 5G      �� 5H      " ��6.   .R�5I   "   �� $ 5��6)   $��1,1,1,1q�6:   
���   �
�������._�5J   &   �� $��Center=�67   $��Center=�6T   5K   #   	 5L   "   P� 5M   &   
 �@J�IsMouseOver . . �5N   *   ��  � ��
 ��  �6G   �� 5O   *    � ��
 �����6G   5P   '   5R      5T      �� 5U       � {� .  62    �� Triggers 5V      ^� 5W       ^� 
Conditions 5X      �� 5Y   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ 
tbTipNaziv�� �� Value	 False6r   .0�5[      ��  � {� . 6:   5\      5^      5`      �� 5a   
   -   5        $��1��5a      $��Izadji��6!   #��[ 62   $��30��6s   $��60��6   $��1��6�   $��	0,10,20,0q�6�   $��Right=�6�   $	��Top=�6�   5b      5c      