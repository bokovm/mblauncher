using System.Collections.Generic;

namespace MyWpfApp.Models
{
    /// <summary>
    /// Модель, представляющая категорию.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Название категории.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание категории.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Список приложений, относящихся к категории.
        /// </summary>
        public List<ApplicationItem> Applications { get; set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Category()
        {
            Applications = new List<ApplicationItem>();
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="name">Название категории.</param>
        /// <param name="description">Описание категории.</param>
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            Applications = new List<ApplicationItem>();
        }

        /// <summary>
        /// Добавить приложение в категорию.
        /// </summary>
        /// <param name="application">Приложение для добавления.</param>
        public void AddApplication(ApplicationItem application)
        {
            Applications.Add(application);
        }
    }
}