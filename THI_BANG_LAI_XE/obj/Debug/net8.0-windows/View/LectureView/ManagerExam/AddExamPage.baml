   M S B A M L   `   `   `  ����J  FTHI_BANG_LAI_XE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerExam,THI_BANG_LAI_XE.View.LectureView.ManagerExam  5      >    8THI_BANG_LAI_XE.View.LectureView.ManagerExam.AddExamPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerExam     5        N� Title$  AddExamPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5        $��Exams��5      $��0q�6%   $��0��69   
������ $��20(�6_   $��1q�6m   6�   �� 5      $�� > Add Exam��6   $��0��6+   $��20(�69   $��0,3,0,0q�6G   6[   5      �� 5   
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
Horizontal=�6Y   .+�50      �� -   5        $	��Add��50      $��20��6#   $	��100��6/   $��Right=�6;   $��Bottom=�6W   $��10q�6r   6�   52      53      54      