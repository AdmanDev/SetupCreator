   M S B A M L   `   `   `  ����G  CSetupCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SetupCreatorSetupCreator  5           SetupCreator.StepAppFolder   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:SetupCreator     5      -   5        
�������$��1q�5   4   .��5      � .+�5	   
   ��   �� Orientation$  Vertical=�6   .+�5
      �� $%��Dossier parent de l'application��6   $
��Bold"�6@   $��16(�6R   $��0,5,0,0q�6`   
�������.��5      �� $  Vertical=�6   .+�5      �� -   5         ��Name$ CBB_DefaultsBaseFolders��5      $
��15,3q�6@   $��Normal"�6N   $��Center=�6b   .@�5      �� $��Program Files Folder��6'    �� 
IsSelected . 6F   �� 5      $��Bureau��6'   �� 5      $��Personnaliser��6'   5      �� 5      $  
Horizontal=�6!   $��Center=�6:   .+�5      �� -   5         ��Name$ TB_BaseFolder��5   "    �� 
IsReadOnly . $��Center=�6K   $��5q�6o   $	��429��6z   $	��429��6�   �� 5      -   5         ��Name$ BT_ChooseBaseFolder��5   !   $	��...��6>   {�.  $��3,1,1,1q�6^      SecondaryButtonStyle#���   6o   6�   5      5      5      �� 5      $%��Nom du dossier de l'application��6   $
��Bold"�6@   $��16(�6R   $��0,5,0,0q�6`   
�������.��5      �� -   5        $ TB_AppFolderName��5      $��Center=�64   $��5q�6X   $	��206��6c   5      �� 5      $��Options��6   $
��Bold"�6(   $��16(�6:   $��0,5,0,0q�6H   
�������.��5      �� $  Vertical=�6   $��5q�64   .+�5      �� -   5         ��Name$! CB_AllowUserChangeAppFolder��5      $D��>Autoriser l'utilisateur à changer le dossier de l'application��6D   
�������6�   5      5      5       5!      5"      