using System.Collections.ObjectModel;
using MyWpfApp.Models;

namespace MyWpfApp.ViewModels
{
    /// <summary>
    /// ViewModel для категории.
    /// </summary>
    public class CategoryViewModel : BaseViewModel
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
        /// Коллекция приложений, относящихся к категории.
        /// </summary>
        public ObservableCollection<ApplicationItem> Applications { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="category">Модель категории.</param>
        public CategoryViewModel(Category category)
        {
            Name = category.Name;
            Description = category.Description;
            Applications = new ObservableCollection<ApplicationItem>(category.Applications);
        }
    }
}