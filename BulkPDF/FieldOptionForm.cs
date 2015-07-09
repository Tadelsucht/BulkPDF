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
    public partial class FieldOptionForm : Form
    {
        public static Point SavedLocation;
        private PDFField pdfField;
        public PDFField PDFField
        {
            get { return this.pdfField; }
        }

        private bool shouldBeSaved = false;
        public bool ShouldBeSaved
        {
            get { return shouldBeSaved; }
        }

        public FieldOptionForm(Point location, PDFField pdfField, List<string> dataSourceColumns)
        {
            // Init
            this.pdfField = pdfField;
            if (SavedLocation == new Point(0,0))
            {
                this.DesktopLocation = location;
            }
            else
            {
                this.DesktopLocation = SavedLocation;
            }
            InitializeComponent();
            

            // Datasource
            foreach (var column in dataSourceColumns)
                cbDataSourceColumns.Items.Add(column);

            cbDataSourceColumns.SelectedIndex = 0;
            if (!String.IsNullOrEmpty(pdfField.DataSourceValue))
            {
                int index = cbDataSourceColumns.FindString(pdfField.DataSourceValue);

                if (index != -1)
                    cbDataSourceColumns.SelectedIndex = cbDataSourceColumns.FindString(pdfField.DataSourceValue);
            }
            
            cbUseValueFromDataSource.Checked = pdfField.UseValueFromDataSource;
            cbUseValueFromDataSource_CheckedChanged(null, null);

            cbReadOnly.Checked = pdfField.MakeReadOnly;
            cbReadOnly_CheckedChanged(null, null);
        }

        private void cbUseValueFromDataSource_CheckedChanged(object sender, EventArgs e)
        {
            cbDataSourceColumns.Enabled = cbUseValueFromDataSource.Checked;
            pdfField.UseValueFromDataSource = cbUseValueFromDataSource.Checked;
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            shouldBeSaved = true;
            this.Close();
        }

        private void cbDataSourceColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            pdfField.DataSourceValue = (string) cbDataSourceColumns.SelectedItem;
        }

        private void FieldOptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavedLocation = this.DesktopLocation;
        }

        private void cbReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            pdfField.MakeReadOnly = cbReadOnly.Checked;
        }
    }
}
