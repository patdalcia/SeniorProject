   M S B A M L   `   `   `  ���� D  @Organized, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Organized	Organized      Organized.courseView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:Organized     $	��300��$	��650��$	��700��$	��950��  � WindowStartupLocation$  CenterScreen=� � WindowStyle$ SingleBorderWindow=� � 	Resources    gradientBackgroundBrush �� 
StartPoint �� EndPoint � Color � Offset  navBarButtons �� 
TargetType �� Property	 �� Value  assignmentListButtons
 �� 
TargetType �� Triggers P� Property P� Value �� 	Resources��%�  &	        &	 R     &	 �     �� $	 1,0&�$ 0.5,1&�.��� $ Black��$ 0Q�� $ DimGray��$ 1Q��� " ��.���  � ��
	 ���� ��  � ��
	 � �����  � ��$		 100����  � ��$	 20(���  � ��
	 ���� ��  � ��$	 1q���  � ��$	 10q��� " ��.���  � ��
	 �������  � ��
	 � �����  � ��$	 40����  � ��$	 15(���  � ��$	 5q���  � ��	 �� "
 ��.R��� #��z��
������ $��2q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  �@J�Opacity$	 1Q���  � ��
	 �������  � ��$	 20(� ���� '��       " ��.���  �@��CornerRadius$	 5����  �@J�Opacity$	 1Q�.���  � ShowGridLines$ false��#��[   � ColumnDefinitions �� �� �� �� �� �� ��  � RowDefinitions �� �� �� �� �� �� �� �� �� �� �� .+��� $��0��$��2��$��0��$��2��$��Center=�.+��� $��Images/resizedLogo.png���� $��1��$��4��$��3�� �� Orientation$ 
Horizontal=�$��Center=�$��RightToLeft=�.+��� -   $��	Dashboard��#��[ �� -   $��Add Assignment��#��[ �� $��Course Information��$��2��$��0��$��2��$
��left=�$��
UltraLight"�
��� ���$��15,0,0,0q� J� Opacity$	 0.5Q��� $��2��$��3��$��0��$��2��
�������$��2q�$��5,30,5,5q�$	 0.5Q� �� CornerRadius$ 5�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  ._��� -    ��Name$ courseInfoPanel��$��10q��� $&�� Click Assignment to view Details��$��5��$��0��$��2��$
��left=�$��
UltraLight"�
��� ���$��15,0,0,0q�$	 0.5Q��� $��5��$��6��$��0��$��2��$��	5,30,0,10q�
�������$��2q�$	 0.5Q�$ 5��   ._��� $
��Auto=�.���� -   $ assingmentListPanel��.+��� $
��Test��#��[ �� $��Assignment Details��$��2��$��2��$��2��$
��left=�$��
UltraLight"�
��� ���$��15,0,0,0q�$	 0.5Q��� $��2��$��6��$��2��$��5��
�������$��2q�$	 0.5Q�$ 5��$��10,30,10,10q�   ._� � -     �Name$ assignmentDetailsFrame��
�������  � NavigationUIVisibility$ Hidden=��� $5��/Time Sensitive: These Assingments are DUE soon!��$��8��$��2��$��2��$
��left=�$��
UltraLight"�
��� ���$��15,0,0,0q�$	 0.5Q��� $��8��$��2��$��3��$��5��
�������$��2q�$	 0.5Q�$ 5��$��10,30,10,10q�   ._��� -   $ upcomingAssignmentsPanel��