   M S B A M L   `   `   `  ����   EmailClient!    EmailClient.EditEmailWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
Edit Email��$	��600��$	��800��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��1�� �� Orientation$ Vertical=�$��10q�.+���    DefaultLabelStyle#��[  $��Subject:��$��	10,00,0,0q�$	��Top=�$
��Left=��� -    ��Name$ 
txtSubject��  DefaultTextBoxStyle#��[ ���� *	Subject+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� #��[  $	��To:��$��10,0,0,0q�$	��Top=�$
��Left=��� -   $ txtReceiver��#��[ ���� *
Receiver+$ TwoWay=�$ PropertyChanged=��� #��[  $	��Cc:��$��10,0,0,0q�$	��Top=�$
��Left=��� -   $ CcRecpt��#��[ ���� *	CcRecpt+$ TwoWay=�$ PropertyChanged=��� #��[  $��Body:��$��10,0,0,0q�$	��Top=�$
��Left=��� -   $ txtBody��#��[ ���� *Body+$ TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�.+��� -   $��atach��  PrimaryButtonStyle#��[ $��Attach Files���� -    ��Name$ lstAttachedFiles��$��10q��� $��2��$ 
Horizontal=�$��Right=�$��10q�.+��� -   #��[ $��Save Changes���� -   #��[ $��Cancel��