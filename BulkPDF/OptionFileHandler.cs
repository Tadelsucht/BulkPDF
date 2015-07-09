using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BulkPDF
{
    static class OptionFileHandler
    {
        static string optionFileName = "options.txt"; 

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
