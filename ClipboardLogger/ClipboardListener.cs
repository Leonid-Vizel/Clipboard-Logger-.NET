using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardLogger
{
    internal class ClipboardListener
    {
        #region Inports
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        private static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll")]
        private static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Constants
        private const int WM_DRAWCLIPBOARD = 0X308;
        private const int WM_CHANGECBCHAIN = 0X030D;
        #endregion

        #region Fields
        private IntPtr nextClipboardViewer;
        #endregion

        #region Delegates
        public delegate void WndProcDelegate(ref Message m);
        public delegate void ClipboardChangedHandler();
        #endregion

        #region Events
        public event ClipboardChangedHandler ClipboardChanged;
        #endregion

        public ClipboardListener(IntPtr handle)
        {
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)handle);
        }

        public void WndProc(ref Message m, WndProcDelegate baseWndProc)
        {
            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    ClipboardChanged();
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
                    baseWndProc(ref m);
                    break;
            }
        }

    }
}
