   M S B A M L   `   `   `  ����   EmailClient    EmailClient.ComposeWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Compose Email��$	��600��$
��1200�� � Triggers :�  :� RoutedEvent$ Window.Loaded��.[��� .���� .��t�  g� Duration$ 0:0:0.5D� t� From$ -300,0,300,0X�	 t� To$ 0X� �� TargetProperty$ Margin�.��� .+���    DefaultLabelStyle#��[  $��From:��$��10,0,0,0q�$	��Top=�$
��Left=��� -    ��Name$ 	cmbSender��  DefaultComboBoxStyle#��[ $��
10,30,10,0q�$	��Top=�$��Stretch=����� *AvailableSenders+ �� SelectedItem �� *SelectedSender+	 �� Mode$	 TwoWay=��� #��[  $	��To:��$��	10,48,0,0q�$	��Top=�$
��Left=��� -   
 ��Name$
 txtTo��  DefaultTextBoxStyle#��[ $��
10,68,10,0q�$	��Top=�$��Stretch=��� #��[  $��Subject:��$��	10,90,0,0q�$	��Top=�$
��Left=��� -   $
 
txtSubject��#��[ $��10,110,10,0q�$	��Top=�$��Stretch=��� #��[  $	��Cc:��$��
10,133,0,0q�$	��Top=�$
��Left=��� -   $
 CcRecpt��#��[ $��10,155,10,0q�$	��Top=�$��Stretch=��� #��[  $��Body:��$��
10,230,0,0q�$	��Top=�$
��Left=��� -   $
 txtBody��$��10,250,10,10q� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$ �� HorizontalScrollBarVisibility$
 Auto=�$��Stretch=�$��Stretch=����� *CurrentEmail.Body+$	 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���  �� Orientation$ 
Horizontal=�$��Right=�$��Bottom=�$��10q�.+��� -    ��Name$ btnDraft��  PrimaryButtonStyle#��[ $��Save as Draft���� -   $ btnSend��#��[ $
��Send���� -    ��Name$ totalAttachedFiles��$��10q��� #��[  $��	Category:��$��
10,188,0,0q�$	��Top=�$
��Left=��� -	   $ cmbCategory��#��[ $��10,210,10,0q�$	��Top=�$��Stretch=����� *
Categories+ �� *SelectedCategory+$	 TwoWay=� �� Text �� *CurrentEmail.Category+$	 TwoWay=�$ PropertyChanged=��� -
   $ btnAt��#��[ $��10q�$
��Left=�$��Bottom=�.���� $ 
Horizontal=�.+��� $��Resources/attachment.png��$��16��$��16���� $�� Attach��$��Center=�