   M S B A M L   `   `   `  ���� G  CSetupCreator, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null+clr-namespace:SetupCreatorSetupCreator      SetupCreator.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:SetupCreator       � Title$  SetupGenerator�� � WindowStartupLocation$ CenterScreen=�$	��500��$��20�� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ CanMinimize=�   WindowsStyle#���    � WindowStyle$
 None=� � 	Resources   MenuItemStyle �� 
TargetType �� Property �� Value��%�   &	       �� " m�.���  � �� �	#FF5D0101��  � ��
 �������  � ��$
 Bold"���  � ��$ Italic$���  � ��$ 12(���  � ��$ 1,0,1,1q���  � ��
 �   �.��� .+��� 	 �� Orientation$	 Vertical=�.+�� -   ���	#FF720000.+��� $	 
Horizontal=�$
��Left=�.+��� $L��Fpack://application:,,,/Resources/Images/Icon/SetupCreator logo PNG.png��$��28��$
��Left=�$	��Top=�$��28��$
��Fill=��� $��SetupCreator��
�������$��16(��� -   
 ��Name$
 BT_ADMANSoftware��$��ADMAN Software-FR��$��Center=�$
��15,1q�$��70,0,0,0q�
�������
�������$��16(�$��Eras ITC)�$
��Bold"�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF930606�� � Offset$ 0Q�� $ 	#FF210000��$ 1Q��� $	 
Horizontal=�$��Right=�$��RightToLeft=�.+��� -   $
 BT_CloseApp����Z� ��Z� .���� $>��8pack://application:,,,/Resources/Images/Close window.png��$
��Fill=�$��28��$��28���� $	��Top=�.+�o�  J� Opacity$ 20Q����	#FF660909.@�m� $��Fichier��#��[ .@�m� -   $��Nouveau��#��[ m� -   $��Ouvrir��#��[ m� -   $��Enregistrer��#��[ m� -   $��Enregistrer sous...��#��[ m� -    m�Name$ MI_SetupOptions��$��Setup��$y�	Collapsed=�#��[ .@�m� -	   $ MI_ExecuteSetup��$��Executer le setup��#��[ m� -
   $ MI_OpenDirectory��$��Ouvrir l'emplacement��#��[ � -    �Name$ 	GridSteps��$��10q�A� -    A�Name$ Grid_ButtonsSteps�� A� Columns$ 2��.+��� -   $
 BT_PreviousStep��$��Précédant��  StepButtonStyle#���  $��18(�$��Normal"����	#FFA64343�� -   $
 BT_NextStep��$��Suivant��#���  