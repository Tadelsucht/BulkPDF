using SpreadsheetLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BulkPDF
{
    public class Spreadsheet : IDataSource
    {
        private List<string> columns = new List<string>();

        private string parameter = "";

        private int possibleRows = 0;

        private int rowIndex = 2;

        private Hashtable rowValues = new Hashtable();

        private SLDocument slDocument;

        public List<string> Columns
        {
            get { return columns; }
        }

        public string Parameter
        {
            get { return parameter; }
        }

        public int PossibleRows
        {
            get { return possibleRows; }
        }

        public Hashtable RowValues
        {
            get { return rowValues; }
        }

        public void Close()
        {
        }

        public string GetField(int columnIndex)
        {
            return slDocument.GetCellValueAsString(rowIndex, columnIndex);
        }

        public List<string> GetSheetNames()
        {
            return slDocument.GetSheetNames();
        }

        public bool NextRow()
        {
            rowIndex++;
            return true;
        }

        public void Open(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    slDocument = new SLDocument(fileStream);
                }
            }

            parameter = filePath;
            SetSheet(slDocument.GetSheetNames()[0]);
        }

        public void ResetRowCounter()
        {
            rowIndex = 2;
        }

        public bool SetSheet(string name)
        {
            slDocument.SelectWorksheet(name);
            possibleRows = CountPossibleRows();
            columns = ListColumns();
            ResetRowCounter();

            return true;
        }

        private int CountPossibleRows()
        {
            // headerColumnNumber
            int headerColumnNumber = 0;
            for (int column = 1; !string.IsNullOrEmpty(slDocument.GetCellValueAsString(1, column)); column++)
                headerColumnNumber += 1;

            int maxRowsTotal = 0;

            if (headerColumnNumber > 0)
            {
                for (int row = 2; true; row++)
                {
                    // Read row
                    var rowValues = new List<string>();
                    for (int column = 1; column <= headerColumnNumber; column++)
                        rowValues.Add(slDocument.GetCellValueAsString(row, column));

                    // Check if the row is empty
                    int notEmptyCells = 0;
                    foreach (var value in rowValues)
                        if (!String.IsNullOrEmpty(value))
                            notEmptyCells++;
                    if (notEmptyCells == 0)
                        break;

                    maxRowsTotal++;
                }
            }

            return maxRowsTotal;
        }

        private List<string> ListColumns()
        {
            List<string> columns = new List<string>();

            for (int x = 1; !string.IsNullOrEmpty(slDocument.GetCellValueAsString(1, x)); x++)
                columns.Add(slDocument.GetCurrentWorksheetName() + "[.]" + slDocument.GetCellValueAsString(1, x));

            return columns;
        }
    }
}