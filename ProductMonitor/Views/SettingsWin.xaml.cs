using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductMonitor.Views
{
    /// <summary>
    /// SettingsWin.xaml 的互動邏輯
    /// </summary>
    public partial class SettingsWin : Window
    {
        public SettingsWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 配置到頁面相對應的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            string tag = "";
            var btn = sender as RadioButton;
            if (btn != null)
            {
                tag = btn.Tag.ToString();
            }

            frame.Navigate(new Uri("pack://application:,,,/ProductMonitor;component/Views/SettingPage.xaml#" + tag, UriKind.RelativeOrAbsolute));
        }
    }
}
