using MyWpfApp.Utilities;
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
        private object _originalContent;

        // �������� �������� ����
        public WindowState WindowState
        {
            get => _windowState;
            set
            {
                if (SetProperty(ref _windowState, value))
                {
                    ConfigureInterfaceForWindowState(value);
                }
            }
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

        // �������� ��� ���������� ��������� ����
        public object CurrentContent
        {
            get => _currentContent;
            set => SetProperty(ref _currentContent, value);
        }

        // �������
        public ICommand ToggleFullScreenCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand OpenGamesCommand { get; }
        public ICommand OpenAppsCommand { get; }
        public ICommand OpenBrowsersCommand { get; }
        public ICommand OpenOtherCommand { get; }
        public ICommand OpenVideosCommand { get; }
        public ICommand OpenMusicCommand { get; }

        public MainViewModel()
        {
            // ������������� ������
            ToggleFullScreenCommand = new RelayCommand(_ => ToggleFullScreen());
            ExitCommand = new RelayCommand(_ => ExitApplication());

            // ������� ���������
            OpenGamesCommand = new RelayCommand(_ => OpenCategory("����"));
            OpenAppsCommand = new RelayCommand(_ => OpenCategory("����������"));
            OpenBrowsersCommand = new RelayCommand(_ => OpenCategory("��������"));
            OpenOtherCommand = new RelayCommand(_ => OpenCategory("������"));
            OpenVideosCommand = new RelayCommand(_ => OpenCategory("�����"));
            OpenMusicCommand = new RelayCommand(_ => OpenCategory("������"));

            // ��������� ���������
            WindowState = WindowState.Normal;
            WindowWidth = 900;
            WindowHeight = 500;
            CurrentContent = new MainContent(); // ��� �������� �������
            _originalContent = CurrentContent;
        }

        private void ToggleFullScreen()
        {
            WindowState = WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }

        private void ConfigureInterfaceForWindowState(WindowState state)
        {
            if (state == WindowState.Maximized)
            {
                WindowWidth = SystemParameters.PrimaryScreenWidth;
                WindowHeight = SystemParameters.PrimaryScreenHeight;
            }
            else
            {
                WindowWidth = 900;
                WindowHeight = 500;
            }
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void OpenCategory(string categoryName)
        {
            var categoryView = new CategoryView(categoryName)
            {
                BackAction = () => CurrentContent = _originalContent
            };

            CurrentContent = categoryView;
        }

        // ��������������� ����� ��� ��������� ��������
        public class MainContent { }
    }
}