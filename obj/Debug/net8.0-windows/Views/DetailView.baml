   M S B A M L   `   `   `  ����B  >MyToDo1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MyToDo1.ExtentionsMyToDo1.Extentions  5	      =#clr-namespace:MyToDo1.Common.ModelsMyToDo1.Common.Models  5
      7 clr-namespace:MyToDo1.ViewModelsMyToDo1.ViewModels  5      -clr-namespace:MyToDo1.ViewsMyToDo1.Views  5          MyToDo1.Views.DetailView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ] YPrism.DryIoc.Wpf, Version=9.0.537.60525, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59V	 RPrism.Wpf, Version=9.0.537.60525, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      _
 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 
 5      *ext clr-namespace:MyToDo1.Extentions 
 5	      0models#clr-namespace:MyToDo1.Common.Models 
 5
      1
viewmodels clr-namespace:MyToDo1.ViewModels 
 5      'localclr-namespace:MyToDo1.Views 
 5      ! 	 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      $��Segoe UI)�5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��Details��6   $��26(�6#   $��20,20q�61   $��Bottom=�6@   $
��Bold"�6[   �� 5   
   ���#dddddd$��0,0,0,1q�6'   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5      .+�5"      �  5#      �� 5$      $
��auto �6$   �� 5%      .+�5'      �� $��Images: ��6   $��25,20, 20,0q�6,   $
��Left=�6A   $��Center=�6\   $��22(�6w   $
��Bold"�6�   �� 5(      -   5         ��Name$ 	detailBar��5(      $��10q�6u   $��1��6�   ��6-   �� *
DetailBars+* 
 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5)      + 
 %Microsoft.Xaml.Behaviors.EventTrigger  5*         	EventName$ SelectionChanged��6)   * 
 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5+      2 
 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   �� *ViewCommand+   CommandParameter 6T   �� 	 �� ElementName$	 	detailBar��
 �� Path$
 SelectedItem�5,      ��5.      �� 5/      .R�50      �� $
��10,5q�6(   ��66   �� *Title+��51   "   �� 52   &    �� 
TargetType" ��6,   .�53   *   ��  �� Property � �� �� Value
 ���� 6G    �� Triggers 55   *   P� 56   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �57   2   ��  �@�Cursor$
 Hand��6K   58   /   5:   '   5<      5>      5@      5A      � 5D      $��1��6    5E      �� 5F      $
��auto �6$   �� 5G      .+�5J      �� -   5        $��ThresholdComboBox��5J      $��5q�6�   ��64   �� *ThresholdsItemSource+ �� SelectedItem 6a   �� *SelectedThreshold+ �� Mode$ TwoWay=�6�   �� 5K      $
��Auto=�6   $��1��6B   .��5L      ��  �� Orientation$ Vertical=�6!   $��1��68   $
��Left=�6E   $��10,20q�6`   $	��Top=�6o   .+�5M      �� $ 
Horizontal=�6%   .+�5N      �� $ Vertical=�6)   .+�5O   "   �� $��Original Image: ��6,   $
��20,0q�6D   �� 5P   "   $	��250��6M   $
��Auto��6Y   $
��Left=�6g   $��Stretch=�6�   $��Uniform=�6�   $��
20,5,20,20q�6�   ��6(   �� *OriginalImagePath+6�   5Q      �� 5R      $ 
Horizontal=�6)   .+�5S   "   �� $��Like This Image? ��6,   $��20,20,10,20q�6E   $��Center=�6Z   $��Center=�6u   $��16(�6�   d� 5T   "    )  %MaterialDesignFlatPrimaryToggleButton#��[  6�    � ToolTip$+ %MaterialDesignFlatPrimaryToggleButton��6�   ��6/   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Heart=�   Size 21 d� 	IsChecked 6f   �� *IsLikedPara+��6�   �� *LikeCommand+5V      5W      �� 5Z      $ 
Horizontal=�6%   .+�5\      �� $ Vertical=�6)   .+�5]   "   �� $��Flakes: ��6,   $
��20,0q�6<   �� 5^   "   $	��450��6L   $
��Auto��6X   $
��Left=�6f   $��Stretch=�6�   $��Uniform=�6�   $��20,5, 20,20q�6�   ��6(   �� *ContourImagePath+6�   5_      �� 5a      $ Vertical=�6)   .+�5b   "   �� $��Mask: ��6,   $
��20,0q�6:   �� 5c   "   $	��450��6N   $
��Auto��6Z   $
��Left=�6h   $��Stretch=�6�   $��Uniform=�6�   $��
20,5,20,20q�6�   ��6(   �� *ThresholdImagePath+6�   5d      5g      5k      5n      5p      5t      5v      5w      