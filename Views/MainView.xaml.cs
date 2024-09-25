using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyToDo1.ViewModels;

namespace MyToDo1.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            string iconKindString = "WindowMaximize";

            if (Enum.TryParse(typeof(MaterialDesignThemes.Wpf.PackIconKind), iconKindString, out var iconKind))
            {
                maxPackIcon.Kind = (MaterialDesignThemes.Wpf.PackIconKind)iconKind;
            }

            btnMin.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };

            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    if (Enum.TryParse(typeof(MaterialDesignThemes.Wpf.PackIconKind), "WindowMaximize", out var iconKind))
                    {
                        maxPackIcon.Kind = (MaterialDesignThemes.Wpf.PackIconKind)iconKind;
                    }
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    if (Enum.TryParse(typeof(MaterialDesignThemes.Wpf.PackIconKind), "WindowRestore", out var iconKind))
                    {
                        maxPackIcon.Kind = (MaterialDesignThemes.Wpf.PackIconKind)iconKind;
                    }
                }
                    
            };

            btnClose.Click += (s, e) =>
            {
                this.Close();
            };

            ColorZone2.MouseMove += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            };

            menuBar.SelectionChanged += (s, e) =>
            {
                drawerHost.IsLeftDrawerOpen = false;
            };
        }

        private void MenuToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
