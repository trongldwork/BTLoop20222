   M S B A M L   `   `   `  ����I  EsebExamination, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sebExamination.ControlssebExamination.Controls  5      /    )sebExamination.Controls.Add_Rand_Question   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:sebExamination.Controls     5      .��5	      � .+�5
   
   ��   �� Orientation$  Vertical=�6   .+�5      � $��50��6   $��
20 20 20 0q�6   .+�5      �� $��28(�6   ���#C02424$��Cambria)�5      $��Medium"�6)   $$��Add a random question to page ��5      5      d� 5      -   5        $��Right=�5      $	��Top=�6;   $��25��5      $��25��6"   
������ $��0q�5      .��5      �� $��\Assets\Image\cross.png��6   5      5      5      �� 5      $	��0.5q�6   ���#8888885      � 5      $��80��6   .+�5      � $��50��6   $	��150��6#   $
��Left=�5      $��Center=�66   .+�5       �� $��0,0.5,0.5,0q�6   ���#888888._�5"      �� $��Existing Category��6$   $��18(�6=   $��Ariel)�6K   $��Center=�5#   (   $��Center=�6E   
���iii�5%      5&      5'      � 5(      $��50��6   $	��150��6#   $��	165,0,0,0q�6/   $
��Left=�5)      $��Center=�6:   .+�5*      �� $��New Category��6    $��18(�64   $��Ariel)�6B   $��Center=�5+   $   $��Center=�6A   ���	#FF579D9D5,      5-      5/      �� 50      ���#888888$��1��6+   $	��0.5q�51      $��150,-30,0,0q�6/   52      � 53      $	��100��6   $	��Top=�6    .+�54      �� $��Category��6   $��18(�6,   $��Ariel)�6:   $
��Left=�55   $   $	��Top=�6?   $��20,0,0,0q�56   $   $	��100��66   
���iii�59      �� 5:      -   5         ��Name$ category_parent��5<   +   $
��Left=�5:      $	��Top=�66   $��	130 0 0 0q�5;   #   5>      �� 5?      -   5         ��Name$ Show_subcate��5@   #   $
��Left=�5?      $��Center=�66   $.��(include questions from subcategories too��5A   #   $��14(�5B   #   $��Ariel)�61   
���iii�$��20 0 0 0q�5D   #   5F      5G      � 5H      $	��100��6   $��	15,0,15,0q�6    .+�5I      �� $	��Top=�6   $
��Left=�64   $	��160��5J   (   $��50��64   $
��Wrap=�6@   $��Number of random question��5K   (   $��18(�6I   
���iii�5M      �� 5N      $$��Questions matching this filter��6   $��18(�6B   $��Ariel)�6P   $��Bottom=�5O   $   
���iii�5P      �� 5Q      -   5        $ Number_of_Rand_Ques_cb��5S   #   $
��Left=�5Q      $	��Top=�66   $��	209,0,0,0q�6N   $	��100��5R   #   $	��0.5q�6/   
�������5U      5W      o� 5X      -   5         o�Name$ paging��5Z      
������ $��	20 0 20 0q�5Y      5\      �� 5]      -   5         ��Name$ QuestionContainer��5]      $��
15,30,15,0q�5^   %   5`      d� 5b      -   5         d�Name$ AddQuestion_btn��5c   +      ToggleButtonStyle#���   5b      ���#0073A5$	��300��5f   +   $��30��67   $��
20 10 0 20q�5g   +   $	��Top=�6?   $
��Left=�5h      .��5i      �� $��16(�6   
�������$��cambria)�6=   !ADD RANDOM QUESTION TO THE QUIZ5k      5l      5n      5p      5r      