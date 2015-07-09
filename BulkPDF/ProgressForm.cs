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
    public partial class ProgressForm : Form
    {
        bool isAborted = false;
        int percent;
        Timer progressbarTimer;
        bool isFinished = false;

        public ProgressForm()
        {
            InitializeComponent();

            progressbarTimer = new Timer();
            progressbarTimer.Interval = 250;
            progressbarTimer.Tick += timer_Tick;
            progressbarTimer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        public void UpdateProgressBar()
        {
            progressBar.Value = percent;

            try
            {
                progressBar.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar.Width / 2 - 10, progressBar.Height / 2 - 7));
            }
            catch (ObjectDisposedException) { }

            // Close if finished
            if (percent == 100)
            {
                if (!isFinished)
                {
                    isFinished = true;
                    progressbarTimer.Stop();
                    MessageBox.Show(Properties.Resources.MessageFinished);
                    this.Close();
                }
            }
        }

        public void SetPercent(int percent)
        {
            this.percent = percent;
        }

        public bool GetIsAborted()
        {
            return isAborted;
        }

        private void bAbort_Click(object sender, EventArgs e)
        {
            isAborted = true;
            MessageBox.Show(Properties.Resources.MessageAborted);
            this.Close();
        }
    }
}
