using System.Collections.Generic;

namespace MyWpfApp.Models
{
    /// <summary>
    /// Модель конфигурации для лаунчера.
    /// </summary>
    public class LauncherConfig
    {
        /// <summary>
        /// Название лаунчера.
        /// </summary>
        public string LauncherName { get; set; }

        /// <summary>
        /// Список категорий, определённых в конфигурации лаунчера.
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Путь к файлу конфигурации.
        /// </summary>
        public string ConfigFilePath { get; set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public LauncherConfig()
        {
            Categories = new List<Category>();
        }

        /// <summary>
        /// Загрузка конфигурации из файла.
        /// </summary>
        /// <param name="filePath">Путь к файлу конфигурации.</param>
        /// <returns>Экземпляр LauncherConfig с заполненными данными.</returns>
        public static LauncherConfig LoadFromFile(string filePath)
        {
            // TODO: Реализовать логику загрузки конфигурации из файла (например, JSON или XML).
            return new LauncherConfig
            {
                LauncherName = "Мой Лаунчер",
                ConfigFilePath = filePath
            };
        }

        /// <summary>
        /// Сохранение конфигурации в файл.
        /// </summary>
        /// <param name="filePath">Путь к файлу конфигурации.</param>
        public void SaveToFile(string filePath)
        {
            // TODO: Реализовать логику сохранения конфигурации в файл (например, JSON или XML).
        }
    }
}