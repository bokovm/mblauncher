using System.IO;
using System.Windows;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {

        DispatcherUnhandledException += (sender, args) =>
        {
            File.AppendAllText("error.log", args.Exception.ToString());
            MessageBox.Show(args.Exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            args.Handled = true;
        };
    }
}