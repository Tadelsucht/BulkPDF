using System.Drawing;
using System.Windows.Forms;

namespace BulkPDF
{
    internal class SeperatorLine : Label
    {
        public SeperatorLine()
        {
            this.AutoSize = false;
            this.Height = 2;
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        public override bool AutoSize
        {
            get
            {
                return false;
            }
        }

        public override Size MaximumSize
        {
            get
            {
                return new Size(int.MaxValue, 2);
            }
        }

        public override Size MinimumSize
        {
            get
            {
                return new Size(500, 2);
            }
        }

        public override string Text
        {
            get
            {
                return "";
            }
        }
    }
}