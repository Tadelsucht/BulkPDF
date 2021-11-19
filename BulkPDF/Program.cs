using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace BulkPDF
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            // Language
            string option = OptionFileHandler.GetOptionValue("Language");
            if (!String.IsNullOrEmpty(option))
                foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
                    if (cultureInfo.Name == option)
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfo.Name);

            // Programm
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}