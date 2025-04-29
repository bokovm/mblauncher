using MyWpfApp.Models;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace MyWpfApp.Views
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
                var apps = new System.Collections.Generic.List<ApplicationItem>
                {
                    new ApplicationItem
                    {
                        Name = $"{_categoryName} - Блокнот",
                        Path = "notepad.exe",
                        Type = ApplicationType.Exe
                    },
                    new ApplicationItem
                    {
                        Name = $"{_categoryName} - Google",
                        Path = "https://google.com",
                        Type = ApplicationType.Web
                    }
                };

                ApplicationsList.ItemsSource = apps;
                ApplicationsList.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) => BackAction?.Invoke();

        private void OnLaunchClicked(object sender, RoutedEventArgs e)
        {
            if (ApplicationsList.SelectedItem is ApplicationItem selectedItem)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = selectedItem.Path,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка запуска: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ApplicationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка выбора элемента
        }
    }
}