using System;
using System.Media;
using System.Windows.Forms;

namespace BulkPDF
{
    public partial class ExceptionForm : Form
    {
        public ExceptionForm(string exception, string exceptionMessage)
        {
            InitializeComponent();
            tbException.Text = exception;
            tbExceptionMessage.Text = exceptionMessage;
            SystemSounds.Beep.Play();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}