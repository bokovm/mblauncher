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
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = selectedItem.Path,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка запуска: {ex.Message}");
                }
            }
        }
    }
}