   M S B A M L   `   `   `  ����J  FTHI_BANG_LAI_XE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper1THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper  5   	   D    >THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper.AddExamPaper   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Qlocal?clr-namespace:THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper     5   	     � Title$  AddExamPaper��5   	   $	��750��6   $
��1200��6+    � WindowStartupLocation$ CenterScreen=�6:   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   6.   �� 5      $��* �6   6+   .+�5   
   �� 
�������$��0��6)   ._�5      ��  �� Orientation$ Vertical=�6   
������ .+�5      �� $��Center=�6   $��30(�69   $��5q�6G   
����  �$
��Bold"�6h   $��Question No��6z   6�   �� 5      ���#614bd4$��0q�6.    �� CornerRadius$ 8��6B   $��6q�6S   ._�5      �� -   5        $��Add Question ➕��5      $
��Auto��66   $��10q�6D   
�������$
��Bold"�6d   
������ $��0q�6�   6�   5      &   System.Windows.Controls.DataGrid  5      -   5        $��	DataQuest��5   �   $��8,0,0,0q�6   $��Center=�6,   $	��Top=�6I   $��0q�6a   
������    AutoGenerateColumns$ False��6�      
IsReadOnly$
 True��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6-   	   Header$	 
Quest List��69   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6M   �� *	questNo+6k   5      5      5       � 5   
   -   5          �Name$ ContentFrame��5        � NavigationUIVisibility$ Hidden=�5   	   $��1��5   	   5       5!      