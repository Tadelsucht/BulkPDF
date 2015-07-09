namespace BulkPDF
{
    partial class ShortcutCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortcutCreator));
            this.gbOuput = new System.Windows.Forms.GroupBox();
            this.tbConfigurationPath = new System.Windows.Forms.TextBox();
            this.bSelectConfiguration = new System.Windows.Forms.Button();
            this.bCreateShortcut = new System.Windows.Forms.Button();
            this.gbOuput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOuput
            // 
            resources.ApplyResources(this.gbOuput, "gbOuput");
            this.gbOuput.Controls.Add(this.tbConfigurationPath);
            this.gbOuput.Controls.Add(this.bSelectConfiguration);
            this.gbOuput.Name = "gbOuput";
            this.gbOuput.TabStop = false;
            // 
            // tbConfigurationPath
            // 
            resources.ApplyResources(this.tbConfigurationPath, "tbConfigurationPath");
            this.tbConfigurationPath.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbConfigurationPath.Name = "tbConfigurationPath";
            // 
            // bSelectConfiguration
            // 
            resources.ApplyResources(this.bSelectConfiguration, "bSelectConfiguration");
            this.bSelectConfiguration.Name = "bSelectConfiguration";
            this.bSelectConfiguration.UseVisualStyleBackColor = true;
            this.bSelectConfiguration.Click += new System.EventHandler(this.bSelectConfiguration_Click);
            // 
            // bCreateShortcut
            // 
            resources.ApplyResources(this.bCreateShortcut, "bCreateShortcut");
            this.bCreateShortcut.Name = "bCreateShortcut";
            this.bCreateShortcut.UseVisualStyleBackColor = true;
            this.bCreateShortcut.Click += new System.EventHandler(this.bCreateShortcut_Click);
            // 
            // ShortcutCreator
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bCreateShortcut);
            this.Controls.Add(this.gbOuput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ShortcutCreator";
            this.gbOuput.ResumeLayout(false);
            this.gbOuput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOuput;
        private System.Windows.Forms.TextBox tbConfigurationPath;
        private System.Windows.Forms.Button bSelectConfiguration;
        private System.Windows.Forms.Button bCreateShortcut;

    }
}