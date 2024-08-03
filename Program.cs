using TatehamaInterlocking.Tsuzaki;

namespace TatehamaInterlocking
{
    internal static class Program
    {
        static internal string ServerAddress = "https://kesigomon.com:62356";
        //static internal string ServerAddress = "https://kesigomon.com:8090";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }
    }
}