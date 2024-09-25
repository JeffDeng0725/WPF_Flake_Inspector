using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MyToDo1.Views
{
    /// <summary>
    /// IndexView.xaml 的交互逻辑
    /// </summary>
    public partial class IndexView : UserControl
    {
        public IndexView()
        {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("en-US");
            // 获取当前时间的小时数
            int hour = DateTime.Now.Hour;

            // 获取当前日期和星期的格式化字符串
            string todayDate = DateTime.Now.ToString("yyyy-MM-dd (dddd)", culture);

            // 根据小时数判断不同的时间段并设置不同的问候语
            if (hour >= 5 && hour < 9)
            {
                DateTextBlock.Text = "Good morning, Today is " + todayDate;
            }
            else if (hour >= 9 && hour < 12)
            {
                DateTextBlock.Text = "Hi, Today is " + todayDate;
            }
            else if (hour >= 12 && hour < 18)
            {
                DateTextBlock.Text = "Good afternoon, Today is " + todayDate;
            }
            else if (hour >= 18 || hour < 5)
            {
                DateTextBlock.Text = "Hi, it's late at night, Today is " + todayDate;
            }
        }

    }
}
