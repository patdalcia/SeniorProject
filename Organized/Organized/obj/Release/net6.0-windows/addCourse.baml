   M S B A M L   `   `   `  ���� D  @Organized, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Organized	Organized      Organized.addCourse   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:Organized     $	��300��$	��200��$	��800��$	��500��  � WindowStartupLocation$  CenterScreen=� � WindowStyle$ SingleBorderWindow=� � 	Resources    backgroundBrush �� Color  gradientBackgroundBrush �� 
StartPoint �� EndPoint � Color � Offset �� 
TargetType  roundedCornerButtonStyle	 �� Property
 �� Value �� 
TargetType �� Triggers P� Property P� Value �� 	Resources �� Path �� Self �� RelativeSource(  "System.Windows.Controls.DatePicker  GeneralErrorStyle J� Opacity �� ElementName ��Name��%�  &	        &	      &	 c     '�� �    '�� F    '  {    &	     �� $ Black���� $	 1,0&�$ 0.5,1&�.��� $ Black��$ 0Q�� $ DimGray��$ 1Q��� " ��.��� 	 � ��

 ���� �� 	 � ��

 � ����� 	 � ��$

 Bold"��� 	 � ��
 �� " ��.R��� #��z��
��� ���$��2q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 	 � ��$
 	ExtraBold"��� 	 � ��$
 20(� ���� '��       " ��.��� 	 �@��CornerRadius$
 20���� 	 �@J�Opacity$
 1Q��� " ��.��� 	 � ��

 � ����� 	 � ��$
 15(��� 	 � ��$
 0,0,0,10q��� 	 � ��$
 Center=��� " ��.��� 	 � ��

 ������� 	 � ��

 � ����� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 25�� ���� '��       " ��.��� 	 �@��CornerRadius$
 10�� P�  �@=�HasError$
 True��. ��� 	 �@�ToolTip
 �� $) #(Validation.Errors)[0].ErrorContent�# Z �� "  .��� 	 � ��

 ������� 	 � ��

 � ����� 	 � ��$
 25�� ���� '��       " ��.��� 	 �@��CornerRadius$
 10���� " ��.��� 	 � ��

 ������� 	 � ��

 � ����� 	 �@��TextAlignment$
 Center=��� 	 � ��$
 25���� 	 �@=�ErrorTemplate
 �� .R�]� .+��� $��Bottom=�$��Center=�
���  ��$
��10pt(�$
 0.75Q����� $ placeholder��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� $ placeholder�� ���� '��       " ��.��� 	 �@��CornerRadius$
 10��.���  � ShowGridLines$ False��
���   � � ColumnDefinitions �� �� �� ��  � RowDefinitions �� �� �� �� �� �� �� �� �� �� .+��� $��1��$��2��$��2��.+��� $��Images/resizedLogo.png���� $��2��$��1��$��2��$��Center=�.+��� $��Course Title��$��Center=��� -    ��Name$
 name��#��[ ���� $
 Name� �� ValidatesOnDataErrors$
 True�� �� UpdateSourceTrigger$ PropertyChanged=��� $��3��$��1��$��2��$��Center=�.+��� $��Description of Course��$��Center=��� -   $ description��#��[ ���� $ Description�$
 True��$ PropertyChanged=��� $��4��$��1��$��2��$��Center=�.+��� $��	Professor��$��Center=��� -   $ 	professor��#��[ ���� $ 	Professor�$
 True��$ PropertyChanged=��� $��5��$��1��$��2��$��Center=�.+��� $��
Start Date��$��Center=�  -     Name$ 	startDate��   Text �� $
 True���� $��6��$��1��$��2��$��Center=�.+��� $��End Date��$��Center=�  -   $ endDate�� �� $
 True���� $��8��$��1��$��2��$��Center=�.+��� -   $��
Add Course��#��[ $��60��$��20(�