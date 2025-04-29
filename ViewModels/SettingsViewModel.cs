using System.Collections.Generic;
using MyWpfApp.Models;

namespace MyWpfApp.ViewModels
{
    /// <summary>
    /// ViewModel ��� �������� ����������.
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        private string _selectedTheme;
        private string _configFilePath;

        /// <summary>
        /// ��������� ���� ��� ������.
        /// </summary>
        public List<string> AvailableThemes { get; set; }

        /// <summary>
        /// ��������� ����.
        /// </summary>
        public string SelectedTheme
        {
            get => _selectedTheme;
            set => SetProperty(ref _selectedTheme, value);
        }

        /// <summary>
        /// ���� � �������� ����� ������������.
        /// </summary>
        public string ConfigFilePath
        {
            get => _configFilePath;
            set => SetProperty(ref _configFilePath, value);
        }

        /// <summary>
        /// ����������� ViewModel ��� ��������.
        /// </summary>
        public SettingsViewModel()
        {
            AvailableThemes = new List<string> { "Light", "Dark", "System Default" };
            SelectedTheme = "Light"; // ��������� ���� �� ���������
        }

        /// <summary>
        /// ���������� ��������.
        /// </summary>
        public void SaveSettings()
        {
            // TODO: ����������� ���������� ��������, ��������, � ���� ��� ���� ������.
        }

        /// <summary>
        /// �������� ��������.
        /// </summary>
        public void LoadSettings()
        {
            // TODO: ����������� �������� ��������, ��������, �� ����� ��� ���� ������.
            ConfigFilePath = "./config.json"; // ������
        }
    }
}