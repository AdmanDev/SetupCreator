   M S B A M L   `   `   `  ����G  CSetupCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SetupCreatorSetupCreator  5   	       SetupCreator.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SetupCreator     5   	     � Title$  SetupGenerator��5   	    � WindowStartupLocation$ CenterScreen=�6    $	��500��6E   $��20��6T    � SizeToContent$ WidthAndHeight=�6d    � 
ResizeMode$ CanMinimize=�6�      WindowsStyle#���   6�    � WindowStyle$
 None=�6�    � 	Resources 5
        MenuItemStyle �� 
TargetType �� Property �� Value��%A  &	       �� 5   
   " m�6&   .�5      ��  � �� �	#FF5D01016+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Italic$�6*   �� 5       � ��$ 12(�6)   �� 5       � ��$ 1,0,1,1q�60   �� 5       � ��
 �   �6,   5      5      .��5      � .+�5   
   �� 	 �� Orientation$	 Vertical=�6   .+�5      � -   5        ���	#FF720000.+�5      �� $	 
Horizontal=�6   $
��Left=�66   .+�5      �� $L��Fpack://application:,,,/Resources/Images/Icon/SetupCreator logo PNG.png��6   $��28��6l   $
��Left=�6w   $	��Top=�6�   $��28��6�   $
��Fill=�6�   �� 5      $��Setup-Generator��6   
�������$��16(�6I   5      �� 5      -   5        
 ��Name$
 BT_ADMANSoftware��5      $��ADMAN Software-FR��63   $��Center=�6O   $
��15,1q�6l   $��70,0,0,0q�6{   
�������
�������$��16(�6�   $��Eras ITC)�6�   $
��Bold"�6�   ��5      �� 5        �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5!      �  � Color$ 	#FF930606��6+    � Offset$ 0Q�6=   � 5"      $ 	#FF210000��6+   $ 1Q�6=   5#      5%      �� 5&      $	 
Horizontal=�6   $��Right=�66   $��RightToLeft=�6R   .+�5'      �� -   5        $
 BT_CloseApp��5'      ��62   Z� ��6H   Z� .��5(      �� $>��8pack://application:,,,/Resources/Images/Close window.png��6    $
��Fill=�6b   $��28��6q   $��28��6|   5)      5*      5+      �� 5-      $	��Top=�6   .+�5.      o�  J� Opacity$ 20Q�6   ���	#FF660909.@�5/      m� $��Fichier��6   #��[ 60   .@�50      m� -   5        $��Nouveau��50   #   #��[ 6N   m� 51      -   5        $��Ouvrir��51   #   #��[ 6N   m� 52      -   5        $��Enregistrer��52   #   #��[ 6S   m� 53      -   5        $��Enregistrer sous...��53   #   #��[ 6R   54      m� 56      -   5         m�Name$ MI_SetupOptions��56      $��Setup��68   $y�	Collapsed=�6G   #��[ 6^   .@�57      m� -	   5        $ MI_ExecuteSetup��57   #   $��Executer le setup��6<   #��[ 6W   6~   m� 58      -
   5        $ MI_OpenDirectory��58   #   $��Ouvrir l'emplacement��6=   #��[ 6[   6�   59      5:      � 5;      -   5         �Name$ 	GridSteps��5;      $��10q�6*   A� 5<       A� Columns$ 2��6   .+�5=      �� -   5        $
 BT_PreviousStep��5=      $��Précédant��66     StepButtonStyle#���  6J   $��18(�6t   $��Normal"�6�   ���	#FFA643436�   �� 5>      -   5        $
 BT_NextStep��5>      $��Suivant��62   #���  6D   6n   5?      5@      5A      5B      5D      