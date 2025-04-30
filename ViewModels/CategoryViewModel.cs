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
        public string CategoryName { get; }
        public ApplicationItem SelectedApp { get; set; }

        public ICommand BackCommand { get; }
        public ICommand LaunchCommand { get; }

        public ObservableCollection<ApplicationItem> Applications { get; } = new();

        public CategoryViewModel(string categoryName, Action backAction)
        {
            LoadApplications(categoryName);
        BackCommand = new RelayCommand(_ => backAction?.Invoke());
        LaunchCommand = new RelayCommand(_ => LaunchApp());
        }

        private void LoadApplications(string categoryName)
        {
            try
            {
                Applications.Clear();

                Applications.Add(new ApplicationItem
                {
                    Name = $"{categoryName} - Блокнот",
                    Path = "notepad.exe",
                    Type = ApplicationType.Exe
                });

                Applications.Add(new ApplicationItem
                {
                    Name = $"{categoryName} - Google",
                    Path = "https://google.com",
                    Type = ApplicationType.Web
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void LaunchApp()
        {
            if (SelectedApp == null) return;

            string path = SelectedApp.Path;
            if (SelectedApp.Type == ApplicationType.Web && !path.StartsWith("http"))
            {
                path = "http://" + path;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}