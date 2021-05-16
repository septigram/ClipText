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
        private delegate void CallDelegate1(string msg);

        SortedDictionary<string, int> countMap = new SortedDictionary<string, int>();

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
                    SetClipboard(v);
                }
            }

        }

        public void IncrementKeyDown()
        {
            var ymdh = DateTime.Now.ToString("yyyy-MM-dd HH:00");
            if (countMap.TryGetValue(ymdh, out int keyCcount))
            {
                countMap[ymdh] = keyCcount + 1;
            }
            else
            {
                countMap[ymdh] = 1;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var e in countMap.Reverse())
            {
                sb.Append($"{e.Key} {e.Value}\r\n");
            }
            UpdateState(sb.ToString());
        }

        public void UpdateState(string msg)
        {
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke(new CallDelegate1(UpdateState), new object[] { msg });
                return;
            }
            textBoxLog.Text = msg;
        }

        public void ClipboardSendDate()
        {
            if (InvokeRequired)
            {
                Invoke(new CallDelegate(ClipboardSendDate));
                return;
            }
            var v = DateTime.Now.ToString("yyyy/MM/dd");
            SetClipboard(v);
        }

        void SetClipboard(string v)
        {
            try {
                Clipboard.SetText(v);
            } catch (Exception e) { }
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
            Environment.Exit(0);
        }

        private void ClipboardSendDateCtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardSendDate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }
    }
}
