using System;

namespace MyWpfApp.Models
{
    /// <summary>
    /// ������, �������������� ������� ����������.
    /// </summary>
    public class ApplicationItem
    {
        /// <summary>
        /// �������� ����������.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ���� � ���������� ��� ���-������.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// ������ ���������� (��������������, ����� ���� ���� � �����������).
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// �������� ����������.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ���� ���������� ����������.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// ����������� �� ���������.
        /// </summary>
        public ApplicationItem()
        {
            DateAdded = DateTime.Now;
        }

        /// <summary>
        /// ����������� � �����������.
        /// </summary>
        /// <param name="name">�������� ����������.</param>
        /// <param name="path">���� � ���������� ��� ���-������.</param>
        /// <param name="iconPath">���� � ������ ����������.</param>
        /// <param name="description">�������� ����������.</param>
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