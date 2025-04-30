using MyWpfApp.Models;
using MyWpfApp.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace MyWpfApp.Views
{
    public partial class CategoryView : UserControl
    {
        public CategoryView(string categoryName, Action backAction)
        {
            InitializeComponent(); // Теперь метод доступен
            DataContext = new CategoryViewModel(categoryName, backAction);
        }

        private void OnLaunchClicked(object sender, RoutedEventArgs e)
        {
            if (ApplicationsList.SelectedItem is ApplicationItem selectedItem)
            {
                try
                {
                    if (string.IsNullOrEmpty(selectedItem.Path))
                    {
                        MessageBox.Show("Путь к приложению не задан.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var processInfo = new ProcessStartInfo
                    {
                        FileName = selectedItem.Type == ApplicationType.Web
                            ? (selectedItem.Path.StartsWith("http") ? selectedItem.Path : $"http://{selectedItem.Path}")
                            : selectedItem.Path,
                        UseShellExecute = true
                    };

                    Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка запуска: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}