using System;
using System.Windows.Forms;

namespace BulkPDF
{
    internal class WizardPages : TabControl
    {
        public WizardPages()
        {
            this.TabStop = false;
        }

        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }
    }
}