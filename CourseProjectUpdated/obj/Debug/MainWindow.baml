   M S B A M L   `   `   `  ����O  KCourseProjectUpdated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CourseProjectCourseProject  5   	       CourseProject.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CourseProject     5   	     � Title$  SchoolJournal��5   	   $	��400��6   $	��400��6,    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Icon$- 'StudentVisual/Resources/journal_min.png��5   	   .��5      � -   5         �Name$ MainGrid��5       � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��100 �6   .+�5   
   �� $��Вход��5      $
��Bold"�5      $��25(�5      $��Center=�5      $��Bottom=�5      $��0��5      � 5!   
   $��1��6    � ColumnDefinitions 5"      �� 5#      $	��125 �6#   �� 5$      .+�5'      �� $��0��6   $��Right=�5(      $��
Логин��5)      $
��Bold"�5*      5+      �� 5.   
   -   5         ��Name$ LoginBox��5.      $��2��5/      $��Center=�50      $	��235��51      � 53   
   $��3��6    54      �� 55      $	��130 �6#   �� 56      .+�59      �� $��0��6   $��Пароль��5:      $��Right=�5;      $
��Bold"�5<      5=      G� 5@   
   -   5         G�Name$ PsswdBox��5@      $��4��5A      $��Center=�5B      $	��235��5C      �� 5F   
   -   5        	 ��Name$	 
ErrorLabel��5F      $��6��5G      $��Center=�5H      
���  ��5I      �� 5K   
   -   5        
 ��Name$
 LoginButton��5K      $��7��5L      $��Center=�5M      $��Bottom=�5N      $��Вход��5O      $��25��5P      
������ 
������ ��5S      �� 5T       �� 
TargetType" ��6   .�5U      ��  �� Property � �� �� Value
 � � �63   �� 5V       � �� 5W      �� 5X       �� 
TargetType" ��6.   .R�5Y   "   �� #��z��6)   ._�5Z   &   �� $��Center=�67   $��Center=�6T   5[   #   5\      5^       �� Triggers 5_      P� 5`       P� Property �@J�IsMouseOver P� Value . . �5a      ��  � ��
 ����6;   �� 5b       �@J�RenderTransformOrigin$ 0.5, 0.5&�6F   �� 5c       � z� 5d   "   �� 5e   &    �� ScaleX$	 1.2Q�65    �� ScaleY$	 1.2Q�6B   5g      5h      P� 5i       � �� . . �5j      ��  � z� 5k   "   �� 5l   &   $ 1Q�65   $ 1Q�6@   5n      5o      5q      5s      5t      5u      