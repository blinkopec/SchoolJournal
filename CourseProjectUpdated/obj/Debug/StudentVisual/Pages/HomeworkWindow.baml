   M S B A M L   `   `   `  ����O  KCourseProjectUpdated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:CourseProjectUpdated.StudentVisual.Pages(CourseProjectUpdated.StudentVisual.Pages  5   	   =    7CourseProjectUpdated.StudentVisual.Pages.HomeworkWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:CourseProjectUpdated.StudentVisual.Pages     5   	     � Title$  SchoolJournal��5   	   $	��200��6   $	��200��6,    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � Icon$ journal_min.png��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $��20 �6   �� 5      �� 5      $��20 �6   .+�5   
   �� $��0��6   $<��6Домашнее задание по предмету:��6   $��12(�5      $
��Bold"�6   $��Center=�5      $	��200��6.   �� 5   
   -   5         ��Name$ ItemTittleLabel��5      $��1��5      $��12(�5   *   $
��Bold"�68   $��Center=�5      $	��200��65   �� 5   
   -   5        $ 	DateLabel��5      $��2��6#   $��9(�5      $
��Left=�6   $	��Top=�68   �� 5   
   -   5         ��Name$ DescriptionBlock��5      $��3��6.   $��Italic)�6;   $	��175��5      $	��105��5      $
��Wrap=�5      �� 5!   
   -   5        $��Center=�5!      $��Bottom=�6.   $��Закрыть��6I   $��4��6[   
������ 
������ ��5#      �� 5$       �� 
TargetType" ��6   .�5%      ��  �� Property � ��	 �� Value
	 � � �63   �� 5&       � ��	 5'      �� 5(      
 �� 
TargetType"
 ��6.   .R�5)   "   �� #��z��6)   ._�5*   &   �� $��Center=�67   $��Center=�6T   5+   #   5,      5.       �� Triggers 5/      P� 50       P� Property �@J�IsMouseOver P� Value . . �51      ��  � ��
	 ����6;   �� 52       �@J�RenderTransformOrigin$	 0.5, 0.5&�6F   �� 53       � z�	 54   "   �� 55   &    �� ScaleX$	 1.2Q�65    �� ScaleY$	 1.2Q�6B   57      58      P� 59       � �� . . �5:      ��  � z�	 5;   "   �� 5<   &   $ 1Q�65   $ 1Q�6@   5>      5?      5A      5C      5D      5E      