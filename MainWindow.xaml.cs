using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using MyWpfApp.ViewModels;

namespace MyWpfApp
{
    public partial class MainWindow : Window
    {
        private bool _isFullScreen = true;
        private UIElement _mainContent;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnWindowLoaded;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            _mainContent = (UIElement)Content;
            if (DataContext is MainViewModel vm)
            {
                vm.CurrentContent = _mainContent;
                EnterFullScreen();
            }
        }

        private void DragWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void ToggleFullScreen()
        {
            _isFullScreen = !_isFullScreen;
            if (_isFullScreen) EnterFullScreen();
            else ExitFullScreen();
        }

        private void EnterFullScreen()
        {
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
        }

        private void ExitFullScreen()
        {
            WindowState = WindowState.Normal;
            WindowStyle = WindowStyle.SingleBorderWindow;
            ResizeMode = ResizeMode.CanResize;
            Width = 1200;
            Height = 800;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenCategory(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && DataContext is MainViewModel vm)
            {
                var categoryName = button.Content.ToString();
                var categoryView = new CategoryView(categoryName)
                {
                    BackAction = () => vm.CurrentContent = _mainContent
                };
                vm.CurrentContent = categoryView;
            }
        }
    }
}