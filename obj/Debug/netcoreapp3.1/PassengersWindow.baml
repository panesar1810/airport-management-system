   M S B A M L   `   `   `  ����B  >Midterm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MidtermMidterm  5   	       Midterm.PassengersWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Midterm     5   	     � Title$  PassengersWindow��5   	   $	��450��6"   $	��800��6/    � 	Resources 5	         contextMenu m� CommandParameter �� RelativeSource �� Path��%M  &	        �� 5
   
   .@�5      m� -   5        $��Insert��5       5      ��  �� *Self+$ Parent�m� 5      -   5        $��Update��5       5      ��  �� *Self+$ Parent�m� 5      -   5        $��Delete��5       5      ��  �� *Self+$ Parent�5      5      .��5      ��  �� Orientation$ 
Horizontal=�6   ���	#FFBBDACD.+�5   
   o� -   5         o�Name$ TopMenu��5      $��20��6    $��1��6,   $��Center=�6=   $	��Top=�6Z   $��2��6r    K� ZIndex$ 1��6�   .@�5      m� $��_File��6   .@�5      m� $
��_New��6   m� 5      $��_Save��6   m� 5      -   5        $��_Quit��5      6*   5      m� 5      $��_Edit��6   .@�5      m� -   5        $��_Insert��5      6,   m� 5      -   5        $��_Update��5      6,   m� 5       -   5        $��_Delete��5       6,   5!      m� 5"      -	   5        $��_Help��5"      5#      5$      �� 5%   
   -
   5         ��Name$ LstPassengers��5%      $��67��6)   $��20,20,20,20q�64   ��6I   �� 6a   �� 5&   
   $��Customer ID��6   $��35��6&   $	��Top=�62   $��0,20,0,0q�6J   $��16(�6\   �� 5'   
   -   5        	 ��Name$	 	TxtCustID��5'      
 �� TextWrapping$

 Wrap=�6%   $	��120��69   $��0,20,0,0q�6E   $��30��6W   $	��Top=�6c   $��16(�6{   �� 5(   
   $��Flight ID
��6   $��35��6.   $��16(�6:   $	��Top=�6H   $��0,20,0,0q�6`   �� 5)   
   -   5        $	 TxtFlightID��5)      $

 Wrap=�6'   $	��120��6;   $��30��6G   $��16(�6S   $	��Top=�6a   $��0,20,0,0q�6y   �� 5*   
   -   5         ��Name$ BtnAdd��5*      $	��Add��66   $��30��6D   $��	10,1,10,1q�6P   $��Center=�6d   $	��Top=�6�   $��0,20,0,0q�6�   ���	#FF5DD13F
�������
�������$��16(�6�   �� 5+   
   -   5        $ 	BtnUpdate��5+      $��Update��6$   ���	#FF3790E4
�������
�������$��30��6s   $��0,20,0,0q�6   $	��Top=�6�   $��	10,1,10,1q�6�   $��16(�6�   6�   �� 5,   
   -   5        $ 	BtnDelete��5,      $��Delete��6$   
�������
����������	#FFD74747$��16(�6s   $��30��6�   $
��Left=�6�   $	��Top=�6�   $��0,20,0,0q�6�   $��5,1,5,1q�6�   6�   5-      5.      