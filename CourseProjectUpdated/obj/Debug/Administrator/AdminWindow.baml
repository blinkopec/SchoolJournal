   M S B A M L   `   `   `  ����O  KCourseProjectUpdated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CourseProject.AdministratorCourseProject.Administrator  5   	   -    'CourseProject.Administrator.AdminWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:CourseProject.Administrator     5   	     � Title$  SchoolJournal��5   	   $	��450��6   $	��800��6,    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � -   5         �Name$ MainGrid��5       � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5   
   �� -   5         ��Name$ ButtonPanel��5      $��0��6*    �� Orientation$ Vertical=�5      .+�5      �� -   5         ��Name$ AddTeacherButton��5      
�������$	��150��5      $��0,20,0,0q�6!   $%��Добавить учителя��5   /   6J   �� 5      -   5        $ AddStudentButton��5   )   $	��150��5      $��0,20,0,0q�6!   
�������$%��Добавить ученика��5   C   6^   �� 5      $"��Редактирование��6   $��Center=�6-   $��0,15,0,0q�6Q   �� 5      
��� ���$��6q�6*    �� CornerRadius$ 10��6>   ._�5      �� $ Vertical=�6   .+�5      �� -   5        $ SelectStudentButton��5   A   
�������$	��180��65   $1��+Редактировать учеников��6^   6   �� 5      -   5        $ SelectTeacherButton��5   A   
�������$	��180��65   $1��+Редактировать учителей��6^   6   �� 5      -   5        $ SelectClassButton��5   A   
�������$	��180��65   $/��)Редактировать классов��6\   6|   �� 5       -   5        $ SelectTeacherClassButton��5    A   
�������$	��180��65   .��5!      �� $f��`Редактирование закрепленных предметов за учителями��6$   $
��Wrap=�6^   	 �� TextAlignment$	 Center=�6r   5"      �� 5#      -	   5        $$ SelectStudentTeacherItemButton��5#   A   $	��180��6   
�������$1��+Редактирование журнала��6i   6�   �� 5$      -
   5        $ SelectItemButton��5$   A   $	��180��6   
�������$5��/Редактирование предметов��6[   6~   �� 5%      -   5        $ SelectAdminButton��5%   A   $	��180��6   
�������.��5&      �� $A��;Редактирование администраторов��6$   $
��Wrap=�6J   $	 Center=�6^   5'      �� 5(      -   5        $ SeletTimeTable��5(   A   $	��180��6   
�������$7��1Редактирование расписания��6Y   6}   5)      5*      �� 5,      -   5        $ 
SaveButton��5,   5   
��� � �$	��100��6)   $��Сохранить��6I   $��0,15,0,0q�6]   6o   �� 5-      -   5        $ DeleteRowButton��5-   4   
���  ��$	��100��6'   $��Удалить��6M   6_   �� 5/      -   5        $ 
QuitButton��5/   -   
�������$��
Выйти��6A   $��0,10,0,0q�6Q   6c   50      &   System.Windows.Controls.DataGrid  52   
   -   5        
  Name$
 dg��52      $��1��6      GridLinesVisibility$	 All=�53         AlternatingRowBackground
 �����6.   55      56      