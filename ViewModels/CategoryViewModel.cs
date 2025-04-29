using System.Collections.ObjectModel;
using MyWpfApp.Models;

namespace MyWpfApp.ViewModels
{
    /// <summary>
    /// ViewModel ��� ���������.
    /// </summary>
    public class CategoryViewModel : BaseViewModel
    {
        /// <summary>
        /// �������� ���������.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �������� ���������.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ��������� ����������, ����������� � ���������.
        /// </summary>
        public ObservableCollection<ApplicationItem> Applications { get; set; }

        /// <summary>
        /// �����������.
        /// </summary>
        /// <param name="category">������ ���������.</param>
        public CategoryViewModel(Category category)
        {
            Name = category.Name;
            Description = category.Description;
            Applications = new ObservableCollection<ApplicationItem>(category.Applications);
        }
    }
}