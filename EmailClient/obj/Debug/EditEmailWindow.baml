   M S B A M L   `   `   `  ����  EmailClient!    EmailClient.EditEmailWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Edit Email��5   	   $	��600��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��1��6    �� Orientation$ Vertical=�6"   $��10q�69   .+�5      �� $��Subject:��6   $��	10,00,0,0q�6'   $	��Top=�6:   $
��Left=�6R   �� 5      -   5         ��Name$ 
txtSubject��5      ��6*   �� *	Subject+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5      $	��To:��6   $��10,0,0,0q�6"   $	��Top=�64   $
��Left=�6L   �� 5      -   5        $ txtReceiver��5      ��6+   �� *
Receiver+$ TwoWay=�$ PropertyChanged=��� 5      $	��Cc:��6   $��10,0,0,0q�6"   $	��Top=�64   $
��Left=�6L   �� 5      -   5        $ CcRecpt��5      ��6(   �� *	CcRecpt+$ TwoWay=�$ PropertyChanged=��� 5      $��Body:��6   $��10,0,0,0q�6$   $	��Top=�66   $
��Left=�6N   �� 5      -   5        $ txtBody��5      ��6(   �� *Body+$ TwoWay=�$ PropertyChanged=��� 5      $ 
Horizontal=�6   .+�5      �� -   5        $��atach��5      $��Attach Files��6'   6>   5      �� 5      -   5         ��Name$ lstAttachedFiles��5      $��10q�60   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�5       �� -   5        $��Save Changes��5       6,   �� 5!      -   5        $��Cancel��5!      6&   5"      5#      5%      