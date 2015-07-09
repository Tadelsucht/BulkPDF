using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace BulkPDF
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
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
