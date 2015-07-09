namespace BulkPDF
{
    partial class ExceptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
            this.tbExceptionMessage = new System.Windows.Forms.TextBox();
            this.tbException = new System.Windows.Forms.TextBox();
            this.bOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbExceptionMessage
            // 
            this.tbExceptionMessage.Location = new System.Drawing.Point(12, 78);
            this.tbExceptionMessage.Multiline = true;
            this.tbExceptionMessage.Name = "tbExceptionMessage";
            this.tbExceptionMessage.ReadOnly = true;
            this.tbExceptionMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbExceptionMessage.Size = new System.Drawing.Size(260, 142);
            this.tbExceptionMessage.TabIndex = 1;
            // 
            // tbException
            // 
            this.tbException.Location = new System.Drawing.Point(12, 12);
            this.tbException.Multiline = true;
            this.tbException.Name = "tbException";
            this.tbException.ReadOnly = true;
            this.tbException.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbException.Size = new System.Drawing.Size(260, 60);
            this.tbException.TabIndex = 2;
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(12, 226);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(260, 23);
            this.bOK.TabIndex = 3;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.tbException);
            this.Controls.Add(this.tbExceptionMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbExceptionMessage;
        private System.Windows.Forms.TextBox tbException;
        private System.Windows.Forms.Button bOK;
    }
}