using System;
using System.Windows.Forms;

namespace BulkPDF
{
    public partial class ShortcutCreator : Form
    {
        private string configurationFilePath;

        public ShortcutCreator()
        {
            InitializeComponent();
        }

        private void bCreateShortcut_Click(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(configurationFilePath))
            //{
            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //    saveFileDialog.Filter = "Shortcut|*.lnk";
            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        WshShell wshShell = new WshShell();
            //        IWshShortcut shortcut = (IWshShortcut)wshShell.CreateShortcut(saveFileDialog.FileName + ".lnk");
            //        shortcut.Arguments = "\"" + configurationFilePath + "\" wait";
            //        shortcut.WorkingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //        shortcut.TargetPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + "BulkPDFConsole.exe"; ;
            //        shortcut.Save();

            //        MessageBox.Show(Properties.Resources.MessageFinished);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(Properties.Resources.MessageSelectConfiguration);
            //}
        }

        private void bSelectConfiguration_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "BulkPDF Options|*.bulkpdf";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                configurationFilePath = openFileDialog.FileName;
                tbConfigurationPath.Text = configurationFilePath;
            }
        }
    }
}