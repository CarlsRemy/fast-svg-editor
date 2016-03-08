using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastSVGEditor
{
    public partial class LogWindow : Form
    {
        public LogWindow()
        {
            InitializeComponent();
        }

        private void LogWindow_Resize(object sender, EventArgs e)
        {
            log.Width = this.ClientRectangle.Width;
            log.Height = this.ClientRectangle.Height;
        }

        public void writeLog(bool error, string message)
        {
            RichTextBoxExtensions.AppendText(log, message + "\n\n", error ? Color.Red : Color.Green);
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
