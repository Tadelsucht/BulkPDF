using System;
using System.Reflection;

namespace BulkPDFConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("----------      BulkPDF       ----------");
            Console.WriteLine("----------      " + Assembly.GetExecutingAssembly().GetName().Version + "       ----------");
            Console.WriteLine("----------------------------------------");

            int exitcode = 1;
            if ((args != null) && ((args.Length >= 1) || (args.Length <= 2)))
            {
                var cmd = new Worker();
                if (cmd.Do(args[0]))
                    exitcode = 0;

                if (args.Length == 2)
                    if (args[1].ToString() == "wait")
                        Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Usage: BulkPDFConsole.exe \"C:\\Users\\username\\Desktop\\\"");
            }
            Environment.Exit(exitcode);
        }
    }
}