using System.Drawing.Text;

namespace Tracker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var pfc = LoadFonts();
            Application.Run(new Form1(pfc));
        }

        static PrivateFontCollection LoadFonts()
        {
            var pfc = new PrivateFontCollection();

            try
            {
                pfc.AddFontFile(Application.StartupPath + @"\src\Fonts\DS-DIGII.ttf");
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