using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace MyWpfApp
{
    public partial class CategoryView : UserControl
    {
        public Action BackAction { get; set; }
        private readonly string _categoryName;

        public CategoryView(string categoryName)
        {
            InitializeComponent();
            _categoryName = categoryName;
            LoadApplications();
            ApplicationsList.SelectionChanged += ApplicationsList_SelectionChanged;
        }

        private void LoadApplications()
        {
            try
            {
                var apps = new List<ApplicationItem>
                {
                    new ApplicationItem
                    {
                        Name = $"{_categoryName} - Блокнот",
                        Path = "notepad.exe"
                    },
                    new ApplicationItem
                    {
                        Name = $"{_categoryName} - Google",
                        Path = "https://google.com"
                    }
                };

                ApplicationsList.ItemsSource = apps;
                ApplicationsList.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки приложений: {ex.Message}",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackAction?.Invoke();
        }

        public class ApplicationItem
        {
            public string Name { get; set; }
            public string Path { get; set; }
        }

        private void ApplicationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ApplicationsList.SelectedItem is ApplicationItem selectedItem)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = selectedItem.Path,
                        UseShellExecute = true
                    });

                    // Сбрасываем выбор после запуска
                    ApplicationsList.SelectedIndex = -1;
                }
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