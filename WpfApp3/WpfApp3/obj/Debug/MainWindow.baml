   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	   5clr-namespace:WpfApp3.ViewModelWpfApp3.ViewModel  5   	       WpfApp3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	   5	ViewModelclr-namespace:WpfApp3.ViewModel     5   	   &vmusing:WpfApp3.ViewModel     5	        � Title$  Library��5   	   $	��500��6   $	��850��6&    � WindowStartupLocation$ CenterScreen=�62    � 	Resources 5       $   CenterAlignmentColumnHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value  CenterAlignmentCell*  $System.Windows.Controls.DataGridCell  Noborderselection��%�  &	        &	 �     &	 !    �� 5   
   "  69   .�5      ��  � ��$ Center=�6;   �� 5       � ��$ 14(�6)   �� 5       � ��$ SemiBold"�6+   5      �� 5   
   "  6,   �5      �� 5       �@��TextAlignment$ Center=�6<   �� 5       � ��$ 0q�64   5      �� 5    
   "  6*   �5!      �� 5#       � ��$ 0q�64   5%      5)       J� InputBindings 5*      �� 5+   
   
 �� Key$ F5��6    �� Command 5,      �� *AddnewbookCommand+.��51      �� $��-2,0,2,0q�6   $��Stretch=�6#   
�������.+�52   
   �� $��Center=�6   
�������$��1q�6A   ._�53      �� 	 �� Orientation$	 
Horizontal=�6   $��
5 10 5 10 q�62   .+�55      �� $��10 0 0 0q�6   $��Author: ��6.   $��SemiBold"�6>   $��14(�6T   �� 56      $��10 0 0 0q�6   $	��200��6,   ��69   �� *Author_block+
 �� Mode$
 TwoWay=��� 57      $��10 0 0 0q�6   $��Title: ��6.   $��SemiBold"�6=   $��14(�6S   �� 58      $��10 0 0 0q�6   $	��200��6,   ��69   �� *Title_block+$
 TwoWay=��� 59      $��10 0 0 0q�6   $��Year:��6.   $��SemiBold"�6;   $��14(�6Q   �� 5:      $��10 0 0 0q�6   $	��100��6.    �� DisplayMemberPath$ Number��6:   ��6W   ��  �� Path$ values�$
 TwoWay=� �� SelectedItem 6�   �� *	_Selected+$
 TwoWay=��� 5;      $��Filter��6<   $��Stretch=�6N   $��10 0 2 0q�6l   $��60��6~   $��14(�6�   $��SemiBold"�6�   ��6   �� *FilterCommand+6�   �� 5<      $��Clear��6;   $��Stretch=�6L   $��5 0 0 0q�6j   $��60��6{   $��14(�6�   $��SemiBold"�6�   ��6   �� *ClearCommand+6�   5>      5?      � 5B   
   $	��500��6   $��	-6,15,0,0q�6   
�������.+�5D      &   System.Windows.Controls.DataGrid  -   5          Name$ 	mylibrary��5D      $��Stretch=�6+      AutoGenerateColumns .  
�������$	��300��6�      
IsReadOnly .    SelectionMode$ Extended=�6�   $��0,0,0,0q�6�   ��6f   �� *_Book+ 6�   �� *Selected_item+$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$ Author��64      	CellStyle# [ 6D      FontSize$ 14Q�6s      HeaderStyle# [  6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *Author+$
 TwoWay=�  5H      $ * 6)   $ Title��63   # [ 6B   $ 14Q�6q   # [  6    6�   �� *Title+$
 TwoWay=�  5I      $ 80 6)   # [ 64   $
 Year��6e   $ 14Q�6s   # [  6�    6�   �� *Year+$
 TwoWay=� 5M      d� 5N       d� Gesture$ LeftDoubleClicka�6#    6=   �� *EditnewbookCommand+�� 5O      $ Delete��6!    6.   �� *DeleteCommand+5S      5T      �� 5U   
   $	 
Horizontal=�6   $��Center=�6/   $��	0 30 0 50q�6L   .+�5V      �� $��Delete��6   $��0 0 0 0 q�6&   $	��120��68   $��SemiBold"�6D   $��30��6|   ��6Z   �� *DeleteCommand+6|   �� 5X      $��Add new book��6   $��10 0 0 0q�6,   $	��120��6d   $��SemiBold"�6p   ��6>   �� *AddnewbookCommand+6p   �� 5Y      $��	Edit book��6   $��10 0 0 0q�6P   $	��120��6b   $��SemiBold"�6n   ��6)   �� *EditnewbookCommand+6n   5Z      5\      5]      