   M S B A M L   `   `   `  ����J  FTHI_BANG_LAI_XE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerExam,THI_BANG_LAI_XE.View.LectureView.ManagerExam  5      A    ;THI_BANG_LAI_XE.View.LectureView.ManagerExam.DetailExamPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerExam     5        N� Title$  DetailExamPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5        $��Exams��5      $��0q�6%   $��0��69   
������ $��20(�6_   $��1q�6m   6�   �� 5      $�� > Exam Detail��6   $��0��6.   $��20(�6<   $��0,3,0,0q�6J   6^   5      �� 5   
   
�������$��1��6-   $ 
Horizontal=�6:   .+�5      �� $ Vertical=�6   .+�5      �� $��	🚪 Room��6   6,   �� 5      
���   �$��40��6-   $��1q�69   
������� �� CornerRadius$ 10��6`   ._�5      �� -   5        $��txtRoomName��5   6   $	��200��6   $��35��6*   $��0q�6I   
������ 6x   5      5      �� 5      $ Vertical=�6   $��20,0,0,0q�60   .+�5      �� $�� 🎓 Courses��6   60   �� 5      -   5         ��Name$ 
ListCourse��5   3   $	��200��6   $��40��6'   
������ $��2q�6`   6v   5       �� 5!      $ Vertical=�6   $��20,0,0,0q�60   .+�5"      �� $�� 🗓 Date start��6   63   �� 5#      
���   �$��40��6-   $��1q�69   
�������$ 10��6`   ._�5$      (  "System.Windows.Controls.DatePicker  -   5        $��txtDateStart��5$   A   $��0q�6!   $	��200��65   $��40��6U   6c   5%      5&      5(      �� 5*   
   $��2��6   $��20q�6$   $��2q�60   
�������.��5+      �� -   5         ��Name$ DataExamPaper��5+   0   $ Vertical=�6   5-      5.      �� 5/   
   $��3��6   $��Right=�6"   $��Bottom=�6>   $ 
Horizontal=�6Y   .+�50      �� -   5        $��
Add as new��50      $��20��6*   $	��100��66   $��Right=�6B   $��Bottom=�6^   $��10q�6y   6�   �� 51      -   5        $��Remove��51      $��20��6&   $	��100��62   $��Right=�6>   $��Bottom=�6Z   $��10q�6u   6�   �� 52      -   5        $
��save��52      $��20��6$   $	��100��60   $��Right=�6<   $��Bottom=�6X   $��10q�6s   6�   53      54      55      