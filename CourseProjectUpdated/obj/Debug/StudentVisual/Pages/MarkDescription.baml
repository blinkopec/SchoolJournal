   M S B A M L   `   `   `  ����O  KCourseProjectUpdated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:CourseProjectUpdated.StudentVisual.Pages(CourseProjectUpdated.StudentVisual.Pages  5   	   >    8CourseProjectUpdated.StudentVisual.Pages.MarkDescription   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:CourseProjectUpdated.StudentVisual.Pages     5   	     � Title$  SchoolJournal��5   	   $	��200��6   $	��200��6,    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ journal_min.png��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      �� 5      $��40 �6   .+�5   
   �� $��0��6   $��Оценка��6   $��Bottom=�5      $��Center=�6+   $
��Bold"�5      � 5   
   $��1��6   .+�5      �� -   5         ��Name$ 	DateLabel��5      $
��Bold"�6'   $	��Top=�5      $
��Left=�6,   �� 5      -   5        $ 	MarkLabel��5      $
��Bold"�6'   $	��Top=�5      $��Right=�6,   5      �� 5    
   -   5         ��Name$ 	DescBlock��5       $	��185��6'   $��90��63   $��2��6?   �� 5"   
   -   5        $��Закрыть��5"      $��4��6#   $	��115��60   $��30��6<   
������ 
������ ��5$      �� 5%       �� 
TargetType" ��6   .�5&      �� 	 �� Property	 � ��
 �� Value

 � � �63   �� 5'      	 � ��
 5(      �� 5)       �� 
TargetType" ��6.   .R�5*   "   �� #��z��6)   ._�5+   &   �� $��Center=�67   $��Center=�6T   5,   #   5-      5/       �� Triggers 50      P� 51       P� Property �@J�IsMouseOver P� Value . . �52      �� 	 � ��

 ����6;   �� 53      	 �@J�RenderTransformOrigin$
 0.5, 0.5&�6F   �� 54      	 � z�
 55   "   �� 56   &    �� ScaleX$	 1.2Q�65    �� ScaleY$	 1.2Q�6B   58      59      P� 5:       � �� . . �5;      �� 	 � z�
 5<   "   �� 5=   &   $ 1Q�65   $ 1Q�6@   5?      5@      5B      5D      5E      5F      