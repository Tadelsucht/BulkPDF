using BulkPDF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace BulkPDFConsole
{
    internal class Worker
    {
        private IDataSource dataSource;
        private int DataSourceColumnsFilenameIndex;
        private PDF pdf;
        private string prefix;
        private string suffix;
        private bool useRowNumber;
        private bool useValueFromDataSource;

        public bool Do(string configurationFilePath)
        {
            try
            {
                Console.WriteLine("--- Load configuration file ---");
                configurationFilePath = Environment.ExpandEnvironmentVariables(configurationFilePath);
                XDocument xDocument = XDocument.Parse(File.ReadAllText(configurationFilePath));

                //// Options
                var xmlOptions = xDocument.Root.Element("Options");
                // DataSource
                Console.WriteLine("Load spreadsheet");
                dataSource = new Spreadsheet();
                dataSource.Open(Environment.ExpandEnvironmentVariables(xmlOptions.Element("DataSource").Element("Parameter").Value));
                ((Spreadsheet)dataSource).SetSheet(xmlOptions.Element("Spreadsheet").Element("Table").Value);

                // PDF
                Console.WriteLine("Load PDF");
                pdf = new PDF();
                pdf.Open(Environment.ExpandEnvironmentVariables(xmlOptions.Element("PDF").Element("Filepath").Value));

                //// PDFFieldValues
                Console.WriteLine("Load field configuration");
                Dictionary<string, PDFField> pdfFields = new Dictionary<string, PDFField>();
                foreach (var node in xDocument.Root.Element("PDFFieldValues").Descendants("PDFFieldValue"))
                {
                    var pdfField = new PDFField();
                    pdfField.Name = node.Element("Name").Value;
                    pdfField.DataSourceValue = pdfField.FixedValue = node.Element("NewValue").Value;
                    pdfField.UseValueFromDataSource = Convert.ToBoolean(node.Element("UseValueFromDataSource").Value);
                    pdfField.UseFixedValue = Convert.ToBoolean(node.Element("UseFixedValue").Value);
                    pdfField.MakeReadOnly = Convert.ToBoolean(node.Element("MakeReadOnly").Value);

                    pdfFields.Add(pdfField.Name, pdfField);
                }

                //// Filename
                Console.WriteLine("Load filename options");
                var xmlFilename = xmlOptions.Element("Filename");
                prefix = xmlFilename.Element("Prefix").Value;
                useValueFromDataSource = Convert.ToBoolean(xmlFilename.Element("ValueFromDataSource").Value);
                DataSourceColumnsFilenameIndex = ((Spreadsheet)dataSource).Columns.IndexOf(xmlFilename.Element("DataSource").Value);
                suffix = xmlFilename.Element("Suffix").Value;
                useRowNumber = Convert.ToBoolean(xmlFilename.Element("RowNumber").Value);

                //// Other
                Console.WriteLine("Load general options");
                bool finalize = Convert.ToBoolean(xmlOptions.Element("Finalize").Value);
                bool unicode = false;
                try
                {
                    unicode = Convert.ToBoolean(xmlOptions.Element("Unicode").Value);
                }
                catch
                {
                    // Ignore. Ugly but don't hurt anyone.
                }
                bool customFont = false;
                string customFontPath = "";
                try
                {
                    customFont = Convert.ToBoolean(xmlOptions.Element("CustomFont").Value);
                    customFontPath = Environment.ExpandEnvironmentVariables(xmlOptions.Element("CustomFontPath").Value);
                }
                catch
                {
                    // Ignore. Ugly but don't hurt anyone.
                }
                string outputDir = Environment.ExpandEnvironmentVariables(xmlOptions.Element("OutputDir").Value);

                Console.WriteLine("--- Start processing ---");
                PDFFiller.CreateFiles(pdf, finalize, unicode, customFont, customFontPath, dataSource, pdfFields, outputDir + @"\", ConcatFilename, WriteLinePercent);
                Console.WriteLine("!!! Finished !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        private string ConcatFilename(int dataSourceRow)
        {
            string filename = "";
            filename += prefix;
            if (useValueFromDataSource)
                filename += dataSource.GetField(DataSourceColumnsFilenameIndex + 1);
            filename += suffix;
            if (useRowNumber)
                filename += dataSourceRow;
            filename += ".pdf";

            return filename;
        }

        private void WriteLinePercent(int percent)
        {
            Console.WriteLine(String.Format("{0:000}%", percent));
        }
    }
}