   M S B A M L   `   `   `  ���� I  EGeneratedSetup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GeneratedSetupGeneratedSetup       GeneratedSetup.SetupWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:GeneratedSetup       � Title$  Setup�� � WindowStartupLocation$ CenterScreen=�$	��500��$	��807��$��16(� � 
ResizeMode$ NoResize=� � SizeToContent$ Height=� � WindowStyle$
 None=�
���   � J� Opacity$
 0.95Q� � AllowsTransparency . 
������� � 	Resources    ButtonStyle �� 
TargetType	 �� Property
 �� Value �� EndPoint �� 
StartPoint �� RelativeTransform �� CenterY �� CenterX �� CenterY �� CenterX �� Angle �� CenterY �� CenterX � Color � Offset  Step_License �� Orientation ��Name �� Padding �� Color �� Opacity ��Name ��Name  Step_Success ��Name 	 Step1 ��Name  ��Name! �� 
IsReadOnly 	 Step2" �Name# �Name$ � Value% � MappingMode& � IsSharedSizeScope��%�
  &	        &	 u    7   &	 &    7   &	 A    7   7   &	 #    7   �� " ��.��� 	 � ��
 �� $ 0.5,1&�$ 0.5,0&� V� .~��� $	 0.5Q�$	 0.5Q��� $	 0.5Q�$	 0.5Q��� $ 142.125Q�$	 0.5Q�$	 0.5Q�T� .��� $ 	#FFF73939��$ 0Q�� $ 	#FF6C0303��$ 1Q��� 	 � ��
 �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF00AEFF��$ 1Q�� $ 	#FF44C51E���� 	 � ��

 ������� 	 � ��$

 Bold"��� $ Vertical=�.+��� 
�������$��1q�._��� $ Vertical=�.+��� $��Visible=�$��10q�$	��260��.���� $ 
TB_Licence��-   $
��Wrap=�
�������$
 15,5q�$��Disabled=�$��Arial)�$��18(����� $ White��$
 0.15Q��� $ CB_Agree��-   $-��'J'accepte les conditions d'utilisation.�����	#FFFFF2F2�� $ BT_ValidateLicence��-   $��	Continuer��$��50,15q�$��30(�$��5q�8��  $
��Bold"�{�.  �� $ Vertical=�.+��� 
�������$��1q�._��� $ Vertical=�.+��� $ 	LB_Statut��-   $)��#L'installation a été un succès !��
�������$��34(�$��Center=�
�������$��1,0,1,1q���Z� �� $ Vertical=�$��0,90,0,0q�$��Center=�.+��� $ CB_StartApp��-   $��Lancer l'application��
�������$
��Left=��� $ CB_CreateShortcut��-   $$��Créer une icone sur le bureau��
�������$
��Left=�$��0,5,0,0q��� $ BT_FinshAndClose��-   $��Terminer��8��  $��30(�$��100,100,100,11q�$��Bottom=��� $ Vertical=�.+��� 
�������$��1q�$��Center=�._��� $ Vertical=�.+��� $ IMG_LargeIcon��-   $'��!Resources/Images/Close window.png��$��Center=�$��Center=�$��0,10,0,0q�$	��220��$	��180���� $ LB_SetupName��-	   $��Nom du logiciel��
�������$��Center=�$��18(�$��Center=�$
��Bold"�$��Century Gothic)��� $#��Emplacement de l'installation��$��
43,35,43,0q�.���� $ 
Horizontal=�$��0q�.+��� $  TB_OutputDir��-
   $	��597��! . 
���   �
���  ��$��3,3,5,3q�
���  ���� $ BT_ChooseOutputDir��-   $��
Choisir...��$
��10,1q�$��Normal"�8��  
�������$��14(��� $ 
BT_Install��-   $��	Installer��$��36(�$��
70,40,70,0q�8�� $��Copperplate Gothic Bold)��� $ Vertical=�$��Center=�.+��� $��10,10,10,30q�
�������$��1q�$	��250��._�� $" Grid_Ads��-   �� $ Vertical=�$
��75,0q�.+��� 
�������$��2q�._�� $# PB_Installation��-   $��27��
�������$$ 0Q����� $ White��$
 0.15Q����� $ 0.5,1&�$% RelativeToBoundingBox=�$ 0.5,0&�.��� $ 	#FFFF8181��� $	 Red��$ 1Q��� $ LB_InstallationDetail��-   $/��)Installation : D:\Ceci\est\un\exemple.dll��$��Center=�
��������� $ 	BT_Cancel��-   $��Annuler��8��  $��Normal"�$��18(�$��Center=�$��0,20,0,0q�& . $
��50,5q�.��� -   $" MainGrid��
���   �' � RowDefinitions' �� $	��30* ��� $
��407* �.+�� -   $��
GridHeader��$��0��.+��� $ 
Horizontal=�$��Right=�.+��� -   $ BT_CloseApp����Z� ��Z� ��Z� .���� $'��!Resources/Images/Close window.png���� $ 
Horizontal=�.+��� -   $ Img_SetupIconW���� -   $ LB_Title��$'��!Installation de [non du logiciel]��
���  ��$��Verdana)�$
��Bold"�$��17(�� -   $" 
Grid_Steps��$��1��$��15q�