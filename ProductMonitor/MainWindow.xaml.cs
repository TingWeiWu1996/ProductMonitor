using ProductMonitor.OpCommand;
using ProductMonitor.Services;
using ProductMonitor.UserControls;
using ProductMonitor.ViewModels;
using ProductMonitor.Views;
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
using ProductMonitor.Models;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        MainWindowVM mainWindowVM;
        public MainWindow()
        {
            InitializeComponent();

            ReloadService();
        }

        // 寫一個公開方法，讓設定頁面存檔後可以呼叫它
        public void ReloadService()
        {
            // 判斷現在是用哪種模式
            IDataService currentService;

            if (DeviceConfig.IsSimulationMode)
            {
                // 如果是模擬模式，就用 MockDataService
                currentService = new MockDataService();
            }
            else
            {
                // 如果是真實模式，就用 ModbusDataService
                currentService = new ModbusDataService();
            }

            // 如果 VM 已經存在，我們可以選擇重建它，或者(更進階的)只換掉它的 Service
            // 為了簡單起見，我們這裡直接重建一個 VM，這樣 Timer 也會重置，比較安全
            if (mainWindowVM != null)
            {
                // 這裡可以考慮先停掉舊 VM 的 Timer (如果你的 VM 有提供 Stop 方法)
                // 目前我們直接換掉，舊的會被 GC 回收
            }

            mainWindowVM = new MainWindowVM(currentService);
            this.DataContext = mainWindowVM;
        }

        //視窗控制事件
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region 彈出配置窗口
        private void ShowSettingWin()
        {


            SettingsWin settingsWin = new SettingsWin() { Owner = this };
            settingsWin.ShowDialog();
        }

        public Command ShowSettingsCmm
        {
            get
            {
                return new Command(ShowSettingWin);
            }

        }

        #endregion

        /// <summary>
        /// 顯示部門詳情頁
        /// </summary>
        private void ShowDetailUC()
        {
            WorkShopDetailUC workShopDetailUC = new WorkShopDetailUC();

            mainWindowVM.MonitorUC = workShopDetailUC;
            //動畫效果 由下而上
            //位移  移動時間
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0, 50, 0, -50), new Thickness(0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 400));

            //透明度  淡入時間
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thicknessAnimation, workShopDetailUC);
            Storyboard.SetTarget(doubleAnimation, workShopDetailUC);

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();

        }
        /// <summary>
        /// 返回主畫面
        /// </summary>
        private void BackCommand()
        {
            MonitorUC monitorUC = new MonitorUC();
            mainWindowVM.MonitorUC = monitorUC;
        }

        /// <summary>
        /// 展示詳情命令
        /// </summary>
        public Command ShowDetailCmm
        {
            get
            {
                return new Command(ShowDetailUC);
            }

        }

        public Command GoBackCmm
        {
            get
            {
                return new Command(BackCommand);

            }
        }

    }
}