   M S B A M L   `   `   `  ����J  FTHI_BANG_LAI_XE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerStudent/THI_BANG_LAI_XE.View.LectureView.ManagerStudent  5      H    BTHI_BANG_LAI_XE.View.LectureView.ManagerStudent.StudentManagerPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerStudent     5        N� Title$  StudentManagerPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��Students��6   $��0��6$   $��20(�61   $��1q�6?   6M   �� 5   
   $��1��6   $��5q�6"    �� Orientation$ 
Horizontal=�6-   .+�5      �� $ Vertical=�6   .+�5      �� $��🧑‍🎓 Student name��6   67   �� 5      
���   �$��40��6-   $��1q�69   
������� �� CornerRadius$ 10��6`   ._�5      �� -   5        $��txtFUllName��5   6   $	��200��6   $��35��6*   $��0q�6I   
������ 6�   5      5      �� 5      $ Vertical=�6   $��20,0,0,0q�60   .+�5      �� $�� 📞 Phone number��6   65   �� 5      
���   �$��40��6-   $��1q�69   
�������$ 10��6`   ._�5      �� -   5        $��txtPhone��5   6   $	��200��6   $��35��6*   $��0q�6F   
������ 6�   5      5      �� 5       $ Vertical=�6   $��20,0,0,0q�60   .+�5!      �� $�� 🎓 Courses��6   60   �� 5"      -   5         ��Name$ 
ListCourse��5"   3   $	��200��6   $��40��6'   
������ $��2q�6`   6�   5#      �� 5$      $ Vertical=�6   $��	20,33,0,0q�60   .+�5%      �� 
���   �$��25��6-   $��1q�69   
�������$ 10��6`   ._�5&      �� -   5        $��80��5&      $��20��6(   $��Reset��65   $��0q�6E   
������ 6�   5'      5(      5)      �� 5*   
   $��2��6   .��5+      �� .+�5,      &   System.Windows.Controls.DataGrid  -   5          Name$ DataStudent��5,   I      AutoGenerateColumns$ False��6      
IsReadOnly$
 True��67      Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6-   
   Header$
 FullName��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *
FullName+6h     5/      $	 * 6-   $
 email��67    6F   �� *Email+6b     50      $	 * 6-   $
 Phone��67    6F   �� *Phone+6b     51      $	 * 6-   $
 School��67    6G   �� *School+6d   53      54      55      �� 57   
   -   5         ��Name$ pagingStudent��57      $��3��6,   $��5q�69   $ 
Horizontal=�6D   59      5:      5;      