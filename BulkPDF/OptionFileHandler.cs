using System.IO;
using System.Text.RegularExpressions;

namespace BulkPDF
{
    internal static class OptionFileHandler
    {
        private static string optionFileName = "options.txt";

        public static string GetOptionValue(string name)
        {
            if (File.Exists(optionFileName))
            {
                string options = File.ReadAllText(optionFileName);
                return Regex.Match(options, @"<" + name + @">(.*)</" + name + @">").Groups[1].Value;
            }
            else
            {
                return "";
            }
        }
    }
}