using MyWpfApp.Views;
using MyWpfApp.Utilities;
using System.Windows;
using System.Windows.Input;

namespace MyWpfApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {      
        private object _currentContent;       

        public object CurrentContent
        {
            get => _currentContent;
            set => SetProperty(ref _currentContent, value);
        }

        public ICommand ToggleFullScreenCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand OpenGamesCommand { get; }
        public ICommand OpenAppsCommand { get; }
        public ICommand OpenBrowsersCommand { get; }
        public ICommand OpenOtherCommand { get; }
        public ICommand OpenVideosCommand { get; }
        public ICommand OpenMusicCommand { get; }
        public ICommand OpenSettingsCommand { get; }

        private object _mainContent;

        public MainViewModel()
        {
            _mainContent = new StartupView();
            CurrentContent = _mainContent;
            ToggleFullScreenCommand = new RelayCommand(_ =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.ToggleFullScreen();
            });
            ExitCommand = new RelayCommand(_ => ExitApplication());
            OpenSettingsCommand = new RelayCommand(_ => OpenSettings());

            OpenGamesCommand = new RelayCommand(_ => OpenCategory("Игры"));
            OpenAppsCommand = new RelayCommand(_ => OpenCategory("Приложения"));
            OpenBrowsersCommand = new RelayCommand(_ => OpenCategory("Браузеры"));
            OpenOtherCommand = new RelayCommand(_ => OpenCategory("Другое"));
            OpenVideosCommand = new RelayCommand(_ => OpenCategory("Видео"));
            OpenMusicCommand = new RelayCommand(_ => OpenCategory("Музыка"));

            CurrentContent = new StartupView();
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void OpenSettings()
        {
            var settingsWindow = new SettingsView();
            settingsWindow.Owner = Application.Current.MainWindow;
            settingsWindow.ShowDialog();
        }

        private void OpenCategory(string categoryName)
        {
            try
            {
                var categoryView = new CategoryView(
                    categoryName,
                    () => CurrentContent = _mainContent ?? new StartupView()
                );
                CurrentContent = categoryView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}