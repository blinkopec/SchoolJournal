   M S B A M L   `   `   `  ����O  KCourseProjectUpdated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:CourseProjectUpdated.TeacherVisual.Pages(CourseProjectUpdated.TeacherVisual.Pages  5   	   @    :CourseProjectUpdated.TeacherVisual.Pages.SelectClassWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:CourseProjectUpdated.TeacherVisual.Pages     5   	     � Title$  SchoolJournal��5   	   $	��200��6   $	��200��6,    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � Icon$ journal_min.png��5   	    � 	Resources 5         ButtonClassTemplate�� 5   
   %�   &	        �� 5      .R�5      �� -   5        
������ $��75��5   3   ��5      �� *	ClassName+5   3   5      5      .��5      � -   5         �Name$ MainGrid��5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      $��40 �6   .+�5   
   �� $��0��6   $"��Выберите класс:��6   $
��Bold"�67   $��23(�6I   $��Center=�5      $��Center=�6-   $��Center=�5      $��Center=�64   �� 5    
   -   5         ��Name$ ClassItemControl��5    $   $��1��6   #��[  5!      �� 5"   
   -   5        $��Закрыть��5"      $��2��6#   $	��185��60   $��30��6<   
������ 
������ ��5%      �� 5&       �� 
TargetType" ��6   .�5'      �� 	 �� Property	 � ��
 �� Value

 � � �63   �� 5(      	 � ��
 5)      �� 5*       �� 
TargetType" ��6.   .R�5+   "   �� #��z��6)   ._�5,   &   �� $��Center=�67   $��Center=�6T   5-   #   5.      50       �� Triggers 51      P� 52       P� Property �@J�IsMouseOver P� Value . . �53      �� 	 � ��

 ����6;   �� 54      	 �@J�RenderTransformOrigin$
 0.5, 0.5&�6F   �� 55      	 � z�
 56   "   �� 57   &    �� ScaleX$	 1.2Q�65    �� ScaleY$	 1.2Q�6B   59      5:      P� 5;       � �� . . �5<      �� 	 � z�
 5=   "   �� 5>   &   $ 1Q�65   $ 1Q�6@   5@      5A      5C      5E      5F      5G      