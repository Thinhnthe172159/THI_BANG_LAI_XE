   M S B A M L   `   `   `  ����J  FTHI_BANG_LAI_XE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper1THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper  5      F    @THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper.DetailQuestion   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Qlocal?clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper     5        N� Title$  DetailQuestion��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��0��6   $��1q�6    �� CornerRadius$ 5��62   
�������._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ Vertical=�6   .+�5      �� $��Enter question detail *��6   $��20(�6>   $
��Bold"�6L   
���  ��6q   �� 5      -   5         ��Name$ txtQuestionDetail��5   1   
�������$��64��6L   $	��700��6X    �� AcceptsReturn$
 True��6d    �� TextWrapping$
 Wrap=�6y   " �� VerticalScrollBarVisibility$
 Auto=�6�   6�   5      5      5      �� 5   
   $��1q�6   $��2��6%   
�������._�5      �� $ 
Horizontal=�6   $��5q�62   $��Center=�6=   .+�5      �� -   5         ��Name$ txtImageUrl��5   ^   $��30,0,0,0q�6   $	��150��6*   $	��450��67   $
��Left=�6C   ��6s   �� *
ImageUrl+6�   �� 5      $��10q�6   
���"�"�$ 5��6>   $��Right=�6P   $��Center=�6l   ._�5       �� $��Upload Image��6   
������ $��10,10,10,10q�6N   
�������$��0q�6w   6�   5!      5"      5#      �� 5%   
   -   5        $��DetailAnswerEdit��5%      $��3��6-   $ 
Horizontal=�6:   $y�Hidden=�6S   .+�5&      �� $ Vertical=�6   $	��133��60   .+�5'      �� $ Vertical=�6   $	��700��64   $	��100��6@   .+�5(      �� $��Answer Detail��6   $��20(�64   6D   �� 5)      -   5        $��	txtAnswer��5)   *   $��53��6   $��2q�6;   
����  �
�������$	��700��6~   6�   5*      �� 5+      -   5        	 ��Name$	 txtIsCorrectAnswer��5+   '   $��10q�6   $��Is Question Correct��6C   5,      5-      5.      �� 5/   
   -   5        $��txtAnswerId��5/      $y�Hidden=�6%   6;   �� 50   
   $��4��6   $ Vertical=�6"   .+�51      &   System.Windows.Controls.DataGrid  -   5        $��
DataAnswer��51   R   $	��190��6   
   AutoGenerateColumns$
 False��6$      
IsReadOnly$
 True��6@      Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$ Question detail��63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *DetailAnswer+6p   55      �� 56      $ 
Horizontal=�6   $��Right=�62   $��0,0,10,0q�6N   .+�57      �� $��2q�6   $	��100��6$   
����İ�$ 5��6N   $��40��6_   ._�58      �� -   5        $	��➕��58      
������ $��0q�6B   $��10q�6V   $
��Bold"�6c   
�������6�   59      �� 5:      $��2q�6   $	��100��6$   $��40��61   
����ح�$ 5��6T   $
��Left=�6e   ._�5;      �� -	   5        $	��➖��5;      
������ $��0q�6C   $��10q�6W   $
��Bold"�6e   
�������6�   5<      5=      �� 5>      $��10q�6   
���  ��$ 5��62   $��Right=�6D   ._�5?      �� -
   5        $��! Remove��5?      
������ $��0q�6E   $��10q�6Y   $��16(�6f   $
��Bold"�6t   
�������6�   5@      5A      5B      5C      