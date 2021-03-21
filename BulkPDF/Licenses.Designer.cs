namespace BulkPDF
{
    partial class Licenses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Licenses));
            this.rtbLicenses = new System.Windows.Forms.RichTextBox();
            this.gbiTextSharp = new System.Windows.Forms.GroupBox();
            this.rtbLibraries = new System.Windows.Forms.RichTextBox();
            this.gbBulkPDF = new System.Windows.Forms.GroupBox();
            this.gbSpreadsheetLight = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.gbiTextSharp.SuspendLayout();
            this.gbBulkPDF.SuspendLayout();
            this.gbSpreadsheetLight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLicenses
            // 
            this.rtbLicenses.Location = new System.Drawing.Point(6, 19);
            this.rtbLicenses.Name = "rtbLicenses";
            this.rtbLicenses.ReadOnly = true;
            this.rtbLicenses.Size = new System.Drawing.Size(448, 120);
            this.rtbLicenses.TabIndex = 0;
            this.rtbLicenses.Text = resources.GetString("rtbLicenses.Text");
            // 
            // gbiTextSharp
            // 
            this.gbiTextSharp.Controls.Add(this.rtbLibraries);
            this.gbiTextSharp.Location = new System.Drawing.Point(12, 163);
            this.gbiTextSharp.Name = "gbiTextSharp";
            this.gbiTextSharp.Size = new System.Drawing.Size(460, 90);
            this.gbiTextSharp.TabIndex = 1;
            this.gbiTextSharp.TabStop = false;
            this.gbiTextSharp.Text = "iTextSharp";
            // 
            // rtbLibraries
            // 
            this.rtbLibraries.Location = new System.Drawing.Point(6, 20);
            this.rtbLibraries.Name = "rtbLibraries";
            this.rtbLibraries.ReadOnly = true;
            this.rtbLibraries.Size = new System.Drawing.Size(448, 64);
            this.rtbLibraries.TabIndex = 0;
            this.rtbLibraries.Text = resources.GetString("rtbLibraries.Text");
            // 
            // gbBulkPDF
            // 
            this.gbBulkPDF.Controls.Add(this.rtbLicenses);
            this.gbBulkPDF.Location = new System.Drawing.Point(12, 12);
            this.gbBulkPDF.Name = "gbBulkPDF";
            this.gbBulkPDF.Size = new System.Drawing.Size(460, 145);
            this.gbBulkPDF.TabIndex = 2;
            this.gbBulkPDF.TabStop = false;
            this.gbBulkPDF.Text = "BulkPDF";
            // 
            // gbSpreadsheetLight
            // 
            this.gbSpreadsheetLight.Controls.Add(this.richTextBox1);
            this.gbSpreadsheetLight.Location = new System.Drawing.Point(12, 259);
            this.gbSpreadsheetLight.Name = "gbSpreadsheetLight";
            this.gbSpreadsheetLight.Size = new System.Drawing.Size(460, 90);
            this.gbSpreadsheetLight.TabIndex = 3;
            this.gbSpreadsheetLight.TabStop = false;
            this.gbSpreadsheetLight.Text = "SpreadsheetLight";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(448, 64);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GNU Unifont";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 20);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(448, 64);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // Licenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 452);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSpreadsheetLight);
            this.Controls.Add(this.gbBulkPDF);
            this.Controls.Add(this.gbiTextSharp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Licenses";
            this.Text = "Licenses";
            this.gbiTextSharp.ResumeLayout(false);
            this.gbBulkPDF.ResumeLayout(false);
            this.gbSpreadsheetLight.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLicenses;
        private System.Windows.Forms.GroupBox gbiTextSharp;
        private System.Windows.Forms.RichTextBox rtbLibraries;
        private System.Windows.Forms.GroupBox gbBulkPDF;
        private System.Windows.Forms.GroupBox gbSpreadsheetLight;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}