   M S B A M L   `   `   `  ����J  FTHI_BANG_LAI_XE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerCourse.THI_BANG_LAI_XE.View.LectureView.ManagerCourse  5      B    <THI_BANG_LAI_XE.View.LectureView.ManagerCourse.AddCoursePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nlocal<clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerCourse     5        N� Title$  AddCoursePage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5        $��Courses��5      $��0q�6'   $��0��6;   
������ $��20(�6a   $��1q�6o   6�   �� 5      $�� > Add Course��6   $��0��6-   $��20(�6;   $��0,3,0,0q�6I   6]   5      �� 5   
   
�������$��1��6-   $ 
Horizontal=�6:   .+�5      �� $ Vertical=�6   .+�5      �� $��🎓 courseName��6   62   �� 5      
���   �$��40��6-   $��1q�69   
������� �� CornerRadius$ 10��6`   ._�5      �� -   5        $��txtCourseName��5   6   $	��200��6   $��35��6*   $��0q�6K   
������ 6z   5      5      �� 5      $ Vertical=�6   $��20,0,0,0q�60   .+�5      �� $�� 🗓 Date Start��6   63   �� 5       
���   �$��40��6-   $��1q�69   
�������$ 10��6`   ._�5!      (  "System.Windows.Controls.DatePicker  -   5        $��txtDateStart��5!   -   $	��200��6!   $��40��6A   6O   5"      5#      �� 5%      $ Vertical=�6   $��20,0,0,0q�60   .+�5&      �� $�� 🗓 Date End��6   61   �� 5'      
���   �$��40��6-   $��1q�69   
�������$ 10��6`   ._�5(        -   5        $��
txtDateEnd��5(   -   $	��200��6!   $��40��6?   6M   5)      5*      5,      �� 5.   
   $��2��6   $��20q�6$   $��2q�60   
�������.��5/      �� -   5         ��Name$ DataExamPaper��5/   0   $ Vertical=�6   51      52      �� 53   
   $��3��6   $��Right=�6"   $��Bottom=�6>   $ 
Horizontal=�6Y   .+�54      �� -   5        $
��save��54      $��20��6$   $	��100��60   $��Right=�6<   $��Bottom=�6X   $��10q�6s   6�   55      56      57      