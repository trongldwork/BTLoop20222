   M S B A M L   `   `   `  ����I  EsebExamination, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sebExamination.ControlssebExamination.Controls  5      *    $sebExamination.Controls.Test_Preview   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:sebExamination.Controls     5      .��5
      � -   5          �Name$  gridGeneral��5      $	��600��5
      .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      � $��80��6   $��
20 10 20 0q�6   .+�5      �� -   5         ��Name$ TestName��5      $��42(�6.   ���#C02424$��Ariel)�5   $   $��DemiBold"�5   $   $
��Left=�6:   $��0 0 40 0q�6U   $
��Wrap=�6g   5      d� 5      -   5         d�Name$ settingTestBtn��5   K      ToggleButtonStyle#���   6   $��
0,10,10,10q�5   /   $��70��5   /   $��0q�5   /   
�������$��Right=�5   /   $	��Top=�5   /   .��5      � .+�5      �� $ ��\Assets\Image\settings.png��6    $��0,0,20,0q�5   0   �� 5      $ ��\Assets\Image\arrowRed.png��6    $��55 0 0 0q�5    0   5!      5"      5#      � 5$      $	��100��6   .+�5%      �� $��Time limit: 1 hour��6   $��Times New Roman)�5&   0   $��22(�5'   0   $��40��5(   0   $	��180��5)   0   $��Right=�5*   0   $	��Top=�5+   0   $��
0,10,125,0q�5,   0   5.      �� 5/      $"��Grading method: Last attempt��6   $��Times New Roman)�50   4   $��22(�51   4   $��40��52   4   $	��280��53   4   $��Right=�54   4   $	��Top=�55   4   $��	0,50,75,0q�56   4   58      59      � 5:      $��50��6   .+�5;      �� $��26(�5<   ,   ���#C02424$��Ariel)�5>   ,   $��DemiBold"�5?   ,   $	��650��6B   $��20 0 0 0q�5@      $
��Left=�5A   ,   #!Summary of your previous attempts5C      5D      � 5E       � ColumnDefinitions 5F      �� 5G      �� 5H       � RowDefinitions 5J      �� 5K      $��35 �6$   �� 5L      $��35 �6$   .+�5N      �� $��0��6   $��2��6&   ���	#FF459FC65O      �� 5P      $��1��6   $��2��6&   ���	#FFE0E6E65Q      �� 5R      $��0��6   $��0��5S   0   $��Attempt��5T   0   
�������$��20(�5V   0   $��Center=�5W   0   5X      �� 5Y      $��0��6   $��1��5Z   0   $��State��5[   0   
�������$��20(�5]   0   $
��Left=�5^   0   5_      �� 5`      $��1��6   $��0��5a   0   $��Preview��5b   0   
���   �$��20(�5d   0   $��Center=�5e   0   5f      �� 5g      $��1��6   $��1��5h   0   $��Nerver submitted��5i   0   
���   �$��20(�5k   0   $
��Left=�5l   0   5m      5n      � 5o      $	��100��6   .+�5p      d� -   5        $ PreviewQuiz��5q   +   #���   5p      ���#0073A5$	��250��5t   +   $��Right=�5u   +   $��50��5v   +   $��0,0,20,0q�5w   +   .��5x      �� $��24(�6    
�������$��cambria)�5y   ?   PREVIEW QUIZ NOW5{      5|      5}      5~      �� 5�   
   -   5         ��Name$ confirmation_box��5�      $y�	Collapsed=�5�      $	��300��5�      $	��550��6   
�������
���   �$��1q�5�   %   ._�5�      �� $��15q�6   .+�5�      � .+�5�      �� $��32(�6    Start attempt5�      �� 5�      -   5         ��Name$ closeConfirmationBox_btn��5�      $��25��5�      $��25��6!   $��Right=�5�      
������ 
������ .��5�      �� $��../Assets/image/cross.png��6    5�      5�      �� 5�      $��0 1 0 0q�6   
�������$��5 5 5 5q�6F   �� 5�      $��26(�5�   ,   ���#C02424$��Ariel)�5�   ,   $��DemiBold"�5�   ,   $	��650��6B   $��
20 10 0 20q�5�      $
��Left=�5�   ,   
Time limit5�      �� 5�      $��Ariel)�6   $��16(�5�      $
��20 0q�5�      
���iii�$
��Wrap=�5�      ��Your attempt will have the time limit of 1 hour. When you start, the timer will begin to count down and cannot be paused. You must finish your attemp before it exprires. Are you sure you wish to start now?5�      �� 5�      $��0 1 0 0q�6   
�������$��	5 15 5 15q�6F   �� 5�      $ 
Horizontal=�6   .+�5�      d� -   5        $ startAttempt��5�   +   #���   5�   #   ���#C02424$	��200��5�   +   $��Right=�5�   +   $��50��5�   +   $��0,0,15,0q�5�   +   .��5�      �� $��24(�6$   
�������$��cambria)�5�   ?   START ATTEMPT5�      5�      d� 5�      -   5        $ Cancel��5�   +   #���   5�   #   ���#0073A5$	��120��5�   +   $��Right=�5�   +   $��50��5�   +   $��0,0,20,0q�5�   +   .��5�      �� $��24(�6$   
�������$��cambria)�5�   ?   CANCEL5�      5�      d� 5�      -	   5        $ Export��5�   +   #���   5�   #   ���#0073A5$	��160��5�   +   $��Center=�5�   +   $��50��5�   +   .��5�      �� $��24(�6$   $��Center=�5�   $   
�������$��cambria)�5�   ?   EXPORT5�      5�      5�      5�      5�      5�      5�      