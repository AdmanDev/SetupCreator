   M S B A M L   `   `   `  ���� G  CSetupCreator, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null+clr-namespace:SetupCreatorSetupCreator  #    SetupCreator.Step_SetupConfig   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:SetupCreator     -   
�������$��1q�.��� .+���   �� Orientation$  Vertical=�.+��� $��CONFIGURATION DU SETUP��$��	ExtraBold"�$��16(�$��0,5,0,0q�
�������.���� $  Vertical=�.+��� $��Chemin du build du setup��$
��Bold"�$��16(�$��0,5,0,0q�
�������.���� $  
Horizontal=�$��Center=�.+��� -    ��Name$ TB_SetupOutputPath�� �� 
IsReadOnly . $��Center=�$��5q�$	��429��$	��429���� -    ��Name$ BT_ChooseSetupOutputPath��$	��...��$��3,1,1,1q�   SecondaryButtonStyle#���   �� $��Nom du setup��$
��Bold"�$��16(�$��0,5,0,0q�
�������.���� -   $ TB_SetupName��$��Center=�$
��Bold"�$��5q�$	��456���� $��Icone du setup (.ICO)��$
��Bold"�$��16(�$��0,5,0,0q�
�������.���� $  
Horizontal=�$��Center=�.+��� -   $ TB_IconPath�� . $��Center=�$��5q�$	��429��$	��429���� -   $ BT_ChooseIcon��$	��...��$��3,1,1,1q�#���   �� $#��Icone de l'application (.PNG)��$
��Bold"�$��16(�$��0,5,0,0q�
�������.���� $  
Horizontal=�$��Center=�.+��� -   $ TB_AppImage�� . $��Center=�$��5q�$	��429��$	��429���� -   $ BT_ChooseAppImage��$	��...��$��3,1,1,1q�#���   �� $��OPTIONS��$��	ExtraBold"�$��16(�$��0,10,0,5q�
�������.���� $  Vertical=�.+��� $��Licence��$
��Bold"�$��16(�$��0,5,0,0q�
�������.���� $  
Horizontal=�$��Center=�.+��� -	   $ TB_LicencePath�� . $��Center=�$��5q�$	��429��$	��429���� -
   $ BT_ChooseLicence��$	��...��$��3,1,1,1q�#���   �� $��Autres��$
��Bold"�$��16(�$��0,5,0,5q�
�������.���� $  Vertical=�.+��� -    ��Name$ CB_CreateDesktpShortcut��$'��!Créer un raccourci sur le bureau��$��Normal"����	#FFFFFCFC�� -   $ CB_StartWhenFinish��$=��7Lancer l'application quand l'installation est terminée��$��Normal"����	#FFFFFCFC