using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyToDo1.Views
{
    /// <summary>
    /// AboutView.xaml 的交互逻辑
    /// </summary>
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void CopyEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            // 要复制的邮箱地址
            string emailAddress = "dengwenzhe04@gmail.com";

            // 将邮箱地址复制到剪贴板
            Clipboard.SetText(emailAddress);

            // 显示提示信息
            PopupText.Visibility = Visibility.Visible;

            // 设置定时器，在1.5秒后隐藏提示信息
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1.5);
            timer.Tick += (s, args) =>
            {
                PopupText.Visibility = Visibility.Collapsed;
                timer.Stop();  // 停止定时器
            };
            timer.Start();
        }
    }
}
