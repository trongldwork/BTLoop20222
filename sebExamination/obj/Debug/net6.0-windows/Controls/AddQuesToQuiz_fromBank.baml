   M S B A M L   `   `   `  ����I  EsebExamination, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sebExamination.ControlssebExamination.Controls  5      4    .sebExamination.Controls.AddQuesToQuiz_fromBank   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:sebExamination.Controls     5        � 	Resources  5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $&  \Template\SquareRadioButton.xaml?�6%   %    5      .��5      �� .+�5   
   � -   5         �Name$ title��5      $��10q�5      $��30��5      $	��Top=�5      .+�5      �� -   5         ��Name$ 	editTitle��5      $��24(�5   ,   ���#C02424$��Cambria)�5   ,   $��Medium"�5   ,   $
��Left=�6@   $
��1001��6[   #!Add from question bank at the end5      �� 5      -   5         ��Name$ 	close_btn��5      $��25��5!      $��25��6!   $��Right=�5"      
������ 
������ .��5%      �� $��../Assets/image/cross.png��6   5&      5'      �� 5)   
   $��0 1 0 0q�6   
�������$��5 5 5 5q�6>   �� 5+   
   $��20q�6   .+�5-      � $��0 0 0 30q�6   .+�5/      �� $��16(�6   
�������Select a category:52      �� 54      -   5         ��Name$ category_parent��54      $��	150 0 0 0q�55      $
��Left=�56      59      5;      d� 5=      -   5         d�Name$ SearchOption_btn��5=      $��24��5?   7   $
��auto��5@   7   $
��Left=�5A   7   
�������$��0q�5C   7   .��5E      ��  �� Orientation$ 
Horizontal=�6   .+�5G      �� $��16(�6    $��0 0 0 0q�5H   <   $��Cambria)�5I   <   $��SemiBold"�5J   <   ���#56AAD6Search option5M      �� 5N      -   5        	 ��Name$	 SearchOption_status��5N      $$��../Assets/image/arrow-down.png��5O   8   $	��2.5q�5P   8   5R      5S      �� 5U      -   5        
 ��Name$
 SearchOption_box��5U      .+�5V      �� -   5         ��Name$ Show_subcate��5V      $��0 5 0 0q�61   
�������.��5W   8   '%Also show question from subcategories5Y      �� 5Z      $��0 5 0 0q�6   
�������.��6>   Also show old question5\      5^      d� 5`      -	   5        $ QuestionContainer_btn��5`      $��24��5b   7   $
��auto��5c   7   $
��Left=�5d   7   
�������$��0q�5f   7   .��5h      �� $ 
Horizontal=�6   .+�5j      �� $��16(�6    $��0 0 0 0q�5k   <   $��Cambria)�5l   <   $��SemiBold"�5m   <   ���#56AAD6
Select all5p      �� 5q      -
   5        $	 QuestionContainer_status��5q      $$��../Assets/image/arrow-down.png��5r   8   $	��2.5q�5s   8   5u      5v      �� 5w      -   5        $ 	selectAll��5x      $��20 5 0 5q�5w      
�������.��5y   3   Select all Questions5{      �� 5|      -   5        $
 QuestionContainer��5|      5      d� 5�      -   5        $ AddQuestion_btn��5�   +      ToggleButtonStyle#���   5�      ���#0073A5$	��300��5�   +   $��30��67   $��	0 10 0 30q�5�   +   $	��Top=�6>   $
��Left=�5�      .��5�      �� $��16(�6   
�������$��cambria)�6=   #!ADD SELECTED QUESTION TO THE QUIZ5�      5�      5�      5�      5�      