   M S B A M L   `   `   `  ����  EmailClient    EmailClient.ComposeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Compose Email��5   	   $	��600��6   $
��1200��6,   .��5      � .+�5   
   �� $��From:��6   $��10,0,0,0q�6    $	��Top=�62   $
��Left=�6J   �� 5   
   -   5         ��Name$ 	cmbSender��5      $��
10,30,10,0q�5	      $	��Top=�5      $��Stretch=�5      ��5
      �� *AvailableSenders+ �� SelectedItem 5      �� *SelectedSender+ �� Mode$ TwoWay=�5      �� 5   
   $	��To:��6   $��	10,50,0,0q�6   $	��Top=�61   $
��Left=�6I   �� 5   
   -   5         ��Name$ txtTo��5      $��
10,70,10,0q�6!   $	��Top=�65   $��Stretch=�6M   �� 5   
   $��Subject:��6   $��	10,90,0,0q�6#   $	��Top=�66   $
��Left=�6N   �� 5   
   -   5        $ 
txtSubject��5      $��10,110,10,0q�6&   $	��Top=�6;   $��Stretch=�6S   �� 5   
   $	��Cc:��6   $��
10,120,0,0q�6   $	��Top=�62   $
��Left=�6J   �� 5   
   -   5        $ CcRecpt��5      $��10,140,10,0q�6#   $	��Top=�68   $��Stretch=�6P   �� 5   
   $��Body:��6   $��
10,150,0,0q�6    $	��Top=�64   $
��Left=�6L   �� 5    
   -   5        $ txtBody��5       $��10,170,10,10q�5!   
    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5#   
   " �� VerticalScrollBarVisibility$
 Auto=�5$   
   $ �� HorizontalScrollBarVisibility$
 Auto=�5%   
   $��Stretch=�5&   
   $��Stretch=�5'   
   ��5(   
   �� *CurrentEmail.Body+$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5*   
   
 �� Orientation$
 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��10q�6e   .+�5,      �� -   5         ��Name$ btnDraft��5,      $��Save as Draft��6'   6?   �� 5/      -   5        $ btnSend��5/      $
��Send��6&   65   �� 50      -   5         ��Name$ totalAttachedFiles��50      $��10q�62   52      �� 56   
   -	   5        $ btnAt��56      $��Attachement��6    $��10q�66   $
��Left=�6B   $��Bottom=�6]   6x   58      59      