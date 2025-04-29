using MyWpfApp.Models;
using MyWpfApp.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MyWpfApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private WindowState _windowState;
        private double _windowWidth;
        private double _windowHeight;
        private object _currentContent;
        private object _mainContent;

        public WindowState WindowState
        {
            get => _windowState;
            set => SetProperty(ref _windowState, value);
        }

        public double WindowWidth
        {
            get => _windowWidth;
            set => SetProperty(ref _windowWidth, value);
        }

        public double WindowHeight
        {
            get => _windowHeight;
            set => SetProperty(ref _windowHeight, value);
        }

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

        public MainViewModel()
        {
            ToggleFullScreenCommand = new RelayCommand(_ => ToggleFullScreen());
            ExitCommand = new RelayCommand(_ => ExitApplication());
            OpenSettingsCommand = new RelayCommand(_ => OpenSettings());

            OpenGamesCommand = new RelayCommand(_ => OpenCategory("Игры"));
            OpenAppsCommand = new RelayCommand(_ => OpenCategory("Приложения"));
            OpenBrowsersCommand = new RelayCommand(_ => OpenCategory("Браузеры"));
            OpenOtherCommand = new RelayCommand(_ => OpenCategory("Другое"));
            OpenVideosCommand = new RelayCommand(_ => OpenCategory("Видео"));
            OpenMusicCommand = new RelayCommand(_ => OpenCategory("Музыка"));

            _mainContent = new MainContent();
            CurrentContent = _mainContent;

            ConfigureWindowInitialState();
        }

        private void ConfigureWindowInitialState()
        {
            WindowState = WindowState.Normal;
            WindowWidth = 900;
            WindowHeight = 500;
        }

        private void ToggleFullScreen()
        {
            WindowState = WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void OpenSettings()
        {
            // Логика открытия настроек
        }

        private void OpenCategory(string categoryName)
        {
            var categoryVM = new CategoryViewModel(
                categoryName,
                () => CurrentContent = _mainContent
            );
            CurrentContent = categoryVM;
        }

        public class MainContent { }
    }
}