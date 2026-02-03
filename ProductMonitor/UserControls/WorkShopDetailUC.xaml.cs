using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// WorkShopDetailUC.xaml 的互動邏輯
    /// </summary>
    public partial class WorkShopDetailUC : UserControl
    {
        public WorkShopDetailUC()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            detail.Visibility = Visibility.Visible;
            //位移動畫
            ThicknessAnimation thickAnimation = new ThicknessAnimation(new Thickness(0, 50, 0, -50), new Thickness(0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 400));

            //透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thickAnimation, detailContent);
            Storyboard.SetTarget(doubleAnimation, detailContent);
            Storyboard.SetTargetProperty(thickAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thickAnimation);
            storyboard.Children.Add(doubleAnimation);

            storyboard.Begin();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //位移動畫
            ThicknessAnimation thickAnimation = new ThicknessAnimation(new Thickness(0, 50, 0, -50), new Thickness(0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 400));

            //透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thickAnimation, detailContent);
            Storyboard.SetTarget(doubleAnimation, detailContent);
            Storyboard.SetTargetProperty(thickAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thickAnimation);
            storyboard.Children.Add(doubleAnimation);

            //動畫結束才關閉

            storyboard.Completed += (se, ev) =>
            {
                detail.Visibility = Visibility.Collapsed;
            };
        }
    }
}
