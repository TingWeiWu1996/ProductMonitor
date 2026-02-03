using ProductMonitor.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProductMonitor.UserControls
{
    public partial class RaderUC : UserControl
    {
        public RaderUC()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drag();
        }

        /// <summary>
        /// 數據來源 數據綁定 依賴屬性
        /// 修正:改名為 ItemsSource(加上 s)
        /// </summary>
        public List<RaderModel> ItemsSource
        {
            get { return (List<RaderModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(List<RaderModel>), typeof(RaderUC), 
                new PropertyMetadata(null, OnItemsSourceChanged));

        /// <summary>
        /// 當 ItemsSource 改變時重繪
        /// </summary>
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RaderUC raderUC)
            {
                raderUC.Drag();
            }
        }

        /// <summary>
        /// 畫圖方法
        /// </summary>
        public void Drag()
        {
            // 判斷是否有數據
            if (ItemsSource == null || ItemsSource.Count == 0)
            {
                return;
            }

            // 清除舊圖
            mainCanvas.Children.Clear();
            P1.Points.Clear();
            P2.Points.Clear();
            P3.Points.Clear();
            P4.Points.Clear();
            P5.Points.Clear();

            // 調整大小(正方形)
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            if (size <= 0) return; // 防止初始化時的錯誤

            LayGrid.Height = size;
            LayGrid.Width = size;

            // 半徑
            double radius = size / 2;

            // 步長
            double step = 360.0 / ItemsSource.Count;

            for (int i = 0; i < ItemsSource.Count; i++)
            {
                // 計算角度(從上方開始,-90度偏移)
                double angle = (step * i - 90) * Math.PI / 180;
                
                // X Y 座標偏移量
                double x = (radius - 20) * Math.Cos(angle);
                double y = (radius - 20) * Math.Sin(angle);

                // 繪製同心多邊形
                P1.Points.Add(new Point(radius + x, radius + y));
                P2.Points.Add(new Point(radius + x * 0.75, radius + y * 0.75));
                P3.Points.Add(new Point(radius + x * 0.5, radius + y * 0.5));
                P4.Points.Add(new Point(radius + x * 0.25, radius + y * 0.25));

                // 數據多邊形(根據實際數值)
                double dataValue = ItemsSource[i].Value / 100.0; // 假設數值為百分比
                P5.Points.Add(new Point(radius + x * dataValue, radius + y * dataValue));

                // 繪製分隔線
                Line line = new Line
                {
                    X1 = radius,
                    Y1 = radius,
                    X2 = radius + x,
                    Y2 = radius + y,
                    Stroke = new SolidColorBrush(Color.FromArgb(0x55, 0x18, 0xaa, 0xbd)),
                    StrokeThickness = 1
                };
                mainCanvas.Children.Add(line);

                // 繪製文字標籤
                TextBlock textBlock = new TextBlock
                {
                    Text = ItemsSource[i].ItemName,
                    Foreground = Brushes.White,
                    FontSize = 12
                };

                Canvas.SetLeft(textBlock, radius + x * 1.1 - 10);
                Canvas.SetTop(textBlock, radius + y * 1.1 - 10);
                mainCanvas.Children.Add(textBlock);
            }
        }
    }
}
