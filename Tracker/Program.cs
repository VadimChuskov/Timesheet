using Microsoft.Extensions.Configuration;
using System.Drawing.Text;

namespace Tracker
{
    internal static class Program
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.AddJsonFile(
            //    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json",
            //    optional: true)
            //.AddEnvironmentVariables()
            .Build();

        //private static ILogger<Program> _logger;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Build a config object, using env vars and JSON providers.
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //// Get values from the config given their key and their target type.
            //Settings settings = config.GetRequiredSection("Settings").Get<Settings>();

            //// Write the values to the console.
            //Console.WriteLine($"KeyOne = {settings.KeyOne}");
            //Console.WriteLine($"KeyTwo = {settings.KeyTwo}");
            //Console.WriteLine($"KeyThree:Message = {settings.KeyThree.Message}");


            var pfc = LoadFonts();
            Application.Run(new MainForm(pfc));
        }

        static PrivateFontCollection LoadFonts()
        {
            var pfc = new PrivateFontCollection();

            try
            {
                pfc.AddFontFile(Application.StartupPath + @"\src\Fonts\LCDAT&TPhoneTimeDate.ttf");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }

            return pfc;
        }
    }
}