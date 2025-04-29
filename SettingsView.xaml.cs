using System.Windows;

namespace MyWpfApp
{
    /// <summary>
    /// Логика взаимодействия для SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "Сохранить"
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь реализуйте логику сохранения настроек
            MessageBox.Show("Настройки сохранены.", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

            // Закрыть окно после сохранения
            this.Close();
        }

        // Обработчик кнопки "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрыть окно без сохранения изменений
            this.Close();
        }
    }
}