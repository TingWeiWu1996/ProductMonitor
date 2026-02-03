using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// RingUC.xaml 的互動邏輯
    /// </summary>
    public partial class RingUC : UserControl
    {


        public RingUC()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drug();
        }

        public double PercentValue
        {
            get { return (double)GetValue(PercentValueProperty); }
            set { SetValue(PercentValueProperty, value); }
        }

        public static readonly DependencyProperty PercentValueProperty =
            DependencyProperty.Register("PercentValue", typeof(double), typeof(RingUC));

        /// <summary>
        /// 畫圓環方法  要多練!
        /// </summary>

        private void Drug()
        {
            LayOutGrid.Width = Math.Min(RenderSize.Width, RenderSize.Height);
            double radius = LayOutGrid.Width / 2;

            double x = radius + (radius - 3) * Math.Cos((PercentValue % 100 * 3.6 - 90) * Math.PI / 180);
            double y = radius + (radius - 3) * Math.Sin((PercentValue % 100 * 3.6 - 90) * Math.PI / 180);

            string pathStr = $"M{radius + 0.01} 3A{radius - 3} {radius - 3} 0 {(PercentValue < 50 ? 0 : 1)} 1 {x} {y}";//移動路徑 

            var converter = TypeDescriptor.GetConverter(typeof(Geometry));

            path.Data = (Geometry)converter.ConvertFrom(pathStr);

        }

    }
}
