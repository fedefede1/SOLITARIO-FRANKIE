   M S B A M L   `   `   `  ����K  GSolitarioFrankie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SolitarioFrankieSolitarioFrankie  5   	   !    SolitarioFrankie.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SolitarioFrankie     5   	     � Title$  Solitario Frankie��5   	   $	��800��6#   $	��450��60    � 
ResizeMode$ NoResize=�6<   .��5	      � ��5
   
   �� 5       �� ImageSource$ /SfondoConCarte1.png��6   .+�5   
   �� -   5         ��Name$ imgCartaInCima��5      $��152,130,152,0q�6(   $	��200��6?   $	��Top=�6L   $	��128��6d   �� 5   
   -   5        $ imgMazzoInizialeStatica��5      $��
32,466,0,0q�61   $
��Left=�6E   $	��128��6`   $	��200��6l   $	��Top=�6y   �� 5   
   -   5        $ imgMazzoDepositoStatica��5      $
��Left=�61   $	��200��6L   $��272,466,0,0q�6Y   $	��Top=�6n   $	��128��6�   z�5      T� 5      -   5        
shakeImage��5   %   5      �� 5   
   -   5        $ imgCarta��5      $y�Visible=�6"   $	��200��67   $��
32,466,0,0q�6D   $	��Top=�6X   $
��Left=�6p   $	��128��6�   �� 5   
   -   5        $ imgCartaDeposito��5      $y�Visible=�6*   $
��Left=�6?   $	��200��6Z   $��272,466,0,0q�6g   $	��Top=�6|   $	��128��6�   �� 5   
   -   5         ��Name$ btnMazzoIniziale��5      $��Button��6+   $��32,466,290,120q�6<    J� Opacity$ 0Q�6s   �� 5   
   -   5        $ btnMazzoDeposito��5      $��Button��6+   $��290,466,32,120q�6<   $ 0Q�6s   �� 5   
   -	   5        $ btnIstruzioni��5      $
��Left=�6(   $	��Top=�6C   $��70��6[   $��70��6g   ���	#00707070$��
363,23,0,0q�6�   ��5      �� 5      $ /infomablu2.png��6    � 	Resources 5       �� 
TargetType �� Property	 �� Value��%`   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$		 500��65   5      5       5!      5"      5#      