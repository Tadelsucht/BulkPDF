namespace BulkPDF
{
    internal static class ExceptionHandler
    {
        public static void Throw(string exception, string exceptionMessage)
        {
            var exceptionWindow = new ExceptionForm(exception, exceptionMessage);
            exceptionWindow.ShowDialog();
        }
    }
}