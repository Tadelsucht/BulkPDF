namespace BulkPDF
{
    partial class FieldOptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldOptionForm));
            this.cbDataSourceColumns = new System.Windows.Forms.ComboBox();
            this.bSet = new System.Windows.Forms.Button();
            this.cbUseValueFromDataSource = new System.Windows.Forms.CheckBox();
            this.cbReadOnly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbDataSourceColumns
            // 
            resources.ApplyResources(this.cbDataSourceColumns, "cbDataSourceColumns");
            this.cbDataSourceColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataSourceColumns.FormattingEnabled = true;
            this.cbDataSourceColumns.Name = "cbDataSourceColumns";
            this.cbDataSourceColumns.SelectedIndexChanged += new System.EventHandler(this.cbDataSourceColumns_SelectedIndexChanged);
            // 
            // bSet
            // 
            resources.ApplyResources(this.bSet, "bSet");
            this.bSet.Name = "bSet";
            this.bSet.UseVisualStyleBackColor = true;
            this.bSet.Click += new System.EventHandler(this.bSet_Click);
            // 
            // cbUseValueFromDataSource
            // 
            resources.ApplyResources(this.cbUseValueFromDataSource, "cbUseValueFromDataSource");
            this.cbUseValueFromDataSource.Name = "cbUseValueFromDataSource";
            this.cbUseValueFromDataSource.UseVisualStyleBackColor = true;
            this.cbUseValueFromDataSource.CheckedChanged += new System.EventHandler(this.cbUseValueFromDataSource_CheckedChanged);
            // 
            // cbReadOnly
            // 
            resources.ApplyResources(this.cbReadOnly, "cbReadOnly");
            this.cbReadOnly.Name = "cbReadOnly";
            this.cbReadOnly.UseVisualStyleBackColor = true;
            this.cbReadOnly.CheckedChanged += new System.EventHandler(this.cbReadOnly_CheckedChanged);
            // 
            // FieldOptionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbReadOnly);
            this.Controls.Add(this.cbUseValueFromDataSource);
            this.Controls.Add(this.bSet);
            this.Controls.Add(this.cbDataSourceColumns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FieldOptionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FieldOptionForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDataSourceColumns;
        private System.Windows.Forms.Button bSet;
        private System.Windows.Forms.CheckBox cbUseValueFromDataSource;
        private System.Windows.Forms.CheckBox cbReadOnly;

    }
}