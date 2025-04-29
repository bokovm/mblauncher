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
        /// ��� ���������� (EXE ��� Web).
        /// </summary>
        public ApplicationType Type { get; set; }

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
            Type = ApplicationType.Exe;
        }

        /// <summary>
        /// ����������� � �����������.
        /// </summary>
        /// <param name="name">�������� ����������</param>
        /// <param name="path">���� � ����������</param>
        /// <param name="type">��� ����������</param>
        /// <param name="iconPath">���� � ������</param>
        /// <param name="description">��������</param>
        public ApplicationItem(
            string name,
            string path,
            ApplicationType type = ApplicationType.Exe,
            string iconPath = null,
            string description = null)
        {
            Name = name;
            Path = path;
            Type = type;
            IconPath = iconPath;
            Description = description;
            DateAdded = DateTime.Now;
        }
    }

    /// <summary>
    /// ���� ����������
    /// </summary>
    public enum ApplicationType
    {
        /// <summary> ����������� ���� </summary>
        Exe,

        /// <summary> ���-���������� </summary>
        Web
    }
}