using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkPDF
{
    public struct PDFField
    {
        public string Name;
        public string Typ;
        public string CurrentValue;
        public string DataSourceValue;
        public bool MakeReadOnly;
        public bool UseValueFromDataSource;
    }
}
