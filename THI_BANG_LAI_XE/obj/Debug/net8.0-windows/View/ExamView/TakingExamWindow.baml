   M S B A M L   `   `   `  ����J  FTHI_BANG_LAI_XE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:THI_BANG_LAI_XE.View.ExamViewTHI_BANG_LAI_XE.View.ExamView  5   	   4    .THI_BANG_LAI_XE.View.ExamView.TakingExamWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:THI_BANG_LAI_XE.View.ExamView     5   	     � Title$  TakingExamWindow��5   	    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��Stretch=�6   $��Stretch=�6)    � ColumnDefinitions 5   
   �� 5      $��* �6   5      �� 5      $	��200 �6   6-    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� -   5         ��Name$ lblTimer��5      $��20(�5      $��Right=�5      $	��Top=�5      $��10q�5      
���  ��5      �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5       �� -   5        $ ExamPaperNo��5    %   $��0��6   $��20(�6:   6J   5!      �� 5%   
   $��0��6   $��1��6%   $ Vertical=�62   .+�5&      �� ._�5'      �� -   5        $ txtQuestionDetail��5'   0   $
��Wrap=�6   $��20(�6L   $��2q�6Z   6g   5(      (� 5)      $	��400��6   .��5*      �� 
�������._�5+      �� -   5         ��Name$ ImageSource��5+      63   5,      5-      5.      �� 51   
   -   5        	 ��Name$	 RadioAnswer��51   "   $��2��6   $��0��67   $ Vertical=�6G   53      �� 54   
   $��2��6   $��1��6   
 �� CornerRadius$
 5��6.   
����� �$��0,0,20,0q�6X   $	��Top=�6j   ._�55      �� -   5        $��submit��55      
������ 
�������$��0q�6S   6�   56      �� 5:   
   $��Questtion number��6   $��1��6,   $��1��6<   6K   �� 5;   
   $��1��6   $��1��6'   $��0,20,0,0q�64   .��5<      � -   5         �Name$ QuestionPanel��5<   3   $
��Left=�6   5=      5>      5@      5A      