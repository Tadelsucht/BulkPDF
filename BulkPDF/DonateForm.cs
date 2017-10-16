using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BulkPDF
{
    public partial class DonateForm : Form
    {
        public DonateForm()
        {
            InitializeComponent();
        }
        private void bSet_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
