using System.Collections.Generic;

namespace MyWpfApp.Models
{
    /// <summary>
    /// ������, �������������� ���������.
    /// </summary>
    public class Category
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
        /// ������ ����������, ����������� � ���������.
        /// </summary>
        public List<ApplicationItem> Applications { get; set; }

        /// <summary>
        /// ����������� �� ���������.
        /// </summary>
        public Category()
        {
            Applications = new List<ApplicationItem>();
        }

        /// <summary>
        /// ����������� � �����������.
        /// </summary>
        /// <param name="name">�������� ���������.</param>
        /// <param name="description">�������� ���������.</param>
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            Applications = new List<ApplicationItem>();
        }

        /// <summary>
        /// �������� ���������� � ���������.
        /// </summary>
        /// <param name="application">���������� ��� ����������.</param>
        public void AddApplication(ApplicationItem application)
        {
            Applications.Add(application);
        }
    }
}