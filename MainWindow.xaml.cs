using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyWpfApp.ViewModels;
using MyWpfApp.Views;

namespace MyWpfApp
{
    public partial class MainWindow : Window
    {
        private bool _isFullScreen = true;
        private UIElement _mainContent;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            _mainContent = new StartupView();
            if (DataContext is MainViewModel vm)
            {
                vm.CurrentContent = _mainContent;
            }
        }

        private void DragWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        public void ToggleFullScreen()
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
                Width = 900;
                Height = 500;
            }
            else
            {
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
            }
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenCategory(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && DataContext is MainViewModel vm)
            {
                var categoryName = button.Content?.ToString();
                if (string.IsNullOrEmpty(categoryName))
                {
                    MessageBox.Show("Название категории не задано.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    var categoryView = new CategoryView(
                        categoryName,
                        () => vm.CurrentContent = _mainContent
                    );
                    vm.CurrentContent = categoryView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии категории: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}