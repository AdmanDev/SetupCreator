   M S B A M L   `   `   `  ����I  EGeneratedSetup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GeneratedSetupGeneratedSetup  5          GeneratedSetup.AdsViewer   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:GeneratedSetup     5      -   5        $	��360��5      $	��760��6     � 	Resources  5
       �� 
TargetType �� Property �� Value �� 
TargetType � Cursor �� 
Background �� Color �� Opacity	 �� Bullet
 �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName 
  OpenAd �� TargetProperty �� 
TargetName O� KeyTime O� Value  CloseAd9  3System.Windows.Media.Animation.EasingDoubleKeyFrame��%�  '	�       &	  �    &	 �    �� 5   
   " 	�6   .�5      ��  � �� 5      �� 5      " 	�6&   .R�5      �� $
 Hand��6*    5      �� 5   "   $ Black��62   $	 0.2Q�6@   	 5      � 5   "   $��20��6'   $��20��63   .+�5   &   �� $��
RadioOuter��6-   
������ 
�������$��2q�6p   $
 2��6�   �� 5   &   $��	RadioMark��6I   $
 1��6-   $��5q�6>   
�������$y�Hidden=�6m   5   #   ._�5      �� $��3,1,0,0q�6(   ���	#FF3E3E3E$��Calibri)�6P   $��12(�6e   �� 5      5      5       5!      P� 5"       �@d�	IsChecked$
 trueY�6;   . �5$   "   �� $ 	RadioMark��6)    � y�$ Visible=�6V   �� 5%   "   $ 
RadioOuter��6)    � �� �	#FFADADAD6X   5&      5(      5*      5+      �� 5-   
   .��5.      U� $ (UIElement.Opacity)�6,   $ 
stackPanel��6\   .\�5/      �� $ 0��6'   $ 0Q�63   �� 50      $ 0:0:1��6'   $ 1Q�67   51      52      �� 54   
   -   5        .��55      U� $ (UIElement.Opacity)�6,   $ 
stackPanel��6\   .\�56        $ 0��6'   $ 1Q�63     57      $ 0:0:1��6'   $ 0Q�67   58      59      5;       � Triggers 5<      :� 5=   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5>      �� #��[ 6   5?      .��5B      � .+�5C   
   ��  �� Orientation$ Vertical=�6   .+�5D      �� 
�������$��1q�6)   ._�5E      �� -   5         ��Name$ 
stackPanel��5E      $ Vertical=�61   .+�5F      �� -   5         ��Name$ IMG_Drawing��5F      $	��100��61   �� 5G      $
��Auto=�6#   $
��10,0q�6F   ��. $��65��6y   .��5H      �� -   5         ��Name$ LB_DrawingInfos��5H   $   $
��Wrap=�6=    �� TextAlignment$ Justify=�6Q   ���	#FFFFFBFB$��16(�6�   ��5I      �� 5J   "   $ White��62   $	 0.1Q�6@   5L      5M      �� 5N      -   5         ��Name$ 
BT_OpenUrl��5N      $��En savoir plus��61   $
��30,9q�6J   $��20(�6X   
�������
���������5O      �� 5P       �� EndPoint$ 0.5,1&�62    �� 
StartPoint$ 0.5,0&�6C   .��5Q   "   �  � Color$ 	#FF001121��6/    � Offset$ 1Q�6A   � 5R   "   $ 	#FF102840��6/   5S      5U      5V      5W      � 5Y      -   5         �Name$ WP_AdIndexs��5Y        � Orientation$  
Horizontal=�6-   $	��0,5q�6F   $��Center=�6S   .+�5Z      	� ! d� 	IsChecked$
! TrueY�6   5[      5]      5^      5_      