   M S B A M L   `   `   `  ����I  EsebExamination, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sebExamination.ControlssebExamination.Controls  5      $    sebExamination.Controls.Import   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:sebExamination.Controls     5      .��5	      � -   5          �Name$  	Import_uc��5	      .+�5
   
   �� $��32(�6   $��Cambria)�5   0   ���#C02424$��2��5   E   Import questions from file5      �� 5   
    �� Orientation$ Vertical=�6   $��0 60 0 0q�5   1   .+�5      d� -   5         d�Name$ import_fileFormat_btn��5      $��24��5   7   $
��auto��5   7   $
��Left=�5   7   
�������$��0q�5   7   .��5      �� $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ fileFomat_status��5      $%��../Assets/image/arrow-right.png��5   8   $	��2.5q�5   8   �� 5      $��16(�6    $��5 0 0 0q�5    <   $��Cambria)�5!   <   $��SemiBold"�5"   <   ���#C02424File format5%      5'      5)      � 5+      -   5        $  import_fileFormat_box��5+      $y�	Collapsed=�62   $
��auto��5,   /   .+�5-      �� $��cambria)�6   $��16(�5.   8   Aiken format6T   5/      �� 51      $��0 1 0 0q�6   
�������$��	5 10 5 10q�6B   d� 53      -   5        $ import_general_btn��53      $��24��55   7   $
��auto��56   7   $
��Left=�57   7   
�������$��0q�59   7   .��5;      �� $ 
Horizontal=�6   .+�5<      �� -   5        $ general_status��5<      $%��../Assets/image/arrow-right.png��5=   8   $	��2.5q�5>   8   �� 5?      $��16(�6    $��5 0 0 0q�5@   <   $��Cambria)�5A   <   $��SemiBold"�5B   <   ���#C02424	General5E      5G      5I      � 5K      -   5        $  import_general_box��5K      $y�	Collapsed=�6/   $
��auto��5L   /   .+�5M      �� $��cambria)�6   $��18(�5N   8   0.Đề bài không nói trong nút này có gì6l   5O      �� 5Q      $��0 1 0 0q�6   
�������$��	5 10 5 10q�6B   d� 5S      -   5        $ import_file_btn��5S      $��24��5U   7   $
��auto��5V   7   $
��Left=�5W   7   
�������$��0q�5Y   7   .��5[      �� $ 
Horizontal=�6   .+�5\      �� -	   5        $ file_status��5\      $$��../Assets/image/arrow-down.png��5]   8   $	��2.5q�5^   8   �� 5_      $��16(�6    $��5 0 0 0q�5`   <   $��Cambria)�5a   <   $��SemiBold"�5b   <   ���#C02424Import questions from file5e      5g      5i      � 5k      -
   5        $  import_file_box��5k      $y�Visible=�6,   $	��200��5l   /   $��0 20 0 0q�5m   /    � ColumnDefinitions 5n      �� 5o      $	��400 �6'   �� 5p      .+�5r      �� $��16(�6   5t      d� 5v      -   5        $ 
upload_Btn��5w   ;      ToggleButtonStyle#���   5v      $��1��5y   ;   $��	0,0,20,20q�5z   ;   ���#009FE5$	��200��5|   ;   $��40��5}   ;   $
��Left=�5~   ;   $	��Top=�5   ;   .��5�      �� $��20(�6    
�������$��cambria)�5�       CHOOSE A FILE...5�      5�      �� 5�      -   5        $��1q�5�      
���   �$
��auto��6A   $
��auto��6N    J� 	AllowDrop$
 True��6\   $��1��5�   5   $��0 60 0 0q�5�   5   
�������._�5�      �� -   5         ��Name$ input_field��5�   (   $-��'Kéo thả file vào đây để upload��5�   (   $��Center=�5�   (   $��Center=�5�   (   5�      5�      d� 5�      -   5        $ importQuestion_btn��5�   3   #���   5�      ���#C02424$	��100��5�   3   $��35��6?   $��Center=�5�   3   $	��Top=�5�   3   $��0 20 0 0q�5�   3   .��5�      �� $��18(�6   
�������$��cambria)�5�   4   $��Light"�5�   4   IMPORT5�      5�      �� 5�      $��Center=�6   $	��Top=�5�   0   $��0 10 0 0q�5�   0   
�������$��16(�5�   0   0.There are required fields in this form marked �� 5�   .   $��Right=�5�   0   $��15��5�   0   $!��../Assets/image/warning.png��5�   0   5�      5�      5�      5�      