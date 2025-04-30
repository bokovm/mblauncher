namespace MyWpfApp.Models
{
    public class ApplicationItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string IconPath { get; set; }
        public string Description { get; set; }
        public ApplicationType Type { get; set; }
    }

    public enum ApplicationType
    {
        Exe,
        Web
    }
}