using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkPDF
{
    public interface IDataSource
    {
        // ATTRIBUTES
        List<string> Columns { get; }
        int PossibleRows { get; }
        string Parameter { get; }

        // METHODS
        void Open(string parameter);
        void Close();
        bool NextRow();
        void ResetRowCounter();
        string GetField(int columnIndex);
    }
}
