   M S B A M L   `   `   `  ����G  CSetupCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SetupCreatorSetupCreator  5      #    SetupCreator.Step_SetupConfig   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:SetupCreator     5      -   5        
�������$��1q�5   4   .��5      � .+�5	   
   ��   �� Orientation$  Vertical=�6   .+�5
      �� $��CONFIGURATION DU SETUP��6   $��	ExtraBold"�67   $��16(�6N   $��0,5,0,0q�6\   
�������.��5      �� $  Vertical=�6   .+�5      �� $��Chemin du build du setup��6   $
��Bold"�6A   $��16(�6S   $��0,5,0,0q�6a   
�������.��5      �� $  
Horizontal=�6%   $��Center=�6>   .+�5      �� -   5         ��Name$ TB_SetupOutputPath��5   &    �� 
IsReadOnly . $��Center=�6T   $��5q�6x   $	��429��6�   $	��429��6�   �� 5      -   5         ��Name$ BT_ChooseSetupOutputPath��5   %   $	��...��6G   $��3,1,1,1q�6V      SecondaryButtonStyle#���   6g   6�   5      5      �� 5      $��Nom du setup��6   $
��Bold"�65   $��16(�6G   $��0,5,0,0q�6U   
�������.��5      �� -   5        $ TB_SetupName��5   "   $��Center=�68   $
��Bold"�6\   $��5q�6n   $	��456��6y   5      �� 5      $��Icone du setup (.ICO)��6   $
��Bold"�6>   $��16(�6P   $��0,5,0,0q�6^   
�������.��5      �� $  
Horizontal=�6%   $��Center=�6>   .+�5      �� -   5        $ TB_IconPath��5   &    . $��Center=�6M   $��5q�6q   $	��429��6|   $	��429��6�   �� 5      -   5        $ BT_ChooseIcon��5   %   $	��...��6<   $��3,1,1,1q�6K   #���   6\   6�   5      5      �� 5      $#��Icone de l'application (.PNG)��6   $
��Bold"�6F   $��16(�6X   $��0,5,0,0q�6f   
�������.��5      �� $  
Horizontal=�6%   $��Center=�6>   .+�5      �� -   5        $ TB_AppImage��5   &    . $��Center=�6M   $��5q�6q   $	��429��6|   $	��429��6�   �� 5      -   5        $ BT_ChooseAppImage��5   %   $	��...��6@   $��3,1,1,1q�6O   #���   6`   6�   5      5       5!      5"      �� 5$      $��OPTIONS��6   $��	ExtraBold"�6(   $��16(�6?   $��0,10,0,5q�6M   
�������.��5%      �� $  Vertical=�6   .+�5&      �� $��Licence��6   $
��Bold"�60   $��16(�6B   $��0,5,0,0q�6P   
�������.��5'      �� $  
Horizontal=�6%   $��Center=�6>   .+�5(      �� -	   5        $ TB_LicencePath��5(   &    . $��Center=�6P   $��5q�6t   $	��429��6   $	��429��6�   �� 5)      -
   5        $ BT_ChooseLicence��5)   %   $	��...��6?   $��3,1,1,1q�6N   #���   6_   6�   5*      5+      �� 5,      $��Autres��6   $
��Bold"�6/   $��16(�6A   $��0,5,0,5q�6O   
�������.��5-      �� $  Vertical=�6%   .+�5.      �� -   5         ��Name$ CB_CreateDesktpShortcut��5.   '   $'��!Créer un raccourci sur le bureau��6H   $��Normal"�6s   ���	#FFFFFCFC6�   �� 5/      -   5        $ CB_StartWhenFinish��5/   '   $=��7Lancer l'application quand l'installation est terminée��6C   $��Normal"�6�   ���	#FFFFFCFC6�   50      51      54      55      56      57      58      