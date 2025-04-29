using System.Collections.Generic;

namespace MyWpfApp.Models
{
    /// <summary>
    /// ������ ������������ ��� ��������.
    /// </summary>
    public class LauncherConfig
    {
        /// <summary>
        /// �������� ��������.
        /// </summary>
        public string LauncherName { get; set; }

        /// <summary>
        /// ������ ���������, ����������� � ������������ ��������.
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// ���� � ����� ������������.
        /// </summary>
        public string ConfigFilePath { get; set; }

        /// <summary>
        /// ����������� �� ���������.
        /// </summary>
        public LauncherConfig()
        {
            Categories = new List<Category>();
        }

        /// <summary>
        /// �������� ������������ �� �����.
        /// </summary>
        /// <param name="filePath">���� � ����� ������������.</param>
        /// <returns>��������� LauncherConfig � ������������ �������.</returns>
        public static LauncherConfig LoadFromFile(string filePath)
        {
            // TODO: ����������� ������ �������� ������������ �� ����� (��������, JSON ��� XML).
            return new LauncherConfig
            {
                LauncherName = "��� �������",
                ConfigFilePath = filePath
            };
        }

        /// <summary>
        /// ���������� ������������ � ����.
        /// </summary>
        /// <param name="filePath">���� � ����� ������������.</param>
        public void SaveToFile(string filePath)
        {
            // TODO: ����������� ������ ���������� ������������ � ���� (��������, JSON ��� XML).
        }
    }
}