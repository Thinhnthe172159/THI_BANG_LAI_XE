   M S B A M L   `   `   `  ����J  FTHI_BANG_LAI_XE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:THI_BANG_LAI_XE.ViewTHI_BANG_LAI_XE.View  5      )    #THI_BANG_LAI_XE.View.CourseListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:THI_BANG_LAI_XE.View     5        N� Title$  CourseListPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��Courses��6   $��1q�6#   $��0��6.   $��20(�6;   6K   �� 5   
   $��1��6   $��10q�6$   .��5      �� -   5         ��Name$ 
DataCourse��5      ��5      �� 5      .R�5      � ���#F5F5F5$��10q�69   5      ��5      �� 5      .R�5      �� $	��250��6!    �� Padding$ 10q�6-   
������� �� CornerRadius$ 10��6M   $��10q�6_   ._�5      �� .+�5   "   �� $��14(�6H   $
��Bold"�6V   $��0,5,0,0q�6h   ��6,   �� *
CourseName+6h   �� 5    "   $��Lecture��6(   $
��Bold"�6:   6N   �� 5!   "   $��14(�6N   $��0,5,0,0q�6\   ��6,   �� *Teacher.FullName+6\   �� 5"   "   $��Start at��6(   $
��Bold"�6;   6O   �� 5#   "   $��14(�6G   $��0,5,0,0q�6U   ��6,   �� *	StartDate+6U   �� 5$   "   $��End at��6(   $
��Bold"�69   6M   �� 5%   "   $��14(�6E   $��0,5,0,0q�6S   ��6,   �� *	EndDate+6S   �� 5'   "   -   5        $
��View��5'   )   
�������
�������$��14(�5(      $��5q�6$   $��0q�60    � Cursor$
 Hand��6D   $��0,10,0,0q�6R   6d   5)      5*      5+      5-      5/      50      51      