   M S B A M L   `   `   `  ����O  KCourseProjectUpdated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CourseProjectUpdated.TeacherVisual"CourseProjectUpdated.TeacherVisual  5   	   3    -CourseProjectUpdated.TeacherVisual.MarkWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:CourseProjectUpdated.TeacherVisual     5   	     � Title$  SchoolJournal��5   	   $	��450��6   $	��200��6,    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ Resources/journal_min.png��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��30 �6   �� 5      �� 5      $��50 �6   .+�5   
   �� $��Оценка��6   $��Center=�5      $��Bottom=�6-   $��0��5      $��24(�5      $
��Bold"�6   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5       �� -   5         ��Name$ DateBox��5       $��0��6'   $
��Bold"�67   $
��Left=�5!      $	��Top=�6+   �� 5"      -   5         ��Name$ MarkBox��5"      $��1��6(   $
��Bold"�5#      $	��Top=�6&   $��Right=�5$      5%      �� 5'   
   -   5        $ DescriptionMarkBox��5'      $��2��6.   $	��185��5(      $	��295��6    $��Italic)�5)      �� 5*   
   	 �� Orientation$	 
Horizontal=�6   $��3��6.   .+�5+      �� -   5        
 ��Name$
 CloseWindowButton��5+      $��Закрыть��60   $��25��6B   $��75��6N   6Y   �� 5-      $	 Vertical=�6   $��50,0,0,0q�60   .+�5.      �� -   5        $��Сохранить��5.      $��75��6-   $��25��68   6D   �� 5/      -   5        $��Удалить��5/      $��25��6+   67   50      51      52      53      