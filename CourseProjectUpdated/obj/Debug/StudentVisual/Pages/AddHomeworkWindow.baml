   M S B A M L   `   `   `  ����O  KCourseProjectUpdated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:CourseProjectUpdated.StudentVisual.Pages(CourseProjectUpdated.StudentVisual.Pages  5   	   @    :CourseProjectUpdated.StudentVisual.Pages.AddHomeworkWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:CourseProjectUpdated.StudentVisual.Pages     5   	     � Title$  SchoolJournal��5   	   $	��200��6   $	��200��6,    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Icon$ journal_min.png��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      �� 5      $��40 �6   .+�5   
   �� $��0��6   $<��6Добавление домашнего задания��6   $��Center=�5      $��Bottom=�6-   $
��Bold"�5      $��11(�6"   �� 5   
   -   5         ��Name$ 	DateLabel��5      $��1��6#   $
��Left=�5      $	��Top=�6+   $
��Bold"�5      �� 5   
   -   5         ��Name$ DescBox��5      $��2��6#   $	��185��5      $��90��6   � 5   
   $��3��6    � ColumnDefinitions 5       �� 5!      �� 5"      .+�5%      �� -   5        $��0��5%      $��Закрыть��6%   $��70��5&      $��30��6    $
��Left=�5'      
������ 
������ ��5)      �� 5*       �� 
TargetType" ��6   .�5+      �� 	 �� Property	 � ��
 �� Value

 � � �67   �� 5,      	 � ��
 5-      �� 5.   "    �� 
TargetType" ��62   .R�5/   &   �� #��z��6-   ._�50   *   �� $��Center=�6;   $��Center=�6X   51   '   52   #   54       �� Triggers 55      P� 56       P� Property �@J�IsMouseOver P� Value . . �57   "   �� 	 � ��

 ����6?   �� 58   "   	 �@J�RenderTransformOrigin$
 0.5, 0.5&�6J   �� 59   "   	 � z�
 5:   &   �� 5;   *    �� ScaleX$	 1.2Q�69    �� ScaleY$	 1.2Q�6F   5=   #   5>      P� 5?       � �� . . �5@   "   �� 	 � z�
 5A   &   �� 5B   *   $ 1Q�69   $ 1Q�6D   5D   #   5E      5G      5I      �� 5K      -   5        $��1��5K      $��Сохранить��6%   $��70��5L      $��30��6    $��Right=�5M      
������ 
������ ��5O      �� 5P      " ��6   .�5Q      �� 	 � ��

 � � �67   �� 5R      	 � ��
 5S      �� 5T   "   " ��62   .R�5U   &   �� #��z��6-   ._�5V   *   �� $��Center=�6;   $��Center=�6X   5W   '   5X   #   5Z       5[      P� 5\       �@J�IsMouseOver . . �5]   "   �� 	 � ��

 ����6?   �� 5^   "   	 �@J�RenderTransformOrigin$
 0.5, 0.5&�6J   �� 5_   "   	 � z�
 5`   &   �� 5a   *   $	 1.2Q�69   $	 1.2Q�6F   5c   #   5d      P� 5e       � �� . . �5f   "   �� 	 � z�
 5g   &   �� 5h   *   $ 1Q�69   $ 1Q�6D   5j   #   5k      5m      5o      5p      5q      5r      