   M S B A M L   `   `   `  ����D  @PhoneBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PhoneBook	PhoneBook  5   	   ;"clr-namespace:PhoneBook.ViewModelsPhoneBook.ViewModels  5   	       PhoneBook.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PhoneBook     5   	   1vm"clr-namespace:PhoneBook.ViewModels     5   	     � Title$  
Phone Book��5	   	   $	��450��6   $	��800��6)    � DataContext 5
      (  "PhoneBook.ViewModels.MainViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.8* �6   �� 5      $��* �6   �� 5      $
��0.8* �6   �� 5      $	��10* �6   �� 5      $��0.35* �6    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $
��0.1* �6   .+�5#   
   �� -   5         ��Name$ addBut��5#      $��1��6"   $��1��6/   $	��Add��6?   $��0,0,1,2q�6M   
���������6q   �� *
AddCommand+�� 5$   
   -   5        $ delBut��5$      $��1��6!   $��2��6.   $��Delete��6>   $��0,0,1,2q�6O   
���������6s   �� *
DelCommand+{�6�   �� *TextBoxEmpty+�� 5%   
   -   5        $ updBut��5%      $��1��6!   $��3��6.   $��Update��6>   $��0,0,1,2q�6O   
���������6t   �� *
UpdCommand+{�6�   �� *TextBoxEmpty+�� 5&   
   -   5        $ loadBut��5&      $��1��6"   $��4��6/   $
��Load��6?   $��0,0,1,2q�6N   
���������6_   �� *LoadCommand+6�   �� 5'   
   -   5        $ saveBut��5'      $��1��6"   $��5��6/   $
��Save��6?   $��0,0,1,2q�6N   
���������6_   �� *SaveCommand+{�6�   �� *TextBoxEmpty+�� 5)   
   -   5         ��Name$ firstNameLabel��5)      $��2��6(   $��1��65   $��First Name:��6E   $��-5,8,0,0q�6[   �� 5*   
   -   5         ��Name$ firstTextBox��5*      $��3��6(   $��1��65   $��0,2,1,3q�6E   ��6V   �� *PersonObj.firstName+�� 5,   
   -   5        $ lastNameLabel��5,      $��2��6'   $��2��64   $��
Last Name:��6D   $��-5,8,0,0q�6Y   �� 5-   
   -	   5        $ lastTextBox��5-      $��3��6'   $��2��64   $��0,2,1,3q�6E   ��6V   �� *PersonObj.lastName+�� 5/   
   -
   5        $ 
phoneLabel��5/      $��2��6$   $��3��61   $��Phone:��6A   $��-5,8,0,0q�6R   �� 50   
   -   5        $ phoneTextBox��50      $��3��6(   $��3��65   $��0,2,1,3q�6F   ��6W   �� *PersonObj.phone+�� 52   
   -   5        $ 
emailLabel��52      $��2��6$   $��4��61   $��Email:��6A   $��-5,8,0,0q�6R   �� 53   
   -   5        $ emailTextBox��53      $��3��6(   $��4��65   $��0,2,1,3q�6G   ��6X   �� *PersonObj.email+�� 55   
   -   5        $ 	passLabel��55      $��2��6#   $��5��60   $��	Password:��6@   $��-5,8,0,0q�6T   �� 56   
   -   5        $ passTextBox��56      $��3��6'   $��5��64   $��0,2,1,3q�6E   ��6V   �� *PersonObj.password+&   System.Windows.Controls.DataGrid  58   
      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 150 6   $��12(�6%   $��4��64   $��1��6A   $��5��6R      SelectionMode$ Single=�6f   	   SelectionUnit$	 FullRow=�6}   
�������
 �� SelectedIndex
 6�   �� *SelectedTableRow+��6�   �� *
PersonData+ � 	Resources 59       �� Color��%c   (��       5:   "   *1/SystemColors.InactiveSelectionHighlightBrushKey+)�� 6   $ Green��6e   5;      5<      5=      5>      