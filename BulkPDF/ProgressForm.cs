using System;
using System.Drawing;
using System.Windows.Forms;

namespace BulkPDF
{
    public partial class ProgressForm : Form
    {
        private bool isAborted = false;
        private bool isFinished = false;
        private int percent;
        private Timer progressbarTimer;

        public ProgressForm()
        {
            InitializeComponent();

            progressbarTimer = new Timer();
            progressbarTimer.Interval = 250;
            progressbarTimer.Tick += timer_Tick;
            progressbarTimer.Start();
        }

        public bool GetIsAborted()
        {
            return isAborted;
        }

        public void SetPercent(int percent)
        {
            this.percent = percent;
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

        private void bAbort_Click(object sender, EventArgs e)
        {
            isAborted = true;
            MessageBox.Show(Properties.Resources.MessageAborted);
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }
    }
}