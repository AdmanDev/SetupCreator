   M S B A M L   `   `   `  ����G  CSetupCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SetupCreatorSetupCreator  5      !    SetupCreator.AdEditorViewer   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:SetupCreator     5      -   5          >�Name$  _this��5      $	��350��6.   
���   �$��1q�6Q   $
��5,10q�6e   $��3q�6t   .��5      � .+�5	   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��Image de l'affiche��6   $
��Bold"�63   $��16(�6E   $��0,5,0,0q�6S   
�������.��5      �� $ 
Horizontal=�6   $��Center=�66   .+�5      �� -   5         ��Name$ TB_ImagePath��5       �� 
IsReadOnly . $��Center=�6�   $��5q�6�   $	��429��6�   ��64   �� *	ImagePath+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5         ��Name$ BT_ChooseImage��5      $	��...��65   $��3,1,1,1q�6D      SecondaryButtonStyle#���   6U   6�   5      5      �� 5      $��Description��6   $
��Bold"�6,   $��16(�6>   $��0,5,0,0q�6L   
�������.��5      �� -   5        $ TB_Description��5       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   $
��Left=�6�   $��Normal"�6�   $��5q�6�   $	��107��6�   ��62   �� *Description+$ OneWayToSource=�$ PropertyChanged=�6�   5      �� 5      $��Titre du lien web��6   $
��Bold"�62   $��16(�6D   $��0,5,0,0q�6R   
�������.��5      �� -   5        $ TB_UrlTitle��5      $��Center=�6�   $��Normal"�6�   $��5q�6�   ��6/   �� *
UrlTitle+$ OneWayToSource=�$ PropertyChanged=�6�   5      �� 5      $��Lien internet��6   $
��Bold"�6.   $��16(�6@   $��0,5,0,0q�6N   
�������.��5      �� -   5        $ TB_Url��5      $��Center=�6y   $��Normal"�6�   $��5q�6�   ��6*   �� *Url+$ OneWayToSource=�$ PropertyChanged=�6�   5      �� 5      -   5        $ 	BT_Delete��5      $��	Supprimer��6(   $��10q�6<     TertiaryButtonStyle#���  6H   $
��Bold"�6v   6�   5      5       5!      