using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardLogger
{
    public partial class MainForm : Form
    {
        private const int WM_DRAWCLIPBOARD = 0X308;
        private const int WM_CHANGECBCHAIN = 0X030D;

        public MainForm()
        {
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)Handle);
            SetProcessDpiAwarenessContext(-1);
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(int value);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        IntPtr nextClipboardViewer;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                    {
                        nextClipboardViewer = m.LParam;
                    }
                    else
                    {
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void DisplayClipboardData()
        {
            string strClip = string.Empty;
            try
            {
                IDataObject dataObject = new DataObject();
                dataObject = Clipboard.GetDataObject();
                if (dataObject.GetDataPresent(DataFormats.UnicodeText) && (dataObject.GetData(DataFormats.UnicodeText).ToString() != string.Empty))
                {
                    strClip = dataObject.GetData(DataFormats.UnicodeText).ToString();
                }
                else if (dataObject.GetDataPresent(DataFormats.Text) && ((string)dataObject.GetData(DataFormats.StringFormat) != string.Empty))
                {
                    strClip = (string)dataObject.GetData(DataFormats.StringFormat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            clipList?.Items.Add(strClip);
        }
    }
}