   M S B A M L   `   `   `  ����G  CSetupCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SetupCreatorSetupCreator  5   	   !    SetupCreator.MainMenuWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SetupCreator     5   	     � Title$  SetupCreator��5   	   $	��450��6   $	��800��6+      WindowsStyle#���   67    � WindowStartupLocation$ CenterScreen=�6^    � WindowStyle$
 None=�6�    � 
ResizeMode$ NoResize=�6�    � 	Resources 5	        BT_Menu_Style �� 
TargetType �� Property �� Value�� 5
   
   %  &	       �� 5      " ��6*   .�5      ��  � ��$	 180��6*   �� 5       � ��$	 180��6+   �� 5       � ��
 �����6/   �� 5       � �� �	#FF06000060   �� 5       � ��
 �   �6/   �� 5       � ��$ 30(�6-   5      5      .��5      � .+�5   
   � -   5        $	��Top=�5      ���	#FF720000.+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   .+�5      �� $L��Fpack://application:,,,/Resources/Images/Icon/SetupCreator logo PNG.png��6   $��28��6h   $
��Left=�6s   $	��Top=�6�   $��28��6�   $
��Fill=�6�   �� 5      $��Setup-Generator��6   
�������$��16(�6E   5      �� 5      -   5        	 ��Name$	 BT_ADMANSoftware��5      $��ADMAN Software-FR��6/   $��Center=�6K   $
��15,1q�6h   $��70,0,0,0q�6w   
�������
�������$��16(�6�   $��Eras ITC)�6�   $
��Bold"�6�   ��5      �� 5      
 �� EndPoint$
 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FF930606��6'    � Offset$ 0Q�69   � 5       $ 	#FF210000��6'   $ 1Q�69   5!      5#      �� 5$      $ 
Horizontal=�6   $��Right=�62   $��RightToLeft=�6N   .+�5%      �� -   5        $	 BT_CloseApp��5%      ��6.   Z� ��6D   Z� .��5&      �� $>��8pack://application:,,,/Resources/Images/Close window.png��6   $
��Fill=�6^   $��28��6m   $��28��6x   5'      5(      5)      � 5+   
   $��Center=�6   $��Center=�6/   .+�5,      �� -   5        $	 BT_New��5,      $��Nouveau��6%   #���  67   6_   �� 5-      -   5        $	 BT_Open��5-      $��Ouvrir��6&   #���  67   $��2,0,0,0q�6_   6p   5.      5/      50      