   M S B A M L   `   `   `  ���� G  CSetupCreator, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null+clr-namespace:SetupCreatorSetupCreator  !    SetupCreator.AdEditorViewer   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:SetupCreator     -     >�Name$  _this��$	��350��
���   �$��1q�$
��5,10q�$��3q�.��� .+���  �� Orientation$ Vertical=�.+��� $��Image de l'affiche��$
��Bold"�$��16(�$��0,5,0,0q�
�������.���� $ 
Horizontal=�$��Center=�.+��� -    ��Name$ TB_ImagePath�� �� 
IsReadOnly . $��Center=�$��5q�$	��429������ *	ImagePath+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ BT_ChooseImage��$	��...��$��3,1,1,1q�   SecondaryButtonStyle#���   �� $��Description��$
��Bold"�$��16(�$��0,5,0,0q�
�������.���� -   $ TB_Description�� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�$
��Left=�$��Normal"�$��5q�$	��107������ *Description+$ OneWayToSource=�$ PropertyChanged=��� $��Titre du lien web��$
��Bold"�$��16(�$��0,5,0,0q�
�������.���� -   $ TB_UrlTitle��$��Center=�$��Normal"�$��5q����� *
UrlTitle+$ OneWayToSource=�$ PropertyChanged=��� $��Lien internet��$
��Bold"�$��16(�$��0,5,0,0q�
�������.���� -   $ TB_Url��$��Center=�$��Normal"�$��5q����� *Url+$ OneWayToSource=�$ PropertyChanged=��� -   $ 	BT_Delete��$��	Supprimer��$��10q�  TertiaryButtonStyle#���  $
��Bold"�