using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkPDF
{
    static class ExceptionHandler
    {
        public static void Throw(string exception, string exceptionMessage)
        {
            var exceptionWindow  = new ExceptionForm(exception, exceptionMessage);
            exceptionWindow.ShowDialog();
        }
    }
}
