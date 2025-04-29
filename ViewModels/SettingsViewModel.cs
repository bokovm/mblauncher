using System.Collections.Generic;
using MyWpfApp.Models;

namespace MyWpfApp.ViewModels
{
    /// <summary>
    /// ViewModel для настроек приложения.
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        private string _selectedTheme;
        private string _configFilePath;

        /// <summary>
        /// Доступные темы для выбора.
        /// </summary>
        public List<string> AvailableThemes { get; set; }

        /// <summary>
        /// Выбранная тема.
        /// </summary>
        public string SelectedTheme
        {
            get => _selectedTheme;
            set => SetProperty(ref _selectedTheme, value);
        }

        /// <summary>
        /// Путь к текущему файлу конфигурации.
        /// </summary>
        public string ConfigFilePath
        {
            get => _configFilePath;
            set => SetProperty(ref _configFilePath, value);
        }

        /// <summary>
        /// Конструктор ViewModel для настроек.
        /// </summary>
        public SettingsViewModel()
        {
            AvailableThemes = new List<string> { "Light", "Dark", "System Default" };
            SelectedTheme = "Light"; // Установим тему по умолчанию
        }

        /// <summary>
        /// Сохранение настроек.
        /// </summary>
        public void SaveSettings()
        {
            // TODO: Реализовать сохранение настроек, например, в файл или базу данных.
        }

        /// <summary>
        /// Загрузка настроек.
        /// </summary>
        public void LoadSettings()
        {
            // TODO: Реализовать загрузку настроек, например, из файла или базы данных.
            ConfigFilePath = "./config.json"; // Пример
        }
    }
}