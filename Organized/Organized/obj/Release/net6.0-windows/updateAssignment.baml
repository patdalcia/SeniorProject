   M S B A M L   `   `   `  ���� D  @Organized, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Organized	Organized       Organized.updateAssignment   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:Organized       � Title$  Update Course��$	��300��$	��200��$	��800��$	��500�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ SingleBorderWindow=� � 	Resources    backgroundBrush �� Color  gradientBackgroundBrush �� 
StartPoint �� EndPoint � Color � Offset	 �� 
TargetType  roundedCornerButtonStyle
 �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value �� 	Resources(  "System.Windows.Controls.DatePicker��%�  &	        &	      &	 c     '�� �    '�� F    '      �� $ Black���� $	 1,0&�$ 0.5,1&�.��� $ Black��$ 0Q�� $ DimGray��$ 1Q��� "	 ��.��� 
 � ��
 ���� �� 
 � ��
 � ����� 
 � ��$
 Bold"��� 
 � �� �� " ��.R��� #��z��
��� ���$��2q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 
 � ��$ 	ExtraBold"��� 
 � ��$ 20(� ���� '��       "	 ��.��� 
 �@��CornerRadius$ 20���� 
 �@J�Opacity$ 1Q��� "	 ��.��� 
 � ��
 � ����� 
 � ��$ 15(��� 
 � ��$ 0,0,0,10q��� 
 � ��$ Center=��� "	 ��.��� 
 � ��
 ������� 
 � ��
 � ����� 
 �@��TextAlignment$ Center=��� 
 � ��$ 25�� ���� '��       "	 ��.��� 
 �@��CornerRadius$ 10���� "	  .��� 
 � ��
 ������� 
 � ��
 � ����� 
 � ��$ 25�� ���� '��       "	 ��.��� 
 �@��CornerRadius$ 10��.���  � ShowGridLines$ False��
���   � � ColumnDefinitions �� �� �� ��  � RowDefinitions �� �� �� �� �� �� �� �� �� �� .+��� $��1��$��2��$��2��.+��� $��Images/resizedLogo.png���� $��2��$��1��$��2��$��Center=�.+��� $��Assignment Title��$��Center=��� -    ��Name$
 name������  �� Path$
 Name��� $��3��$��1��$��2��$��Center=�.+��� $��Description of Assignment��$��Center=��� -   $ description������ $ Description��� $��4��$��1��$��2��$��Center=�.+��� $��Due Date��$��Center=�  -     Name$ dueDate��   Text �� $ DueDate��� $��5��$��1��$��2��$��Center=�.+��� $��	Completed��$��Center=���  �� Orientation$ 
Horizontal=�$��Center=�.+�	� -    	�Name$ completedYes��$	��Yes�� 	� 	GroupName$ 	completed��$��Center=�
��� ���$��60��$��5q�	� -   $ completedNo��$��No��$ 	completed��$��Center=�
��� ���$��60��$��5q��� $��7��$��1��$��2��.+��� -   $��Update Assignment��#��[ $��50��