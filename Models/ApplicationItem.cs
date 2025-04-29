using System;

namespace MyWpfApp.Models
{
    /// <summary>
    /// Модель, представляющая элемент приложения.
    /// </summary>
    public class ApplicationItem
    {
        /// <summary>
        /// Название приложения.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Путь к приложению или веб-ссылке.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Иконка приложения (необязательная, может быть путь к изображению).
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// Описание приложения.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата добавления приложения.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public ApplicationItem()
        {
            DateAdded = DateTime.Now;
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="name">Название приложения.</param>
        /// <param name="path">Путь к приложению или веб-ссылке.</param>
        /// <param name="iconPath">Путь к иконке приложения.</param>
        /// <param name="description">Описание приложения.</param>
        public ApplicationItem(string name, string path, string iconPath = null, string description = null)
        {
            Name = name;
            Path = path;
            IconPath = iconPath;
            Description = description;
            DateAdded = DateTime.Now;
        }
    }
}