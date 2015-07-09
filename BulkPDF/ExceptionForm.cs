using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
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
