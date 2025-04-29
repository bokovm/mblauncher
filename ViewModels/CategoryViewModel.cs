using MyWpfApp.Models;
using MyWpfApp.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace MyWpfApp.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private readonly Action _goBackAction;
        private readonly string _categoryName;

        public ObservableCollection<ApplicationItem> Applications { get; } = new();
        public ApplicationItem SelectedApp { get; set; }

        public ICommand BackCommand { get; }
        public ICommand LaunchCommand { get; }

        public CategoryViewModel(string categoryName, Action goBackAction)
        {
            _categoryName = categoryName;
            _goBackAction = goBackAction;

            BackCommand = new RelayCommand(_ => _goBackAction?.Invoke());
            LaunchCommand = new RelayCommand(_ => LaunchApplication());

            LoadApplications();
        }

        private void LoadApplications()
        {
            try
            {
                Applications.Clear();

                Applications.Add(new ApplicationItem(
                    $"{_categoryName} - Блокнот",
                    "notepad.exe",
                    ApplicationType.Exe));

                Applications.Add(new ApplicationItem(
                    $"{_categoryName} - Google",
                    "https://google.com",
                    ApplicationType.Web));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LaunchApplication()
        {
            if (SelectedApp == null) return;

            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = SelectedApp.Type == ApplicationType.Web
                        ? SelectedApp.Path.StartsWith("http")
                            ? SelectedApp.Path
                            : $"http://{SelectedApp.Path}"
                        : SelectedApp.Path,
                    UseShellExecute = true
                };

                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка запуска: {ex.Message}",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }
    }
}