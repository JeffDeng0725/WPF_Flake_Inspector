   M S B A M L   `   `   `  ����B  >MyToDo1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyToDo1.ViewsMyToDo1.Views  5          MyToDo1.Views.ProcessView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      'localclr-namespace:MyToDo1.Views  5      $��Segoe UI)�5
      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��Process��6   $��30(�6#   $��20,20q�61   $��Bottom=�6@   $��	UltraBold"�6[   �� 5   
   ���#dddddd$��0,0,0,1q�6'   �� 5   
   $
��Auto=�6   $��1��6:   .��5      �   5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      .+�5      � $��0��6   $
��0,20q�6$    � ColumnDefinitions 5       �� 5!      $
��auto �6+   �� 5"      .+�5%      �� $
��15,0q�5&       �� CornerRadius$ 10��5'       J� Opacity$	 0.1Q�5(      ���#BEBEBE5)      �� 5*      $��1��5+      $
��15,0q�5,      $ 10��5-      $	 0.1Q�5.      ���#BEBEBE5/      �� 50       �� Orientation$ Vertical=�6!   $
��Left=�68   $
��20,0q�6S   .+�51      �� $��Input Folder��6$   $��20(�68   $
��Left=�6F   $��10q�6a   �� 52      -   5        $��folderPathTextBox��52   "   $��-��6;   $
��Left=�6D   $��10q�6_   �� 53      -   5        $��selectFolderPathBtn��53   !   $��Select Input Folder��6<   $
��Left=�6|   $��10,10,10,20q�6�      MaterialDesignPaperButton#��[  6�   54      �� 55      $ Vertical=�6!   $
��Left=�68   $
��20,0q�6S   $��1��6a   .+�56      �� $��Output Folder��6$   $��20(�69   $
��Left=�6G   $��10q�6b   �� 57      $ 
Horizontal=�6%   $
��Left=�6>   .+�58      �� -   5        $��outputDirTextBox��58   &   $��-��6>   $
��Left=�6G   $��10q�6b   �� 59      -   5        $
��Copy��59   %   $��Bottom=�64   $
��Left=�6O   $��8(�6j   #��[  6w   6�   5:      �� 5;      -   5        $��selectOutputDirButton��5;   !   $��Select Output Folder��6>   $
��Left=�6�   $��10,10,10,20q�6�   #��[  6�   5<      5@      � 5C      $��1��6   $
��0,20q�6$    5D      �� 5E      $
��auto �6+   �� 5F      $
��auto �6+   �� 5G      $
��auto �6+   �� 5H      .+�5J      �� $��0��5K      $
��15,0q�5L      $ 10��5M      $	 0.1Q�5N      ���#BEBEBE5O      �� 5P      $��1��5Q      $
��15,0q�5R      $ 10��5S      $	 0.1Q�5T      ���#BEBEBE5U      �� 5V      $��2��5W      $
��15,0q�5X      $ 10��5Y      $	 0.1Q�5Z      ���#BEBEBE5[      �� 5\      $��3��5]      $
��15,0q�5^      $ 10��5_      $	 0.1Q�5`      ���#BEBEBE5a      �� 5c      $ Vertical=�6!   $
��Left=�68   $��	20,0,30,0q�6S   $��0��6f   .+�5d      �� $��Low Threshold��6$   $��20(�69   $
��Left=�6G   $��10q�6b   ,  &MaterialDesignThemes.Wpf.NumericUpDown  5e      -   5        $��lowThresholdNumericUD��5e   7      AllowChangeOnScroll$
 True��6T      Value$	 100��6o   $
��Left=�6|   $��10,40,10,20q�6�   5f      �� 5g      $ Vertical=�6!   $
��Left=�68   $
��30,0q�6S   $��1��6a   .+�5h      �� $��High Threshold��6$   $��20(�6:   $
��Left=�6H   $��10q�6c     5i      -   5        $��highThresholdNumericUD��5i   7   $
 True��6U   $	 170��6p   $
��Left=�6|   $��10,40,10,20q�6�   5j      �� 5k      $ Vertical=�6!   $
��Left=�68   $
��30,0q�6S   $��2��6a   .+�5l      �� $��Number��6$   $��20(�62   $
��Left=�6@   $��10q�6[     5m      -   5        $��numberNumericUD��5m   7   $
 True��6N   $ 5��6i   $
��Left=�6s   $��10,40,10,20q�6�   5n      �� 5o      $ Vertical=�6!   $
��Left=�68   $
��30,0q�6S   $��3��6a   .+�5p      �� $��Channel��6$   $��20(�63   $
��Left=�6A   $��10q�6\   �� 5q      -	   5        $��channelComboBox��5q   #   $
��Left=�6:   $��10,40,10,20q�6U   $��70��6j   .@�5r      �� $
��blue��6+   �� 5s      $	��red��6+   �� 5t      $��green��6+   �� 5u      $
��gray��6+   5v      5w      5{      � 5}      $��2��6    5~      �� 5      $
��auto �6+   �� 5�      .+�5�      �� $��0��5�      $
��15,0q�5�      $ 10��5�      $	 0.1Q�5�      ���#BEBEBE5�      �� 5�      $��1��5�      $
��15,0q�5�      $ 10��5�      $	 0.1Q�5�      ���#BEBEBE5�      �� 5�      $ Vertical=�6!   $
��Left=�68   $
��20,0q�6S   $��0��6a   .+�5�      �� $��
Crop Ratio��6$   $��20(�66   $
��Left=�6D   $��10q�6_   �� 5�      $��16(�6v   $
��Left=�6�   $��10q�6�   ��6$   ��  �� ElementName$ cropRatioSlider�� �� Path$ Value�	 �� StringFormat$	 {0:F2}��6�   �� 5�      -
   5        $��cropRatioSlider��5�   !   
 � Minimum$
 0Q�68    � Maximum$ 1Q�6D    � Value$	 0.7Q�6P    � SmallChange$
 0.01Q�6\    � LargeChange$	 0.1Q�6o   $	��300��6�   $
��Left=�6�   $��
10,0,10,20q�6�   5�      �� 5�      $ Vertical=�6!   $
��Left=�68   $��
30,0,30,20q�6S   $��3��6g   .+�5�      �� $��Material��6$   $��20(�64   $
��Left=�6B   $��10q�6]   �� 5�      -   5        $��materialComboBox��5�   #   $
��Left=�6;   $��10q�6V   $��70��6b   .@�5�      �� $	��hBN��6+   �� 5�      $��Graphene��6+   �� 5�      $��MoTe2��6+   5�      5�      5�      �� 5�      -   5         ��Name$ startPythonBtn��5�      $'��!Click Here to Start Python Script��61   $��30q�6]   $��3��6i   #��[  6�   5�      5�      5�      5�      