using System.Collections.Generic;

namespace BulkPDF
{
    public interface IDataSource
    {
        // ATTRIBUTES
        List<string> Columns { get; }

        string Parameter { get; }
        int PossibleRows { get; }

        void Close();

        string GetField(int columnIndex);

        bool NextRow();

        // METHODS
        void Open(string parameter);

        void ResetRowCounter();
    }
}