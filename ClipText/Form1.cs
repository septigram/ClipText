using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipText
{
    public partial class Form1 : Form
    {
        private delegate void CallDelegate();

        public Form1()
        {
            InitializeComponent();
        }

        public void ClipboaradConv()
        {
            if (InvokeRequired)
            {
                Invoke(new CallDelegate(ClipboaradConv));
                return;
            }

            if (Clipboard.ContainsText())
            {
                string v = Clipboard.GetText();
                if (v != null)
                {
                    // Console.WriteLine($"ClipText: {v}");
                    Clipboard.SetText(v);
                }
            }

        }

        public void ClipboardSendDate()
        {
            if (InvokeRequired)
            {
                Invoke(new CallDelegate(ClipboardSendDate));
                return;
            }
            var v = DateTime.Now.ToString("yyyy/MM/dd");
            Clipboard.SetText(v);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            ClipboaradConv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClipboaradConv();
        }

        private void ClipboaradConvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClipboaradConv();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClipboardSendDateCtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardSendDate();
        }
    }
}
